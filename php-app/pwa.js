if ('serviceWorker' in navigator) {
  window.addEventListener('load', () => {
    navigator.serviceWorker.register('service-worker.js')
      .then(registration => {
        console.log('Service Worker registrado:', registration.scope);
      })
      .catch(error => {
        console.warn('Error registrando Service Worker:', error);
      });
  });
}
