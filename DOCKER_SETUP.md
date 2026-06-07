# Configuración Multi-Contenedor MVP

Este proyecto utiliza Docker Compose para ejecutar 2 aplicaciones simultáneamente con una base de datos compartida.

## Arquitectura

```
┌─────────────────────────────────────────────────────┐
│           Docker Network (mvp_network)              │
├─────────────────────────────────────────────────────┤
│                                                     │
│  ┌──────────────┐  ┌──────────────┐                 │
│  │  PHP App     │  │  C# App      │                 │
│  │  :8000       │  │  :5000       │                 │
│  └──────────────┘  └──────────────┘                 │
│         │                 │                        │
>>>>>>> 6378830 (aprendiendo android)
│         └─────────────────┼────────────────┘        │
│                           │                         │
│                    ┌──────────────┐                 │
│                    │   MySQL DB   │                 │
│                    │   :3306      │                 │
│                    │ mvp_db       │                 │
│                    └──────────────┘                 │
│                           │                         │
│                    ┌──────────────┐                 │
│                    │  PhpMyAdmin  │                 │
│                    │   :8080      │                 │
│                    └──────────────┘                 │
│                                                     │
└─────────────────────────────────────────────────────┘
```

## Requisitos

- Docker 20.10+
- Docker Compose 2.0+

## Inicio Rápido

### 1. Levantar todos los contenedores

#### Desarrollo Local (recomendado)
```bash
# Usa automáticamente .env.local
# También ejecuta el script init.sql para crear la BD automáticamente
docker-compose up -d
```

#### Producción
```bash
# Primero edita .env.production con tus valores reales
nano .env.production

# Luego levanta con .env.production
docker-compose --env-file .env.production up -d
```

Para más detalles sobre:
- **Archivos .env**: Ver [ENV_GUIDE.md](ENV_GUIDE.md)
- **Inicialización de BD**: Ver [DATABASE_INIT.md](DATABASE_INIT.md)

### 2. Verificar que todo está corriendo

```bash
docker-compose ps
```

Deberías ver 4 contenedores (mysql, php-app, csharp-app-blazer, phpmyadmin).

### 3. Acceder a las aplicaciones

Cada aplicación tiene 3 puertos disponibles (en caso de que alguno esté ocupado):

**PHP App:**
- http://localhost:8000
- http://localhost:8001
- http://localhost:8002

**C# Blazor App:**
- http://localhost:5010
- http://localhost:5011
- http://localhost:5012

**PhpMyAdmin:**
- http://localhost:8080
- http://localhost:8081
- http://localhost:8082
  - Usuario: `root`
  - Contraseña: `root_password`

## Detalles de Conexión a la Base de Datos

**⚠️ IMPORTANTE:** Las credenciales y puertos se configuran en los archivos `.env`:
- `.env.local` - Configuración de desarrollo local (por defecto)
- `.env.production` - Configuración de producción

Ver [ENV_GUIDE.md](ENV_GUIDE.md) para más detalles.

Todas las aplicaciones comparten la misma instancia de MySQL:

| Parámetro | Valor Local |
|-----------|-------|
| Host | `mysql` (nombre interno del contenedor) |
| Puerto | `3306` |
| Base de Datos | `mvp_db` |
| Usuario | `mvp_user` |
| Contraseña | `mvp_password` |
| Root Password | `root_password` |

### Para PHP

```php
$host = 'mysql';      // hostname dentro de Docker
$db = 'mvp_db';
$user = 'mvp_user';
$pass = 'mvp_password';

// O usa variables de entorno
$host = getenv('DB_HOST');
$db = getenv('DB_NAME');
$user = getenv('DB_USER');
$pass = getenv('DB_PASSWORD');
```

### Para C#

```csharp
string connectionString = "Server=mysql;Database=mvp_db;Uid=mvp_user;Pwd=mvp_password;";
```


## Sincronización de Datos

Como todas las aplicaciones acceden a la **misma instancia de MySQL**, los datos están automáticamente sincronizados:

- Los cambios en PHP se ven inmediatamente en C# y Android
- La base de datos se persiste en un volumen Docker (`mysql_data`)
- Los datos se mantienen incluso si los contenedores se detienen

### Volumen Persistente

```yaml
volumes:
  mysql_data:  # Almacena datos de MySQL
```

Los datos se guardan en `/var/lib/docker/volumes/mvp_mysql_data/_data`

## Comandos Útiles

### Ver logs de todos los contenedores
```bash
docker-compose logs -f
```

### Ver logs de un servicio específico
```bash
docker-compose logs -f php-app
```

### Entrar a un contenedor
```bash
docker-compose exec mysql bash
```

### Ejecutar comandos en MySQL desde línea de comandos
```bash
docker-compose exec mysql mysql -u mvp_user -p mvp_db
# Contraseña: mvp_password
```

### Detener todos los contenedores
```bash
docker-compose down
```

### Detener y eliminar volúmenes (CUIDADO: borra datos)
```bash
docker-compose down -v
```

### Reconstruir imagen de un servicio
```bash
docker-compose build php-app
docker-compose up -d
```

## Networking

Docker Compose crea automáticamente una red interna (`mvp_network`) donde los contenedores se comunican usando el nombre del servicio como hostname:

- `php-app` se conecta a `mysql:3306`
- `csharp-app-blazer` se conecta a `mysql:3306`

No necesitas usar direcciones IP, los nombres de los servicios se resuelven automáticamente.

## Troubleshooting

### MySQL tarda en iniciar

El contenedor MySQL puede tardar 10-15 segundos en estar listo. Los otros servicios esperan con `depends_on` y `healthcheck`.

### Conexión rechazada en PHP

Asegúrate de que `configLink.php` usa `getenv()` para obtener las variables de entorno:

```php
define('DB_HOST', getenv('DB_HOST') ?: 'localhost');
```

### Permisos en volúmenes

Si tienes problemas de permisos en Linux:

```bash
docker-compose exec mysql chown -R mysql:mysql /var/lib/mysql
```

## Desarrollo Local

Para cambiar código sin reconstruir las imágenes, monta tu carpeta local:

```yaml
volumes:
  - ./php-app:/var/www/html    # PHP
  - ./csharp-app:/app          # C#
```

Los cambios se reflejan inmediatamente en los contenedores en ejecución.

## Escalabilidad Futura

Si necesitas múltiples instancias de una app:

```bash
docker-compose up -d --scale php-app=2
```

Para esto necesitarías agregar un balanceador de carga (Nginx).
