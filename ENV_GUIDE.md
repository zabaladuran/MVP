# Guía de Configuración: Local vs Producción

## Estructura de Archivos .env

El proyecto tiene dos archivos de configuración:

### `.env.local` - Desarrollo Local
Usado por defecto cuando ejecutas `docker-compose up`. Contiene:
- Base de datos MySQL en contenedor local
- Puertos accesibles localmente (8000-8082)
- Debug habilitado
- Contraseñas simples para desarrollo

### `.env.production` - Producción
Usado cuando ejecutas con `--env-file .env.production`. Contiene:
- Base de datos en servidor remoto (db.production.com)
- Puertos HTTP/HTTPS estándar
- Debug deshabilitado
- SSL/TLS habilitado
- Contraseñas seguras (DEBE REEMPLAZARSE)

---

## ¿Qué debe tener `.env.local`?

### Archivo `.env.local` Completo

Aquí está el contenido que **debe tener** para desarrollo local:

```env
# ========================================
# ENTORNO
# ========================================
ENVIRONMENT=local
DEBUG=true

# ========================================
# BASE DE DATOS - MySQL en contenedor
# ========================================
MYSQL_ROOT_PASSWORD=root_password
MYSQL_PASSWORD=mvp_password
MYSQL_USER=mvp_user
DB_NAME=mvp_db
DB_HOST=mysql
DB_PORT=3306

# ========================================
# PUERTOS - PHP
# ========================================
PHP_PORT_1=8000
PHP_PORT_2=8001
PHP_PORT_3=8002

# ========================================
# PUERTOS - C# Desktop
# ========================================
CSHARP_PORT_1=5000
CSHARP_PORT_2=5001
CSHARP_PORT_3=5002

# ========================================
# PUERTOS - Android
# ========================================
ANDROID_ADB_PORT_1=5037
ANDROID_ADB_PORT_2=5038
ANDROID_ADB_PORT_3=5039
ANDROID_API_PORT_1=8003
ANDROID_API_PORT_2=8004
ANDROID_API_PORT_3=8005

# ========================================
# PUERTOS - PhpMyAdmin
# ========================================
PHPMYADMIN_PORT_1=8080
PHPMYADMIN_PORT_2=8081
PHPMYADMIN_PORT_3=8082

# ========================================
# URLs (localhost para desarrollo)
# ========================================
APP_URL=http://localhost:8000
API_URL=http://localhost:5000
ANDROID_API_URL=http://localhost:8003

# ========================================
# SSL/TLS (deshabilitado en desarrollo)
# ========================================
SSL_ENABLED=false
SSL_CERT_PATH=
SSL_KEY_PATH=

# ========================================
# SECRETOS (simples para desarrollo)
# ========================================
API_KEY=dev_api_key_12345
API_SECRET=dev_secret_67890
JWT_SECRET=dev_jwt_secret_local
```

### Explicación de Cada Variable

#### Entorno
| Variable | Valor (Local) | Descripción |
|----------|---------------|------------|
| `ENVIRONMENT` | `local` | Indica que es desarrollo local |
| `DEBUG` | `true` | Habilita modo debug (muestra errores) |

#### Base de Datos
| Variable | Valor (Local) | Descripción |
|----------|---------------|------------|
| `MYSQL_ROOT_PASSWORD` | `root_password` | Contraseña root de MySQL (simple para dev) |
| `MYSQL_PASSWORD` | `mvp_password` | Contraseña del usuario `mvp_user` |
| `MYSQL_USER` | `mvp_user` | Usuario de base de datos |
| `DB_NAME` | `mvp_db` | Nombre de la base de datos |
| `DB_HOST` | `mysql` | Nombre del contenedor MySQL en Docker |
| `DB_PORT` | `3306` | Puerto estándar de MySQL |

> **Nota:** `DB_HOST` es `mysql` porque en Docker Compose, los contenedores se pueden alcanzar por nombre de servicio.

#### Puertos
| Variable | Valor (Local) | Descripción |
|----------|---------------|------------|
| `PHP_PORT_1/2/3` | `8000`, `8001`, `8002` | 3 puertos alternos (por si alguno está ocupado) |
| `CSHARP_PORT_1/2/3` | `5000`, `5001`, `5002` | 3 puertos para C# |
| `ANDROID_ADB_PORT_1/2/3` | `5037`, `5038`, `5039` | Puertos para Android Debug Bridge |
| `ANDROID_API_PORT_1/2/3` | `8003`, `8004`, `8005` | Puertos para API Android |
| `PHPMYADMIN_PORT_1/2/3` | `8080`, `8081`, `8082` | Puertos para gestor de BD |

