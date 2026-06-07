# README para la aplicación Android

## Estructura del Proyecto

```
android-studio-app/
├── app/
│   ├── src/
│   │   ├── main/
│   │   │   ├── java/com/duran/appmvp/
│   │   │   │   └── MainActivity.kt
│   │   │   ├── res/
│   │   │   │   ├── layout/
│   │   │   │   │   └── activity_main.xml
│   │   │   │   ├── values/
│   │   │   │   │   ├── colors.xml
│   │   │   │   │   ├── strings.xml
│   │   │   │   │   └── styles.xml
│   │   │   └── AndroidManifest.xml
│   │   ├── test/
│   │   └── androidTest/
│   └── build.gradle
├── build.gradle
├── settings.gradle
└── gradle.properties
```

## Requisitos

- Android Studio Jellyfish (2023.3.1) o superior
- JDK 1.8 o superior
- Android SDK 21+ (mínimo)
- Emulador Android o dispositivo físico

## Pasos para ejecutar

### 1. Abrir en Android Studio

1. Abre Android Studio
2. File → Open → Selecciona la carpeta `android-studio-app`
3. Espera a que Gradle sincronice (puede tardar 2-3 minutos)

### 2. Levanta Docker (desde otra terminal)

```powershell
cd C:\Users\elsek\OneDrive\Desktop\uiwu\MVP
docker-compose up -d
```

### 3. Verifica que PHP está funcionando

Abre en tu navegador: `http://localhost:8000`

Deberías ver tu aplicación PHP.

### 4. Ejecuta la aplicación Android

En Android Studio:
1. Build → Build Bundle(s) / APK(s) → Build APK(s)
2. O presiona Shift+F10 para ejecutar directamente

### 5. Prueba en el Emulador

- El emulador cargará automáticamente: `http://10.0.2.2:8000`
- `10.0.2.2` es la IP especial del emulador para acceder al host local

## Configuración de Conectividad

### Emulador Android

```
URL: http://10.0.2.2:8000
```

### Dispositivo Físico

Si quieres usar un celular real:
1. Obtén la IP local de tu PC: `ipconfig` (busca IPv4)
2. Usa esa IP en lugar de `10.0.2.2`

Ejemplo:
```kotlin
webView.loadUrl("http://192.168.1.100:8000")
```

### Cambiar Puerto

Si quieres usar otro puerto (8001 o 8002):

**En `MainActivity.kt`**, cambia:
```kotlin
webView.loadUrl("http://10.0.2.2:8000")
```

por:

```kotlin
webView.loadUrl("http://10.0.2.2:8001")  // o 8002
```

## Troubleshooting

### La aplicación no carga

1. Verifica que Docker está en marcha: `docker ps`
2. Verifica que PHP está disponible: `http://localhost:8000` en tu navegador
3. En el emulador, abre Chrome y prueba: `http://10.0.2.2:8000`

### Errores de permisos

- Asegúrate de que `AndroidManifest.xml` tiene: `<uses-permission android:name="android.permission.INTERNET" />`

### WebView muestra página en blanco

1. Habilita JavaScript en MainActivity: ✅ Ya está habilitado
2. Verifica que el backend PHP no tiene errores
3. Abre DevTools en Chrome del emulador (Ctrl+Shift+I)

## Más información

- [DOCKER_SETUP.md](../DOCKER_SETUP.md) - Configuración de Docker
- [ENV_GUIDE.md](../ENV_GUIDE.md) - Variables de entorno
- [README.md](../README.md) - Guía general del proyecto
