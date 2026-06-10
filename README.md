# MVP - Mercado Shop (Desktop, Web)

Solución multi-plataforma para gestión de tiendas con aplicaciones web y desktop sincronizadas en una base de datos compartida. El proyecto conserva los archivos PWA necesarios para integración web progresiva.

## Tabla de Contenidos

1. [Inicio Rápido](#-inicio-rápido)
2. [Scripts Disponibles](#-scripts-disponibles)
3. [Acceder a las Aplicaciones](#-acceder-a-las-aplicaciones)
4. [Documentación Completa](#-documentación-completa)
5. [Troubleshooting](#-troubleshooting)

---

## Inicio Rápido

### Opción 1: Script Interactivo (RECOMENDADO)

**La forma más fácil - Un comando y menú**

#### En Windows (PowerShell)
```powershell
# Abre PowerShell en la carpeta del proyecto
cd C:\Users\ronal\OneDrive\Escritorio\MVP

# Ejecuta el script
    powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Selecciona: 1 (para Desarrollo Local)
# Espera 30-60 segundos
```

**Ventajas:**
- ✅ Gestiona todo automáticamente (local vs producción)
- ✅ Menú interactivo y fácil
- ✅ Muestra logs, configuración, control de contenedores
- ✅ Detiene contenedores previos automáticamente

#### En Linux/Mac (Bash)
```bash
cd ~/Escritorio/MVP
chmod +x switch-env.sh
./switch-env.sh

# Selecciona: 1 (para Desarrollo Local)
```

Para más detalles: Ver sección [Scripts Disponibles](#-scripts-disponibles)

---

### Opción 2: Comando Directo

**Si prefieres ejecutar directamente sin menú:**

```bash
# Desarrollo Local (automático)
docker-compose up -d

# Producción (necesita .env.production configurado)
docker-compose --env-file .env.production up -d
```

**Nota:** El script (Opción 1) es preferible porque:
- Elige automáticamente `.env.local` para desarrollo
- Maneja errores y da feedback visual
- Permite cambiar entre entornos fácilmente

---

## Scripts Disponibles

### `switch-env.ps1` (Windows)

**Gestor interactivo de configuración y contenedores**

#### ¿Qué hace?
Script que facilita cambiar entre desarrollo local y producción sin escribir comandos largos de Docker.

#### Ejecutar:
```powershell
powershell -ExecutionPolicy Bypass -File switch-env.ps1
```

#### Opciones del Menú:

| Opción | Acción | Ejemplo de Uso |
|--------|--------|----------------|
| **1** | Levanta contenedores en **Desarrollo Local** (.env.local) | Primer inicio, desarrollo |
| **2** | Levanta contenedores en **Producción** (.env.production) | Deploy a servidor |
| **3** | Muestra variables de configuración (.env.local y .env.production) | Verificar settings |
| **4** | Muestra logs en tiempo real (elige local o production) | Debugging |
| **5** | Detiene todos los contenedores | Limpieza, pausa |
| **6** | Sale del script | - |

#### Flujo Típico - Primer Inicio:

```powershell
# 1. Abre PowerShell en la carpeta del proyecto
cd C:\Users\Desktop\MVP

# 2. Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# 3. Verás el menú - escribe: 1
# Opción [1-6]: 1

# 4. Espera 30-60 segundos
# El script:
#   - Detiene contenedores previos (si existen)
#   - Levanta MySQL, PHP, C#, Android, PhpMyAdmin
#   - Muestra los puertos disponibles
```

#### Flujo - Cambiar a Producción:

```powershell
# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Escribe: 2
# Opción [1-6]: 2

# Te pedirá confirmación (escribe: s)
# ¿Deseas continuar? (s/n): s

# Levantará con .env.production (valores reales de servidor)
```

#### Flujo - Ver Logs en Tiempo Real:

```powershell
# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Escribe: 4
# Opción [1-6]: 4

# Elige entorno: local
# ¿De qué entorno? (local/production): local

# Verás logs en tiempo real de todos los contenedores
# Presiona Ctrl+C para salir
```

#### Flujo - Ver Configuración:

```powershell
# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Escribe: 3
# Opción [1-6]: 3

# Muestra todas las variables de .env.local y .env.production
```

### `switch-env.sh` (Linux/Mac)

**Mismo menú y funcionalidad que PowerShell**

#### Ejecutar:
```bash
chmod +x switch-env.sh
./switch-env.sh
```

Usa las mismas opciones 1-6 descritas arriba.

---

# Acceder a las aplicaciones

Una vez iniciado, accede a:

| Aplicación | URL | Puerto |
|-----------|-----|--------|
| **PHP Web** | http://localhost:8000 | 8000, 8001, 8002 |
| **C# Desktop** | http://localhost:5000 | 5000, 5001, 5002 |
| **PhpMyAdmin** | http://localhost:8080 | 8080, 8081, 8082 |

**Credenciales BD:**
```
Usuario: mvp_user
Contraseña: mvp_password
Host: localhost
BD: mvp_db
```

---

## Documentación Completa

| Documento | Descripción | Relación con `switch-env` |
|-----------|------------|--------------------------|
| [DOCKER_SETUP.md](DOCKER_SETUP.md) | Arquitectura de contenedores, puertos, networking | El script usa `docker-compose` basado en esta configuración |
| [ENV_GUIDE.md](ENV_GUIDE.md) | Configuración `.env.local` vs `.env.production` | El script cambia automáticamente entre estos archivos (opción 2 vs 3) |
| [DATABASE_INIT.md](DATABASE_INIT.md) | Inicialización automática de base de datos | El script ejecuta Docker que triggeriza el script `init.sql` |

---

## Flujo Típico

### Primer Uso - Desarrollo Local

```powershell
# 1. Abre PowerShell en la carpeta
cd C:\Users\ronal\OneDrive\Escritorio\MVP

# 2. Ejecuta el script gestor
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# 3. Selecciona opción 1
# Opción [1-6]: 1

# 4. Espera 30-60 segundos a que inicien todos los contenedores

# 5. Accede a las aplicaciones
# PHP:        http://localhost:8000
# C#:         http://localhost:5000
# PhpMyAdmin: http://localhost:8080

# 6. Ver estado de contenedores
docker-compose ps
```

### Ver Logs si hay Problemas

```powershell
# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Selecciona opción 4 (Logs en tiempo real)
# Opción [1-6]: 4

# Elige: local
# ¿De qué entorno? (local/production): local

# Presiona Ctrl+C para salir
```

### Parar Contenedores

```powershell
# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Selecciona opción 5 (Detener contenedores)
# Opción [1-6]: 5
```

### Cambiar a Producción

```powershell
# Primero EDITA .env.production con valores reales

# Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# Selecciona opción 2
# Opción [1-6]: 2

# Confirma
# ¿Deseas continuar? (s/n): s

# Levantará con configuración de producción
```

---

## Troubleshooting Rápido

**Puerto ocupado:**
```bash
# Edita .env.local y cambia los puertos
nano .env.local
# Reconstruye
docker-compose down && docker-compose up -d
```

**BD no se crea:**
```bash
# Elimina volumen y reinicia
docker-compose down -v
docker-compose up -d
```

**Ver errores:**
```bash
docker-compose logs mysql  # Errores de BD
docker-compose logs php-app  # Errores PHP
```

---

## Tecnologías

- **PHP 8.1** - Aplicación web
- **C# .NET 9** - Aplicación desktop
- **MySQL 8.0** - Base de datos compartida
- **Docker Compose** - Orquestación de contenedores

---

## Estructura del Proyecto

```
MVP/
├── switch-env.ps1              ← Script Windows
├── switch-env.sh               ← Script Linux/Mac
├── docker-compose.yml          ← Config contenedores
├── .env.local                  ← Variables locales
├── .env.production             ← Variables producción
├── README.md                   ← Este archivo
├── DOCKER_SETUP.md             ← Documentación completa
├── ENV_GUIDE.md                ← Guía de configuración
├── DATABASE_INIT.md            ← Inicialización BD
├── database/
│   └── init.sql                ← Script SQL inicial
├── php-app/                    ← Aplicación PHP
├── csharp-app/                 ← Aplicación C#
└── android-app/                ← Archivos PWA estáticos (manifest, pwa.js, service-worker.js)
```

---

## Referencias Rápidas

```bash
# Ver todo en tiempo real
docker-compose up -d && docker-compose logs -f

# Acceder a MySQL
docker-compose exec mysql mysql -u mvp_user -p mvp_db

# Reiniciar servicio
docker-compose restart php-app

# Parar sin eliminar datos
docker-compose down

# Parar y limpiar todo
docker-compose down -v
```

---

## ¿Preguntas?

- **Arquitectura**: Ver [DOCKER_SETUP.md](DOCKER_SETUP.md)
- **Configuración**: Ver [ENV_GUIDE.md](ENV_GUIDE.md)
- **Base de Datos**: Ver [DATABASE_INIT.md](DATABASE_INIT.md)
- **Comandos Docker**: Ver sección "Referencias Rápidas" arriba

---


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

### 5. Prueba en el Emulador o en tu celular

- Para emulador Android: `http://10.0.2.2:8000`
- Para un dispositivo real en tu red Wi‑Fi: `http://192.168.224.123:8000`

## Configuración de Conectividad

### Emulador Android

```
URL: http://10.0.2.2:8000
```

### Dispositivo real (tu red)

```
URL: http://192.168.224.123:8000
```

### Dispositivo Físico

Si quieres usar un celular real:
1. Obtén la IP local de tu PC: `ipconfig` (busca IPv4)
2. Usa la IP de tu PC en la red Wi‑Fi, por ejemplo `192.168.224.123`.

Ejemplo:
```kotlin
webView.loadUrl("http://192.168.224.123:8000")
```

### Cambiar Puerto

Si quieres usar otro puerto (8001 o 8002):

**En `MainActivity.kt`**, cambia:
```kotlin
webView.loadUrl("http://192.168.224.123:8000")
```

por:

```kotlin
webView.loadUrl("http://192.168.224.123:8001")  // o 8002
```

## Troubleshooting

### La aplicación no carga

1. Verifica que Docker está en marcha: `docker ps`
2. Verifica que PHP está disponible: `http://localhost:8000` en tu navegador
3. En el emulador, abre Chrome y prueba: `http://10.0.2.2:8000`.
   En un celular real, prueba: `http://192.168.224.123:8000`.

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