#### URLs
| Variable | Valor (Local) | Descripción |
|----------|---------------|------------|
| `APP_URL` | `http://localhost:8000` | URL de la app PHP |
| `API_URL` | `http://localhost:5000` | URL de la app C# |
| `ANDROID_API_URL` | `http://localhost:8003` | URL de la API Android |

#### Seguridad (Desarrollo)
| Variable | Valor (Local) | Descripción |
|----------|---------------|------------|
| `SSL_ENABLED` | `false` | SSL deshabilitado en dev |
| `SSL_CERT_PATH` | ` ` (vacío) | No aplica en local |
| `SSL_KEY_PATH` | ` ` (vacío) | No aplica en local |
| `API_KEY` | `dev_api_key_12345` | Clave simple para testing |
| `API_SECRET` | `dev_secret_67890` | Secreto simple para testing |
| `JWT_SECRET` | `dev_jwt_secret_local` | Token JWT para local |

### Valores que Puedes Cambiar en Local

Si algún puerto está ocupado, puedes cambiar fácilmente:

```env
# Si puerto 8000 está ocupado, usa:
PHP_PORT_1=9000

# Si puerto 5000 está ocupado, usa:
CSHARP_PORT_1=6000

# Si puerto 3306 está ocupado, usa:
DB_PORT=3307
```

---

## Diferencia: `.env.local` vs `.env.production`

| Variable | Local | Producción |
|----------|-------|-----------|
| `ENVIRONMENT` | `local` | `production` |
| `DEBUG` | `true` | `false` |
| `DB_HOST` | `mysql` (contenedor) | `db.tu-servidor.com` (servidor remoto) |
| `SSL_ENABLED` | `false` | `true` |
| `API_KEY` | `dev_api_key_12345` | `clave_segura_aleatoria_32_caracteres` |
| `PHP_PORT_1` | `8000` | `80` (HTTP) |
| `CSHARP_PORT_1` | `5000` | `443` (HTTPS) |

## Uso

### Desarrollo Local (por defecto)

```bash
# El script automáticamente usa .env.local
powershell -ExecutionPolicy Bypass -File switch-env.ps1
# O directamente:
docker-compose up -d

# Verifica que los contenedores estén corriendo
docker-compose ps

# Acceder a las aplicaciones:
# PHP:        http://localhost:8000  (o 8001, 8002)
# C#:         http://localhost:5000  (o 5001, 5002)
# Android:    http://localhost:5037  (o 5038, 5039)
# PhpMyAdmin: http://localhost:8080  (o 8081, 8082)

# Acceder a MySQL desde tu máquina:
docker-compose exec mysql mysql -u mvp_user -p mvp_db
# Contraseña: mvp_password
```

### Producción

```bash
# IMPORTANTE: Primero EDITA .env.production con tus valores reales
# (ver sección "Configurar Producción" abajo)

# Luego usa el script
powershell -ExecutionPolicy Bypass -File switch-env.ps1
# Selecciona opción 2 (Producción)

# O directamente:
docker-compose --env-file .env.production up -d

# Si usas docker stack deploy (Swarm):
docker stack deploy -c docker-compose.yml mvp --env-file .env.production
```

## Configurar Producción

### Archivo `.env.production` Completo

Usa este como base y **reemplaza todos los valores con los reales**:

