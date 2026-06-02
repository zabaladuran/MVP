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

## Uso

### Desarrollo Local (por defecto)

```bash
# Levanta con .env.local automáticamente
docker-compose up -d

# Acceder a las aplicaciones:
# PHP:      http://localhost:8000
# C#:       http://localhost:5000
# Android:  http://localhost:5037
# PhpMyAdmin: http://localhost:8080
```

### Producción

```bash
# IMPORTANTE: Primero edita .env.production con tus valores reales
nano .env.production

# Luego levanta con .env.production
docker-compose --env-file .env.production up -d

# Si usas docker stack deploy (Swarm):
docker stack deploy -c docker-compose.yml mvp --env-file .env.production
```

## Configurar Producción

Antes de deployar a producción, edita `.env.production` y reemplaza:

1. **Base de Datos:**
   ```
   MYSQL_HOST=tu-servidor-db.com
   MYSQL_ROOT_PASSWORD=contraseña_segura_aleatoria
   MYSQL_PASSWORD=contraseña_segura_aleatoria
   ```

2. **Seguridad:**
   ```
   SSL_ENABLED=true
   SSL_CERT_PATH=/ruta/a/tu/certificado.pem
   SSL_KEY_PATH=/ruta/a/tu/clave.pem
   ```

3. **Dominio:**
   ```
   APP_URL=https://tu-dominio.com
   API_URL=https://api.tu-dominio.com
   ```

4. **Secretos:**
   ```
   API_KEY=tu_clave_api_segura
   API_SECRET=tu_secreto_seguro
   ```

## Variables de Entorno Disponibles

### Base de Datos
- `MYSQL_HOST` - Servidor MySQL (default: mysql)
- `MYSQL_PORT` - Puerto MySQL (default: 3306)
- `DB_NAME` - Nombre de la BD (default: mvp_db)
- `DB_USER` - Usuario de BD (default: mvp_user)
- `DB_PASSWORD` - Contraseña de BD

### Puertos
- `PHP_PORT_1/2/3` - Puertos para PHP
- `CSHARP_PORT_1/2/3` - Puertos para C#
- `ANDROID_ADB_PORT_1/2/3` - Puertos ADB
- `ANDROID_API_PORT_1/2/3` - Puertos API Android
- `PHPMYADMIN_PORT_1/2/3` - Puertos PhpMyAdmin

### Entorno
- `ENVIRONMENT` - "local" o "production"
- `DEBUG` - "true" o "false"

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
