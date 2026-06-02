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

### Opción 1: Scripts Automatizados (Recomendado)

#### En Windows (PowerShell)

```powershell
# 1. Abre PowerShell en la carpeta del proyecto
cd C:\Users\ronal\OneDrive\Escritorio\MVP

# 2. Ejecuta el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1

# 3. Selecciona opción "1" (Desarrollo Local)
# Espera 30-60 segundos a que inicie
```

#### En Linux/Mac (Bash)

```bash
# 1. Abre terminal
cd ~/Escritorio/MVP

# 2. Dale permisos al script
chmod +x switch-env.sh

# 3. Ejecuta
./switch-env.sh

# 4. Selecciona opción "1" (Desarrollo Local)
```

### Opción 2: Comando Directo

```bash
# Desarrollo Local
docker-compose up -d

# Producción
docker-compose --env-file .env.production up -d
```

---

## Scripts Disponibles

### `switch-env.ps1` (Windows)

Menú interactivo con opciones:
- `1` → Levanta Desarrollo Local
- `2` → Levanta Producción
- `3` → Ver configuración
- `4` → Ver logs en tiempo real
- `5` → Detener contenedores
- `6` → Salir

**Ejecutar:**
```powershell
powershell -ExecutionPolicy Bypass -File switch-env.ps1
```

### `switch-env.sh` (Linux/Mac)

Mismo menú que PowerShell.

**Ejecutar:**
```bash
chmod +x switch-env.sh
./switch-env.sh
```

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

| Documento | Descripción |
|-----------|------------|
| [DOCKER_SETUP.md](DOCKER_SETUP.md) | Arquitectura, puertos, networking |
| [ENV_GUIDE.md](ENV_GUIDE.md) | Configuración local vs producción |
| [DATABASE_INIT.md](DATABASE_INIT.md) | Inicialización automática de BD |

---

## Flujo Típico

```bash
# 1. Primer uso - Levanta todo
./switch-env.ps1  # Windows
# o
./switch-env.sh   # Linux/Mac

# 2. Selecciona "1" (Desarrollo Local)

# 3. Verifica que todo está corriendo
docker-compose ps

# 4. Ver logs si hay problemas
docker-compose logs -f

# 5. Cuando termines
docker-compose down
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

**MVP - Junio 2, 2026**