```env
# ========================================
# ENTORNO
# ========================================
ENVIRONMENT=production
DEBUG=false

# ========================================
# BASE DE DATOS - Servidor remoto
# ========================================
MYSQL_ROOT_PASSWORD=contraseña_segura_aleatoria_32_caracteres_CAMBIAR
MYSQL_PASSWORD=contraseña_segura_aleatoria_32_caracteres_CAMBIAR
MYSQL_USER=mvp_prod_user
DB_NAME=mvp_db_produccion
DB_HOST=db.tu-servidor-produccion.com
DB_PORT=3306

# ========================================
# PUERTOS - HTTP/HTTPS estándar
# ========================================
PHP_PORT_1=80
PHP_PORT_2=8080
PHP_PORT_3=8081

# ========================================
# PUERTOS - C# Desktop
# ========================================
CSHARP_PORT_1=443
CSHARP_PORT_2=8443
CSHARP_PORT_3=8444

# ========================================
# PUERTOS - Android
# ========================================
ANDROID_ADB_PORT_1=5037
ANDROID_ADB_PORT_2=5038
ANDROID_ADB_PORT_3=5039
ANDROID_API_PORT_1=8003
ANDROID_API_PORT_2=8004
ANDROID_API_PORT_3=8005

# ========================================
# PUERTOS - PhpMyAdmin (no exponer en prod)
# ========================================
PHPMYADMIN_PORT_1=9000
PHPMYADMIN_PORT_2=9001
PHPMYADMIN_PORT_3=9002

# ========================================
# URLs - Dominio HTTPS real
# ========================================
APP_URL=https://tienda.tu-dominio.com
API_URL=https://api.tu-dominio.com
ANDROID_API_URL=https://api.tu-dominio.com

# ========================================
# SSL/TLS - Certificados reales
# ========================================
SSL_ENABLED=true
SSL_CERT_PATH=/etc/letsencrypt/live/tu-dominio.com/fullchain.pem
SSL_KEY_PATH=/etc/letsencrypt/live/tu-dominio.com/privkey.pem

# ========================================
# SECRETOS - Valores seguros aleatorios
# ========================================
API_KEY=generar_con_openssl_rand_base64_32
API_SECRET=generar_con_openssl_rand_base64_32
JWT_SECRET=generar_con_openssl_rand_base64_64
```

### Pasos para Configurar Producción

1. **Generar contraseñas seguras:**
   ```bash
   # Genera 3 contraseñas de 32 caracteres
   openssl rand -base64 32  # Copia en MYSQL_ROOT_PASSWORD
   openssl rand -base64 32  # Copia en MYSQL_PASSWORD
   openssl rand -base64 32  # Copia en API_KEY
   openssl rand -base64 32  # Copia en API_SECRET
   openssl rand -base64 64  # Copia en JWT_SECRET
   ```

2. **Reemplazar valores reales:**
   ```env
   # Edita estas líneas con TUS valores:
   MYSQL_ROOT_PASSWORD=tu_contraseña_segura_1
   MYSQL_PASSWORD=tu_contraseña_segura_2
   MYSQL_USER=tu_usuario_bd
   DB_NAME=nombre_bd_produccion
   DB_HOST=direccion_servidor_mysql
   
   APP_URL=https://tu-dominio-real.com
   API_URL=https://api.tu-dominio-real.com
   ANDROID_API_URL=https://api.tu-dominio-real.com
   
   API_KEY=tu_clave_segura_1
   API_SECRET=tu_clave_segura_2
   JWT_SECRET=tu_jwt_seguro
   ```

3. **Certificados SSL/TLS:**
   ```bash
   # Obtén certificados (ej. Let's Encrypt)
   # Luego actualiza:
   SSL_CERT_PATH=/ruta/a/certificado.pem
   SSL_KEY_PATH=/ruta/a/clave.pem
   ```

4. **Verificar la configuración:**
   ```bash
   # Verifica que no hay valores por defecto
   grep -E "cambiar|default|localhost|dev_" .env.production
   # No debe devolver nada
   ```

5. **Guardar en lugar seguro (NO en Git):**
   ```bash
   # Ya debe estar en .gitignore:
   echo ".env.production" >> .gitignore
   
   # Opcionalmente: guarda en gestor de secretos
   ```

### Cambios Clave vs Local

| Aspecto | Local | Producción |
|--------|-------|-----------|
| **Contraseña MySQL** | `mvp_password` (simple) | Contraseña segura aleatoria |
| **Host BD** | `mysql` (contenedor) | `db.servidor.com` (remoto) |
| **Debug** | `true` (muestra errores) | `false` (no expone info) |
| **Puertos PHP** | `8000`, `8001`, `8002` | `80`, `8080`, `8081` |
| **Puertos C#** | `5000`, `5001`, `5002` | `443`, `8443`, `8444` |
| **SSL** | Deshabilitado | Habilitado con certificado real |
| **URLs** | `http://localhost:XXXX` | `https://tu-dominio.com` |
| **Secretos** | Valores simples de test | Valores seguros aleatorios |
| **PhpMyAdmin expuesto** | Sí (puerto 8080 público) | No (puerto 9000 interno) |

## Variables de Entorno Disponibles

Para referencia rápida, aquí están todas las variables que puedes usar:

