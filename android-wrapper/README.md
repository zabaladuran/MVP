# Android APK Wrapper (Cordova)

Este directorio contiene la configuración mínima para crear un APK que cargue tu web local desde un `WebView`.

## Requisitos

1. Node.js instalado.
2. Cordova instalado globalmente:
   ```bash
   npm install -g cordova
   ```
3. Android SDK command-line tools instalados.
4. `ANDROID_HOME` configurado en tu sistema y las plataformas Android instaladas.

## Pasos para crear la APK

1. En el directorio del proyecto, crea la aplicación Cordova:
   ```bash
   cd C:\xampp\htdocs\MVP
   cordova create android-wrapper com.mvp.app MVPWrapper
   ```

2. Entra en el proyecto y agrega Android:
   ```bash
   cd android-wrapper
   cordova platform add android
   ```

3. Reemplaza el `config.xml` del proyecto con el archivo existente aquí.
   - Si ya existe, copia el contenido del `android-wrapper/config.xml` a `android-wrapper/config.xml` del proyecto.

4. Construye la APK:
   ```bash
   cordova build android --release
   ```

5. El APK generado estará en:
   ```text
   android-wrapper/platforms/android/app/build/outputs/apk/release/app-release-unsigned.apk
   ```

6. Firma el APK si deseas instalarlo en un teléfono real.

## Configuración de URL

El wrapper está configurado para cargar tu aplicación web en:

```text
http://192.168.101.10:8000/
```

Eso significa que tu PC debe seguir conectado a la misma red Wi-Fi que tu móvil.

## Nota

Este APK no contiene la app web dentro del código nativo; simplemente abre tu sitio web local en un `WebView`.

Si quieres que el APK incluya HTML local en vez de cargar desde la red, te puedo ajustar el `www/index.html` para eso.
