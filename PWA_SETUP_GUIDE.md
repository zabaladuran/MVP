# Guía Rápida PWA - Próximos Pasos

## ✅ Ya Configurado

Tu app Blazer ahora es una PWA completamente funcional con:

- ✅ Service Worker con estrategia de caché inteligente
- ✅ Funcionamiento offline
- ✅ Instalable como app nativa
- ✅ Botón de instalación integrado
- ✅ Página de información PWA
- ✅ Detección de conexión online/offline
- ✅ Notificaciones de estado
- ✅ Soporte para dispositivos con notch

## 📋 Tareas Pendientes (Recomendadas)

### 1. Crear Iconos de Aplicación
La app busca iconos en estos tamaños:
- `/icon-192x192.png` (Icono estándar 192x192)
- `/icon-512x512.png` (Icono estándar 512x512)
- `/icon-maskable-192x192.png` (Para iconos adaptables)
- `/icon-maskable-512x512.png` (Para iconos adaptables)

> Coloca los PNG en `wwwroot/` junto a `manifest.json`

### 2. Actualizar Favicon
Reemplaza o crea un favicon adecuado:
- Ubicación: `wwwroot/favicon.png`
- Tamaño recomendado: 192x192 o superior
- Formato: PNG con fondo transparente

### 3. Crear Página de Bienvenida Offline (Opcional)
Actualmente existe `wwwroot/offline.html`. Puedes personalizarla:
- Agregar logo de tu app
- Cambiar colores para que coincida con tu branding
- Añadir instrucciones personalizadas

## 🚀 Cómo Probar

### Desktop (Chrome/Edge)
```
1. Abre DevTools (F12)
2. Ve a Application → Service Workers
3. Verás "service-worker" registrado
4. Busca el botón "Instalar" en la barra de direcciones
```

### Mobile (Android)
```
1. Abre en Chrome
2. Busca el menú (⋮) → "Instalar app"
3. La app se agregará a tu pantalla de inicio
```

### Modo Offline
```
1. DevTools → Network
2. Marcar "Offline"
3. La app sigue funcionando con contenido cacheado
4. Desmarcar "Offline" → Auto-recarga
```

## 📁 Estructura de Archivos PWA

```
wwwroot/
├── manifest.json           # Configuración de la app
├── service-worker.js       # Logic offline
├── app.js                  # Registro y gestión
├── offline.html            # Página sin conexión
├── favicon.png             # Icono de la app
├── icon-192x192.png        # Icono mediano
├── icon-512x512.png        # Icono grande
├── css/
│   └── pwa.css            # Estilos PWA
└── bootstrap/
```

## 🔧 Configuración Personalizable

### En `manifest.json`
- `name`: Nombre completo de la app
- `short_name`: Nombre corto (máx 12 caracteres)
- `description`: Descripción
- `start_url`: Página inicial (`/`)
- `theme_color`: Color del tema
- `background_color`: Color de fondo

### En `service-worker.js`
- `CACHE_NAME`: Nombre del caché (versionar con v1, v2, etc)
- `urlsToCache`: URLs adicionales para precargar
- Estrategias de caché personalizables

## 🎨 Personalización

### Cambiar Colores
En `manifest.json`:
```json
"theme_color": "#667eea",
"background_color": "#ffffff"
```

### Cambiar Nombre
En `manifest.json`:
```json
"name": "Mi App Tienda",
"short_name": "MiTienda"
```

## 🔐 Requisitos Importantes

- ✅ **HTTPS obligatorio** (PWA no funciona en HTTP local en producción)
- ✅ Service Worker registrado ✓
- ✅ Manifest.json válido ✓
- ⚠️ Iconos de aplicación (necesarios para instalación completa)
- ⚠️ Favicon personalizado (recomendado)

## 📊 Verificar Estado

Abre la consola del navegador y verás:
```
✓ Service Worker registered successfully
✓ PWA app.js loaded
```

En `Settings → Application` de DevTools:
- Service Workers: Debe mostrar tu service worker activo
- Manifest: Debe mostrar los detalles del manifest.json
- Storage: Cache Storage con "tienda-pwa-v1"

## 💡 Consejos

1. **Para desarrollo**: Usa DevTools → Application para depurar service worker
2. **Para producción**: Asegúrate de usar HTTPS
3. **Actualizaciones**: Incrementa `CACHE_NAME` para forzar actualización
4. **Testing**: Prueba en múltiples dispositivos/navegadores

---

**¿Preguntas?** Revisa la página `/pwa-info` en la app para más detalles.