### Base de Datos
- `MYSQL_ROOT_PASSWORD` - Contraseña root de MySQL
- `MYSQL_PASSWORD` - Contraseña del usuario de BD
- `MYSQL_USER` - Usuario de la base de datos
- `DB_NAME` - Nombre de la base de datos
- `DB_HOST` - Host/servidor de MySQL (ej: `mysql` en local, `db.server.com` en prod)
- `DB_PORT` - Puerto de MySQL (default: 3306)

### Puertos (PHP, C#, Android, PhpMyAdmin)
- `PHP_PORT_1`, `PHP_PORT_2`, `PHP_PORT_3` - 3 puertos alternos para PHP
- `CSHARP_PORT_1`, `CSHARP_PORT_2`, `CSHARP_PORT_3` - 3 puertos alternos para C#
- `ANDROID_ADB_PORT_1/2/3` - Puertos Android Debug Bridge
- `ANDROID_API_PORT_1/2/3` - Puertos API Android
- `PHPMYADMIN_PORT_1/2/3` - 3 puertos alternos para PhpMyAdmin

### Entorno y Debug
- `ENVIRONMENT` - `"local"` o `"production"`
- `DEBUG` - `"true"` (local) o `"false"` (production)

### URLs
- `APP_URL` - URL de la aplicación PHP
- `API_URL` - URL de la aplicación C#
- `ANDROID_API_URL` - URL de la API Android

### Seguridad
- `SSL_ENABLED` - `"true"` o `"false"`
- `SSL_CERT_PATH` - Ruta al certificado SSL
- `SSL_KEY_PATH` - Ruta a la clave privada SSL
- `API_KEY` - Clave de API
- `API_SECRET` - Secreto de API
- `JWT_SECRET` - Secreto para tokens JWT

## Cómo las Aplicaciones Usan las Variables

### PHP

En `configLink.php`:
```php
define('DB_HOST', getenv('DB_HOST') ?: 'localhost');
define('DB_NAME', getenv('DB_NAME') ?: 'mvp_db');
define('DB_USER', getenv('DB_USER') ?: 'root');
define('DB_PASS', getenv('DB_PASSWORD') ?: '');
```

### C#

En `appsettings.json` o en el constructor de conexión:
```csharp
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? $"Server={Environment.GetEnvironmentVariable("DB_HOST")};Database={Environment.GetEnvironmentVariable("DB_NAME")}...";
```

### Android

En variables de configuración:
```java
String dbHost = System.getenv("DB_HOST") != null ? System.getenv("DB_HOST") : "localhost";
String dbPort = System.getenv("DB_PORT") != null ? System.getenv("DB_PORT") : "3306";
```

## Seguridad en Producción

**IMPORTANTE:** Antes de deployar a producción:

1. ✅ Genera contraseñas aleatorias seguras:
   ```bash
   # Linux/Mac
   openssl rand -base64 32
   ```

2. ✅ Nunca versiones `.env.production` en Git:
   ```bash
   echo ".env.production" >> .gitignore
   ```

3. ✅ Usa secretos de Docker/Kubernetes:
   ```bash
   docker secret create db_password /path/to/password
   ```

4. ✅ Habilita SSL/TLS con certificados válidos

5. ✅ Usa HTTPS en todas las conexiones

6. ✅ Implementa firewall y rate limiting

7. ✅ Realiza backups automáticos de la base de datos

## Monitoreo en Producción

```bash
# Ver logs en tiempo real
docker-compose --env-file .env.production logs -f

# Ver logs de un servicio específico
docker-compose --env-file .env.production logs -f php-app

# Ver estado de contenedores
docker-compose --env-file .env.production ps

# Ejecutar comando en un contenedor
docker-compose --env-file .env.production exec mysql mysqldump -u mvp_user -p mvp_db > backup.sql
```

---

## Troubleshooting - Problemas Comunes

### "No puedo conectarme a la BD"

**Verificar que las variables sean correctas:**
```bash
# Ver valores en .env.local
grep "DB_" .env.local

# Probar conexión directa
docker-compose exec mysql mysql -h mysql -u mvp_user -pmvp_password -e "SELECT 1"
```

**Soluciones:**
- ✅ En local: `DB_HOST` debe ser `mysql` (no `localhost`)
- ✅ En producción: `DB_HOST` debe ser la dirección real del servidor
- ✅ Verifica que `MYSQL_PASSWORD` y `DB_PASSWORD` sean iguales
- ✅ Verifica que `MYSQL_USER` y `DB_USER` sean iguales

