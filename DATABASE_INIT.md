# Inicialización Automática de Base de Datos

## ¿Cómo funciona?

Cuando levantes los contenedores en **modo local**, Docker ejecutará automáticamente el script SQL ubicado en `database/init.sql` para crear todas las tablas y datos iniciales.

### Flujo de Inicialización

```
docker-compose up -d
    ↓
MySQL inicia
    ↓
Docker monta ./database/init.sql en /docker-entrypoint-initdb.d/
    ↓
MySQL ejecuta automáticamente todos los scripts en /docker-entrypoint-initdb.d/
    ↓
Base de datos lista con todas las tablas y datos iniciales
```

## Datos que se crean automáticamente

### Tablas creadas:

1. **Independientes y Compartidas**
   - `TDepartamento` - Departamentos
   - `TMunicipio` - Municipios
   - `TDireccion` - Direcciones
   - `TEstadoPedido` - Estados de pedidos
   - `TRoles` - Roles de usuario
   - `TCategoria` - Categorías de productos

2. **Módulo Cliente**
   - `TUsuarioCliente` - Usuarios cliente
   - `TDireccionCliente` - Direcciones de cliente
   - `TCarrito` - Carrito de compras

3. **Módulo Tienda**
   - `TTiendas` - Tiendas
   - `TProductos` - Productos
   - `TTrabajador` - Trabajadores
   - `TTrabajadorTienda` - Asignación trabajador-tienda

4. **Pedidos y Transacciones**
   - `TPedido` - Pedidos
   - `TDetallePedido` - Detalle de pedidos
   - `TTransaccionPasarela` - Transacciones de pago

5. **Admin y PQRS**
   - `TUsuarioAdmin` - Usuarios administradores
   - `TTiendaAdmin` - Tiendas administración
   - `TPQRS` - PQRS (Peticiones, Quejas, Reclamos, Sugerencias)
   - `THiloPQRS` - Hilo de conversación PQRS

### Datos iniciales insertados:

**Estados de Pedido:**
- Pendiente, Confirmado, En Preparación, Enviado, Entregado, Cancelado

**Roles:**
- Administrador, Gerente de Tienda, Vendedor, Almacenista, Cliente

**Departamentos de Ejemplo:**
- Bogotá D.C., Cundinamarca, Antioquia

**Municipios de Ejemplo:**
- Bogotá, Soacha, Medellín

## Primero uso (Desarrollo Local)

```bash
# Levanta todos los contenedores
docker-compose up -d

# Verifica que MySQL esté listo
docker-compose logs mysql

# Accede a la base de datos
docker-compose exec mysql mysql -u mvp_user -p mvp_db
# Contraseña: mvp_password

# Listar tablas
SHOW TABLES;
```

## Si necesitas reiniciar la base de datos

```bash
# Detiene y elimina el volumen (ADVERTENCIA: borra todos los datos)
docker-compose down -v

# Levanta nuevamente (recreará la BD desde init.sql)
docker-compose up -d
```

## Para producción

**IMPORTANTE:** El script `init.sql` NO se ejecuta en producción por defecto.

Si deseas ejecutarlo en producción, necesitas:

1. Crear un script separado: `database/init.production.sql`
2. Montarlo manualmente en el contenedor
3. O ejecutarlo manualmente:

```bash
# Ejecutar el script en la BD de producción
docker-compose --env-file .env.production exec mysql mysql -u mvp_user -p mvp_db < database/init.sql
```

## Agregar más datos iniciales

Para agregar más datos de prueba, edita `database/init.sql` y agrega al final, antes de `SET FOREIGN_KEY_CHECKS = 1;`:

```sql
-- Insertar datos de prueba
INSERT INTO TDepartamento (cNombre, cCodigoDane) VALUES 
('Cauca', '19'),
('Valle del Cauca', '76');

INSERT INTO TTiendas (cNombreComercial, cRazonSocial, eEstadoTienda) VALUES 
('Mi Tienda', 'Mi Tienda S.A.S', 'Activa');
```

Luego reconstruye la BD:

```bash
docker-compose down -v
docker-compose up -d
```

## Estructura del archivo init.sql

El script está organizado en secciones:

1. **Configuración inicial** - Deshabilita claves foráneas
2. **Tablas independientes** - Se crean primero
3. **Módulos** - Se crean por módulo (Cliente, Tienda, etc.)
4. **Datos iniciales** - Se insertan al final
5. **Finalización** - Re-habilita claves foráneas

## Troubleshooting

### Las tablas no se crean

```bash
# Verifica los logs de MySQL
docker-compose logs mysql

# Verifica que el archivo existe
ls -la database/init.sql

# Verifica que el contenedor tiene permisos
docker-compose exec mysql ls -la /docker-entrypoint-initdb.d/
```

### Errores de sintaxis SQL

```bash
# Valida el SQL localmente
mysql -u root < database/init.sql

# Verifica las líneas que causan error en los logs
docker-compose logs mysql | grep -i error
```

### Necesito reimportar datos sin perder todo

```bash
# Entrate en el contenedor
docker-compose exec mysql bash

# Accede a MySQL
mysql -u root -p

# Selecciona la BD
USE mvp_db;

# Ejecuta solo parte del script
source /docker-entrypoint-initdb.d/init.sql;
```

## Notas importantes

- ✅ El script usa `CREATE TABLE IF NOT EXISTS` para no sobrescribir tablas existentes
- ✅ El script usa `INSERT IGNORE` para no insertar duplicados
- ✅ Las claves foráneas se habilitan solo al final
- ✅ Se soporta UTF-8 con collation unicode
- ✅ El volumen `mysql_data` persiste entre reinicios
- ⚠️ Si eliminas `-v` con `docker-compose down`, los datos se pierden
