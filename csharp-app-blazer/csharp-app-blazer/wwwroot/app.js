// Register Service Worker
if ('serviceWorker' in navigator) {
  window.addEventListener('load', () => {
    navigator.serviceWorker.register('/service-worker.js')
      .then((registration) => {
        console.log('Service Worker registered successfully:', registration);
        
        // Check for updates periodically
        setInterval(() => {
          registration.update();
        }, 60000); // Check every 60 seconds
      })
      .catch((error) => {
        console.log('Service Worker registration failed:', error);
      });

    // Listen for controller change (new service worker activated)
    navigator.serviceWorker.addEventListener('controllerchange', () => {
      console.log('Service Worker controller changed');
    });
  });

  // Handle messages from service worker
  navigator.serviceWorker.addEventListener('message', (event) => {
    console.log('Message from Service Worker:', event.data);
  });
}

// Detect online/offline status
window.addEventListener('online', () => {
  console.log('App is online');
  document.body.classList.remove('offline');
  showNotification('¡Estás de vuelta en línea!', 'success');
});

window.addEventListener('offline', () => {
  console.log('App is offline');
  document.body.classList.add('offline');
  showNotification('Sin conexión - algunas funciones pueden estar limitadas', 'warning');
});

// Check initial online status
if (!navigator.onLine) {
  document.body.classList.add('offline');
}

console.log('PWA app.js loading...');

// PWA Installation Prompt
let deferredPrompt;
let isPWAPromptAvailable = false;

// Listen for the beforeinstallprompt event BEFORE page load
window.addEventListener('beforeinstallprompt', (e) => {
  console.log('beforeinstallprompt event fired');
  e.preventDefault();
  deferredPrompt = e;
  isPWAPromptAvailable = true;
  console.log('PWA install prompt available', e);
  
  // Show the install button
  showInstallButton();
});

window.addEventListener('appinstalled', () => {
  console.log('PWA was installed');
  deferredPrompt = null;
  isPWAPromptAvailable = false;
  hideInstallButton();
  showNotification('¡App instalada correctamente!', 'success');
});

// Function to show install button
function showInstallButton() {
  const container = document.getElementById('pwa-install-container');
  if (container) {
    container.style.display = 'block';
    console.log('Install button shown');
  }
}

// Function to hide install button
function hideInstallButton() {
  const container = document.getElementById('pwa-install-container');
  if (container) {
    container.style.display = 'none';
    console.log('Install button hidden');
  }
}

// Utility function to show notifications
function showNotification(message, type = 'info') {
  const notification = document.createElement('div');
  notification.className = `pwa-notification pwa-notification-${type}`;
  notification.textContent = message;
  notification.style.cssText = `
    position: fixed;
    top: 20px;
    right: 20px;
    padding: 12px 20px;
    border-radius: 4px;
    background-color: ${type === 'success' ? '#28a745' : type === 'warning' ? '#ffc107' : '#17a2b8'};
    color: ${type === 'warning' ? '#000' : '#fff'};
    z-index: 9999;
    font-size: 14px;
    box-shadow: 0 2px 8px rgba(0,0,0,0.2);
    animation: slideIn 0.3s ease-in-out;
  `;
  
  document.body.appendChild(notification);
  
  setTimeout(() => {
    notification.style.animation = 'slideOut 0.3s ease-in-out';
    setTimeout(() => notification.remove(), 300);
  }, 3000);
}

// Add animation styles
if (!document.querySelector('#pwa-animations')) {
  const style = document.createElement('style');
  style.id = 'pwa-animations';
  style.textContent = `
    @keyframes slideIn {
      from {
        transform: translateX(400px);
        opacity: 0;
      }
      to {
        transform: translateX(0);
        opacity: 1;
      }
    }
    
    @keyframes slideOut {
      from {
        transform: translateX(0);
        opacity: 1;
      }
      to {
        transform: translateX(400px);
        opacity: 0;
      }
    }
    
    body.offline {
      opacity: 0.85;
    }
  `;
  document.head.appendChild(style);
}

// Expose install function for Blazor interop
window.installPWA = async function() {
  console.log('installPWA called, deferredPrompt:', !!deferredPrompt);
  
  if (!deferredPrompt) {
    console.log('Install prompt not available');
    showNotification('El navegador no soporta instalación en este momento', 'warning');
    return false;
  }
  
  try {
    deferredPrompt.prompt();
    const { outcome } = await deferredPrompt.userChoice;
    console.log(`User response to the install prompt: ${outcome}`);
    
    if (outcome === 'accepted') {
      deferredPrompt = null;
      isPWAPromptAvailable = false;
      showNotification('¡Instalando app...', 'success');
    }
    return outcome === 'accepted';
  } catch (error) {
    console.error('Error during installation:', error);
    showNotification('Error durante la instalación', 'warning');
    return false;
  }
};

// Check if app is running as PWA
window.isPWA = function() {
  return window.navigator.standalone === true || 
         window.matchMedia('(display-mode: standalone)').matches ||
         window.matchMedia('(display-mode: fullscreen)').matches;
};

// Check PWA support
window.getPWASupport = function() {
  return {
    serviceWorkerSupport: 'serviceWorker' in navigator,
    installPromptAvailable: isPWAPromptAvailable,
    isRunningAsPWA: window.isPWA(),
    httpsEnabled: window.location.protocol === 'https:' || window.location.hostname === 'localhost'
  };
};

// Log PWA status when page loads
window.addEventListener('DOMContentLoaded', () => {
  console.log('PWA Support:', window.getPWASupport());
  console.log('PWA app.js loaded successfully');
});

console.log('PWA app.js loading...');