### "Puerto ya está en uso"

**Si ves error: `bind: address already in use`**

```bash
# Opción 1: Cambiar en .env.local
PHP_PORT_1=9000  # En lugar de 8000
CSHARP_PORT_1=6000  # En lugar de 5000

# Opción 2: Matar el proceso que usa el puerto
# En Windows PowerShell:
Get-Process | Where-Object {$_.Port -eq 8000}

# En Linux/Mac:
lsof -i :8000
```

### ".env.local no se carga"

**Verificar que existe:**
```bash
# Ver si existe el archivo
ls -la .env.local

# Ver contenido
cat .env.local

# Debe estar en la raíz del proyecto (al lado de docker-compose.yml)
```

### "Valores no se aplican a los contenedores"

**Pasos para forzar recarga:**
```bash
# 1. Detener contenedores
docker-compose down

# 2. Eliminar volúmenes (cuidado: borra datos locales)
docker-compose down -v

# 3. Levantar nuevamente
docker-compose up -d

# 4. Verificar variables en contenedor
docker-compose exec php-app env | grep DB_
```

### "Acceso denegado a MySQL en producción"

**Verificar credenciales:**
```bash
# Ver contraseña en .env.production (no debe tener espacios)
grep "MYSQL_PASSWORD" .env.production

# Conexión de prueba (remota)
mysql -h db.servidor.com -u mvp_user -p mvp_db
# Ingresa contraseña cuando pida
```

**Cambiar contraseña (si está comprometida):**
```bash
# 1. Genera nueva contraseña
openssl rand -base64 32

# 2. Actualiza en .env.production
MYSQL_PASSWORD=nueva_contraseña_segura

# 3. Reinicia contenedores
docker-compose --env-file .env.production down
docker-compose --env-file .env.production up -d
```

### "SSL no funciona en producción"

**Verificar certificado:**
```bash
# Ver rutas en .env.production
grep "SSL_CERT\|SSL_KEY" .env.production

# Verificar que archivos existen en el servidor
ls -la /etc/letsencrypt/live/tu-dominio.com/

# Probar HTTPS
curl -I https://tu-dominio.com
```

### "Logs vacíos o no muestra errores"

**Habilitar debug:**
```bash
# En .env.local (no en production!)
DEBUG=true

# Reiniciar
docker-compose down && docker-compose up -d

# Ver logs con más detalle
docker-compose logs -f php-app
docker-compose logs -f mysql
```

---

## Checklist antes de Deploy a Producción

- [ ] `.env.production` está creado y completo
- [ ] Todas las contraseñas son únicas y seguras (openssl rand -base64 32)
- [ ] `DB_HOST` es la dirección real del servidor, NO `localhost` ni `mysql`
- [ ] `ENVIRONMENT=production` y `DEBUG=false`
- [ ] URLs tienen `https://` (no `http://`)
- [ ] SSL está habilitado (`SSL_ENABLED=true`)
- [ ] Certificados SSL existen (`SSL_CERT_PATH` y `SSL_KEY_PATH` son válidos)
- [ ] `.env.production` está en `.gitignore` (no commitear credenciales)
- [ ] Variables de secreto (JWT_SECRET, API_KEY, API_SECRET) son aleatorias
- [ ] PhpMyAdmin NO está expuesto en puertos públicos
- [ ] Has probado conectarte a MySQL con las credenciales de `.env.production`
- [ ] Backup automático de BD está configurado

## Rollback a Desarrollo

Si necesitas volver a desarrollo desde producción:

```bash
# Detén la versión de producción
docker-compose --env-file .env.production down

# Levanta con la configuración local
docker-compose up -d
```

## Troubleshooting

### Las variables de entorno no se aplican
```bash
# Verifica que uses el archivo correcto
docker-compose config --env-file .env.production | grep DB_HOST

# Reconstruye las imágenes si cambiaste la configuración
docker-compose --env-file .env.production build --no-cache
```

### Conexión a BD rechazada
```bash
# Verifica credenciales en el archivo .env
grep DB_ .env.production

# Reinicia el contenedor de MySQL
docker-compose --env-file .env.production restart mysql
```

### Puerto ya en uso
Los archivos .env tienen 3 puertos alternativos para cada servicio. Si uno está ocupado, intenta con el siguiente puerto en el archivo .env.
