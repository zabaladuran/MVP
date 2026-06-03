# MVP - Mercado Shop (Desktop, Web, Android)

Solución completa multi-plataforma para gestión de tiendas con 3 aplicaciones sincronizadas en una base de datos compartida.

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

## Acceder a las Aplicaciones

Una vez iniciado, accede a:

| Aplicación | URL | Puerto |
|-----------|-----|--------|
| **PHP Web** | http://localhost:8000 | 8000, 8001, 8002 |
| **C# Desktop** | http://localhost:5000 | 5000, 5001, 5002 |
| **Android** | http://localhost:5037 | 5037-5039, 8003-8005 |
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
# Android:    http://localhost:5037
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
- **Android API 30** - Aplicación móvil
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
└── android-app/                ← Aplicación Android
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
