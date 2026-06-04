# Ejecuta esto desde C:\xampp\htdocs\MVP\android-wrapper
# Requiere Cordova instalado globalmente y Android SDK configurado.

if (-not (Get-Command cordova -ErrorAction SilentlyContinue)) {
    Write-Host "Cordova no está instalado. Ejecuta: npm install -g cordova" -ForegroundColor Yellow
    exit 1
}

$defaultJavaHome = "C:\Program Files\Eclipse Adoptium\jdk-17.0.19.10-hotspot"
$defaultAndroidSdk = "C:\Users\elsek\AppData\Local\Android\Sdk"
$defaultSdkTools = "C:\Users\elsek\.bubblewrap\android_sdk\tools"

if (-not $env:JAVA_HOME -and (Test-Path "$defaultJavaHome\bin\javac.exe")) {
    Write-Host "Configurando JAVA_HOME = $defaultJavaHome" -ForegroundColor Yellow
    $env:JAVA_HOME = $defaultJavaHome
}
if (-not $env:ANDROID_HOME -and (Test-Path $defaultAndroidSdk)) {
    Write-Host "Configurando ANDROID_HOME = $defaultAndroidSdk" -ForegroundColor Yellow
    $env:ANDROID_HOME = $defaultAndroidSdk
}
if (-not $env:ANDROID_SDK_ROOT -and (Test-Path $defaultAndroidSdk)) {
    Write-Host "Configurando ANDROID_SDK_ROOT = $defaultAndroidSdk" -ForegroundColor Yellow
    $env:ANDROID_SDK_ROOT = $defaultAndroidSdk
}

if ($env:JAVA_HOME) {
    $env:PATH = "$env:PATH;$env:JAVA_HOME\bin"
}
if ($env:ANDROID_HOME) {
    $env:PATH = "$env:PATH;$env:ANDROID_HOME\platform-tools"
}
if ((Test-Path "$defaultSdkTools\bin") -and (-not ($env:PATH -split ';' | Where-Object { $_ -eq "$defaultSdkTools\bin" }))) {
    $env:PATH = "$env:PATH;$defaultSdkTools\bin"
}

$gradleExe = Get-ChildItem -Path "$env:USERPROFILE\.gradle\wrapper\dists" -Filter gradle.bat -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
if (-not (Get-Command gradle -ErrorAction SilentlyContinue) -and $gradleExe) {
    $gradleBin = $gradleExe.DirectoryName
    if (-not ($env:PATH -split ';' | Where-Object { $_ -eq $gradleBin })) {
        Write-Host "Agregando Gradle wrapper al PATH: $gradleBin" -ForegroundColor Yellow
        $env:PATH = "$env:PATH;$gradleBin"
    }
}

if ((Test-Path $defaultAndroidSdk) -and -not (Test-Path "$defaultAndroidSdk\cmdline-tools\latest")) {
    if (Test-Path $defaultSdkTools) {
        Write-Host "Copiando cmdline-tools del paquete instalado en .bubblewrap..." -ForegroundColor Yellow
        New-Item -ItemType Directory -Force -Path "$defaultAndroidSdk\cmdline-tools\latest" | Out-Null
        Copy-Item -Path "$defaultSdkTools\*" -Destination "$defaultAndroidSdk\cmdline-tools\latest" -Recurse -Force
    } else {
        Write-Host "ADVERTENCIA: falta cmdline-tools y no se encontró el paquete en $defaultSdkTools" -ForegroundColor Red
    }
}

Write-Host "Agregando plataforma Android si no existe..." -ForegroundColor Cyan
cordova platform add android | Write-Host

Write-Host "Construyendo APK..." -ForegroundColor Cyan
$buildResult = cordova build android --release 2>&1
$buildSuccess = $LASTEXITCODE -eq 0
$buildResult | Write-Host

if (-not $buildSuccess) {
    Write-Host "ERROR: La compilación falló. Revisa los mensajes anteriores." -ForegroundColor Red
    exit 1
}

$apkPath = "android-wrapper\platforms\android\app\build\outputs\apk\release\app-release-unsigned.apk"
if (Test-Path $apkPath) {
    Write-Host "APK generado en: $apkPath" -ForegroundColor Green
} else {
    Write-Host "ERROR: No se encontró el APK en $apkPath" -ForegroundColor Red
    exit 1
}
