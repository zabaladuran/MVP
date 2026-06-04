-- ======================================================
-- SCRIPT DE INICIALIZACIÓN DE BASE DE DATOS MVP
-- ======================================================
-- Este script se ejecuta automáticamente cuando el
-- contenedor de MySQL se inicia por primera vez
-- ======================================================

-- ======================================================
-- 1. CONFIGURACIÓN INICIAL
-- ======================================================
SET FOREIGN_KEY_CHECKS = 0;

-- ======================================================
-- 2. TABLAS INDEPENDIENTES Y COMPARTIDAS
-- ======================================================

CREATE TABLE IF NOT EXISTS TDepartamento (
  nDepartamentoID INT PRIMARY KEY AUTO_INCREMENT,
  cNombre VARCHAR(255),
  cCodigoDane VARCHAR(255)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TMunicipio (
  nMunicipioID INT PRIMARY KEY AUTO_INCREMENT,
  nDepartamentoFK INT,
  cNombre VARCHAR(255),
  cCodigoDane VARCHAR(255),
  FOREIGN KEY (nDepartamentoFK) REFERENCES TDepartamento(nDepartamentoID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TDireccion (
  nDireccionID INT PRIMARY KEY AUTO_INCREMENT,
  cNomenclatura VARCHAR(255),
  cBarrio VARCHAR(255),
  cNotasAdicionales VARCHAR(255),
  cCodigoPostal VARCHAR(255),
  nMunicipioFK INT,
  FOREIGN KEY (nMunicipioFK) REFERENCES TMunicipio(nMunicipioID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TEstadoPedido (
  nEstadoPedidoID INT PRIMARY KEY AUTO_INCREMENT,
  cNombreEstado VARCHAR(255)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TRoles (
  nRolID INT PRIMARY KEY AUTO_INCREMENT,
  cNombre VARCHAR(255),
  cDescripcion VARCHAR(255)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TCategoria (
  nCategoriaID INT PRIMARY KEY AUTO_INCREMENT,
  cNombreCategoria VARCHAR(255),
  nCategoriaPadreFK INT,
  bEstado BOOLEAN,
  FOREIGN KEY (nCategoriaPadreFK) REFERENCES TCategoria(nCategoriaID)
) ENGINE=InnoDB;

-- ======================================================
-- 3. MÓDULO CLIENTE
-- ======================================================

CREATE TABLE IF NOT EXISTS TUsuarioCliente (
  nUsuarioClienteID INT PRIMARY KEY AUTO_INCREMENT,
  cNombre VARCHAR(255),
  cApellido VARCHAR(255),
  cDocumento VARCHAR(255),
  cContrasena VARCHAR(255),
  cCorreo VARCHAR(255),
  cTelefono VARCHAR(255),
  nDireccionFK INT,
  FOREIGN KEY (nDireccionFK) REFERENCES TDireccion(nDireccionID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TDireccionCliente (
  nDireccionClienteID INT PRIMARY KEY AUTO_INCREMENT,
  nClienteFK INT,
  nDireccionFK INT,
  cEtiqueta VARCHAR(255),
  cNombreRecibidor VARCHAR(255),
  cTelefonoRecibidor VARCHAR(255),
  FOREIGN KEY (nClienteFK) REFERENCES TUsuarioCliente(nUsuarioClienteID),
  FOREIGN KEY (nDireccionFK) REFERENCES TDireccion(nDireccionID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TCarrito (
  nCarritoID INT PRIMARY KEY AUTO_INCREMENT,
  nUsuarioClienteFK INT,
  eEstado VARCHAR(255),
  dFechaUltActualizacion TIMESTAMP,
  dFechaExpiracion TIMESTAMP,
  FOREIGN KEY (nUsuarioClienteFK) REFERENCES TUsuarioCliente(nUsuarioClienteID)
) ENGINE=InnoDB;

-- ======================================================
-- 4. MÓDULO TIENDA
-- ======================================================

CREATE TABLE IF NOT EXISTS TTiendas (
  nTiendaID INT PRIMARY KEY AUTO_INCREMENT,
  cNombreComercial VARCHAR(255),
  tDescripcion TEXT,
  cUrlLogo VARCHAR(255),
  cCorreoAtencion VARCHAR(255),
  cTelefonoAtencion VARCHAR(255),
  cRazonSocial VARCHAR(255),
  nDireccionFK INT,
  cCodigoPostal VARCHAR(255),
  eEstadoTienda ENUM('Activa', 'Inactiva', 'Suspendida', 'Pendiente'),
  nPlanFK INT,
  dFechaVencimientoSuscripcion TIMESTAMP,
  FOREIGN KEY (nDireccionFK) REFERENCES TDireccion(nDireccionID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TProductos (
  nProductoID INT PRIMARY KEY AUTO_INCREMENT,
  nTiendaFK INT,
  cDescripcionCorta VARCHAR(255),
  cDescripcionLarga TEXT,
  cUrlImagenPrincipal VARCHAR(255),
  nCategoriaFK INT,
  jEspecificaciones JSON,
  nPrecioUnitario DECIMAL(19,4),
  nCantidadStock INT,
  FOREIGN KEY (nTiendaFK) REFERENCES TTiendas(nTiendaID),
  FOREIGN KEY (nCategoriaFK) REFERENCES TCategoria(nCategoriaID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TTrabajador (
  nTrabajadorID INT PRIMARY KEY AUTO_INCREMENT,
  cIdentificacion VARCHAR(255),
  cNombre VARCHAR(255),
  cApellido VARCHAR(255),
  cPassword VARCHAR(255),
  cTelefono VARCHAR(255),
  nRolFK INT,
  FOREIGN KEY (nRolFK) REFERENCES TRoles(nRolID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TTrabajadorTienda (
  nID INT PRIMARY KEY AUTO_INCREMENT,
  nTiendaFK INT,
  nTrabajadorFK INT,
  FOREIGN KEY (nTiendaFK) REFERENCES TTiendas(nTiendaID),
  FOREIGN KEY (nTrabajadorFK) REFERENCES TTrabajador(nTrabajadorID)
) ENGINE=InnoDB;

-- ======================================================
-- 5. PEDIDOS Y TRANSACCIONES
-- ======================================================

CREATE TABLE IF NOT EXISTS TPedido (
  nPedidoID INT PRIMARY KEY AUTO_INCREMENT,
  nClienteFK INT,
  nDireccionClienteFK INT,
  cNumeroComprobante VARCHAR(255),
  nSubtotal DECIMAL(19,4),
  nCostoEnvio DECIMAL(19,4),
  nTotal DECIMAL(19,4),
  nTransaccionPasarelaFK INT,
  nEstadoPedidoFK INT,
  dFechaActualizacion TIMESTAMP,
  FOREIGN KEY (nClienteFK) REFERENCES TUsuarioCliente(nUsuarioClienteID),
  FOREIGN KEY (nDireccionClienteFK) REFERENCES TDireccionCliente(nDireccionClienteID),
  FOREIGN KEY (nEstadoPedidoFK) REFERENCES TEstadoPedido(nEstadoPedidoID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TDetallePedido (
  nDetallePedidoID INT PRIMARY KEY AUTO_INCREMENT,
  nPedidoFK INT,
  nProductoFK INT,
  cNombreProducto VARCHAR(255),
  nPrecioCompra DECIMAL(19,4),
  nCantidad INT,
  nSubtotal DECIMAL(19,4),
  FOREIGN KEY (nPedidoFK) REFERENCES TPedido(nPedidoID),
  FOREIGN KEY (nProductoFK) REFERENCES TProductos(nProductoID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TTransaccionPasarela (
  nTransaccionID INT PRIMARY KEY AUTO_INCREMENT,
  nPedidoFK INT,
  cNombrePasarela VARCHAR(255),
  cIdTransaccionExterna VARCHAR(255),
  cMetodoPago VARCHAR(255),
  eFranquicia ENUM('Visa', 'Mastercard', 'AMEX'),
  cUltimos4Digitos VARCHAR(4),
  nCuotas INT,
  nValorTransaccion DECIMAL(19,4),
  cEstadoTransaccion VARCHAR(255),
  cCodigoAprobacionBanco VARCHAR(255),
  dFechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  dFechaActualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  jRawResponse JSON,
  FOREIGN KEY (nPedidoFK) REFERENCES TPedido(nPedidoID)
) ENGINE=InnoDB;

-- ======================================================
-- 6. MÓDULO ADMIN Y PQRS
-- ======================================================

CREATE TABLE IF NOT EXISTS TUsuarioAdmin (
  nIdUsuario INT PRIMARY KEY AUTO_INCREMENT,
  cNombre VARCHAR(255),
  cApellido VARCHAR(255),
  cCorreo VARCHAR(255),
  cPassword VARCHAR(255),
  eEstado ENUM('Activo', 'Inactivo', 'Bloqueado'),
  dCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TTiendaAdmin (
  nIdTienda INT PRIMARY KEY AUTO_INCREMENT,
  cNombre VARCHAR(255),
  cDireccion VARCHAR(255),
  cTelefono VARCHAR(255),
  eEstado ENUM('Activa', 'Inactiva', 'Suspendida', 'Pendiente')
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS TPQRS (
  nPQRSID INT PRIMARY KEY AUTO_INCREMENT,
  nCreadorFK INT,
  cTipoCreador ENUM('Usuario', 'Tienda', 'Admin'),
  dFechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  eTipo ENUM('Peticion', 'Queja', 'Reclamo', 'Sugerencia'),
  eEstado ENUM('Activo', 'Resuelto', 'Pendiente'),
  cNumeroTicket VARCHAR(255),
  cAsunto VARCHAR(255),
  nPedidoFK INT,
  nTiendaFK INT,
  FOREIGN KEY (nPedidoFK) REFERENCES TPedido(nPedidoID),
  FOREIGN KEY (nTiendaFK) REFERENCES TTiendaAdmin(nIdTienda)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS THiloPQRS (
  nHiloPQRSID INT PRIMARY KEY AUTO_INCREMENT,
  nPQRSFK INT,
  cMensaje TEXT,
  dFechaEnvio TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  nActorFK INT,
  cTipoActor ENUM('Usuario', 'Tienda', 'Admin'),
  bEsMensajeInterno BOOLEAN,
  cEvidencia VARCHAR(255),
  FOREIGN KEY (nPQRSFK) REFERENCES TPQRS(nPQRSID)
) ENGINE=InnoDB;

-- ======================================================
-- 7. DATOS INICIALES
-- ======================================================

-- Insertar estados de pedido
INSERT IGNORE INTO TEstadoPedido (nEstadoPedidoID, cNombreEstado) VALUES 
(1, 'Pendiente'),
(2, 'Confirmado'),
(3, 'En Preparación'),
(4, 'Enviado'),
(5, 'Entregado'),
(6, 'Cancelado');

-- Insertar roles
INSERT IGNORE INTO TRoles (nRolID, cNombre, cDescripcion) VALUES 
(1, 'Administrador', 'Acceso completo al sistema'),
(2, 'Gerente de Tienda', 'Gestión de la tienda y productos'),
(3, 'Vendedor', 'Atención a clientes y gestión de pedidos'),
(4, 'Almacenista', 'Gestión de inventario'),
(5, 'Cliente', 'Usuario final del sistema');

-- Insertar departamentos
INSERT IGNORE INTO TDepartamento (nDepartamentoID, cNombre, cCodigoDane) VALUES 
(1, 'Bogotá D.C.', '11'),
(2, 'Cundinamarca', '25'),
(3, 'Antioquia', '05'),
(4, 'Valle del Cauca', '76'),
(5, 'Atlántico', '08'),
(6, 'Santander', '68'),
(7, 'Boyacá', '15'),
(8, 'Magdalena', '47');

-- Insertar municipios
INSERT IGNORE INTO TMunicipio (nMunicipioID, nDepartamentoFK, cNombre, cCodigoDane) VALUES 
(1, 1, 'Bogotá', '11001'),
(2, 2, 'Soacha', '25754'),
(3, 3, 'Medellín', '05001'),
(4, 4, 'Cali', '76001'),
(5, 5, 'Barranquilla', '08001'),
(6, 6, 'Bucaramanga', '68001'),
(7, 7, 'Tunja', '15001'),
(8, 8, 'Santa Marta', '47001'),
(9, 2, 'Chía', '25200'),
(10, 2, 'Cajicá', '25134'),
(11, 3, 'Envigado', '05266'),
(12, 4, 'Palmira', '76520');

-- ======================================================
-- 8. DATOS DE PRUEBA
-- ======================================================

-- Categorías
INSERT IGNORE INTO TCategoria (nCategoriaID, cNombreCategoria, nCategoriaPadreFK, bEstado) VALUES
(1, 'Electrónica', NULL, TRUE),
(2, 'Ropa y Accesorios', NULL, TRUE),
(3, 'Hogar', NULL, TRUE),
(4, 'Deportes', NULL, TRUE),
(5, 'Celulares', 1, TRUE),
(6, 'Computadores', 1, TRUE),
(7, 'Audífonos', 1, TRUE),
(8, 'Cámaras', 1, TRUE),
(9, 'Smartwatches', 1, TRUE),
(10, 'Televisores', 1, TRUE),
(11, 'Videojuegos', 1, TRUE),
(12, 'Camisetas', 2, TRUE),
(13, 'Pantalones', 2, TRUE),
(14, 'Zapatos', 2, TRUE),
(15, 'Chaquetas', 2, TRUE),
(16, 'Accesorios', 2, TRUE),
(17, 'Muebles', 3, TRUE),
(18, 'Cocina', 3, TRUE),
(19, 'Decoración', 3, TRUE),
(20, 'Fitness', 4, TRUE),
(21, 'Ciclismo', 4, TRUE),
(22, 'Camping', 4, TRUE);

-- Direcciones
INSERT IGNORE INTO TDireccion (nDireccionID, cNomenclatura, cBarrio, cNotasAdicionales, cCodigoPostal, nMunicipioFK) VALUES
(1, 'Carrera 15 # 88-12', 'Chapinero', 'Torre B apto 301', '110111', 1),
(2, 'Calle 26 # 69-76', 'Fontibón', 'Oficina 402', '110931', 1),
(3, 'Carrera 43A # 1-50', 'El Poblado', 'Local 12', '050021', 3),
(4, 'Calle 10 # 3-20', 'Centro', 'Casa blanca portón negro', '250051', 2),
(5, 'Avenida 68 # 20-10', 'Barrios Unidos', 'Conjunto Cerrado Las Palmas', '111211', 1),
(6, 'Calle 100 # 15-30', 'Usaquén', 'Edificio empresarial piso 8', '110111', 1),
(7, 'Carrera 7 # 72-41', 'Chapinero', '', '110221', 1),
(8, 'Calle 5 # 15-80', 'San Fernando', 'Casa de dos pisos', '760001', 4),
(9, 'Carrera 58 # 75-20', 'Norte', 'Conjunto residencial Los Pinos', '080011', 5),
(10, 'Calle 45 # 28-60', 'Cabecera', 'Edificio Santander apto 1502', '680011', 6),
(11, 'Carrera 11 # 100-50', 'Santa Bárbara', 'Oficina 301', '110111', 1),
(12, 'Avenida 1 # 10-30', 'Centro', 'Local comercial esquinero', '150001', 7),
(13, 'Calle 22 # 4-80', 'Centro Histórico', 'Casa colonial restaurada', '470001', 8),
(14, 'Carrera 7 # 120-30', 'Usaquén', 'Casa con parqueadero', '110121', 1),
(15, 'Calle 80 # 65-20', 'Engativá', 'Conjunto Pradera Norte', '111071', 1);

-- Usuarios clientes
INSERT IGNORE INTO TUsuarioCliente (nUsuarioClienteID, cNombre, cApellido, cDocumento, cContrasena, cCorreo, cTelefono, nDireccionFK) VALUES
(1, 'Carlos', 'Martínez', '1234567890', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'carlos@email.com', '3001234567', 1),
(2, 'María', 'González', '9876543210', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'maria@email.com', '3107654321', 4),
(3, 'Pedro', 'Ramírez', '4567891230', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'pedro@email.com', '3209876543', 7),
(4, 'Ana', 'Torres', '1112233445', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'ana.torres@email.com', '3015544332', 8),
(5, 'Luis', 'Herrera', '9988776655', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'luis.herrera@email.com', '3156677889', 9),
(6, 'Camila', 'Rojas', '5544332211', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'camila.rojas@email.com', '3009988776', 10),
(7, 'Andrés', 'Mendoza', '1234509876', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'andres.mendoza@email.com', '3104455667', 13),
(8, 'Valentina', 'Ospina', '6677889900', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'valentina.ospina@email.com', '3201122334', 14),
(9, 'Felipe', 'Castro', '4433221100', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'felipe.castro@email.com', '3012233445', 11);

-- Direcciones de clientes
INSERT IGNORE INTO TDireccionCliente (nDireccionClienteID, nClienteFK, nDireccionFK, cEtiqueta, cNombreRecibidor, cTelefonoRecibidor) VALUES
(1, 1, 1, 'Casa', 'Carlos Martínez', '3001234567'),
(2, 1, 5, 'Trabajo', 'Carlos Martínez', '3001234567'),
(3, 2, 4, 'Casa', 'María González', '3107654321'),
(4, 3, 7, 'Apartamento', 'Pedro Ramírez', '3209876543'),
(5, 4, 8, 'Casa', 'Ana Torres', '3015544332'),
(6, 5, 9, 'Casa', 'Luis Herrera', '3156677889'),
(7, 6, 10, 'Oficina', 'Camila Rojas', '3009988776'),
(8, 7, 13, 'Casa', 'Andrés Mendoza', '3104455667'),
(9, 8, 14, 'Casa', 'Valentina Ospina', '3201122334'),
(10, 9, 11, 'Trabajo', 'Felipe Castro', '3012233445'),
(11, 1, 14, 'Finca', 'Carlos Martínez', '3001234567'),
(12, 4, 15, 'Apartamento', 'Ana Torres', '3015544332');

-- Carritos
INSERT IGNORE INTO TCarrito (nCarritoID, nUsuarioClienteFK, eEstado, dFechaUltActualizacion, dFechaExpiracion) VALUES
(1, 1, 'Activo', NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY)),
(2, 2, 'Activo', NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY)),
(3, 4, 'Activo', NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY)),
(4, 5, 'Activo', NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY)),
(5, 8, 'Activo', NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY));

-- Tiendas
INSERT IGNORE INTO TTiendas (nTiendaID, cNombreComercial, tDescripcion, cUrlLogo, cCorreoAtencion, cTelefonoAtencion, cRazonSocial, nDireccionFK, cCodigoPostal, eEstadoTienda, nPlanFK, dFechaVencimientoSuscripcion) VALUES
(1, 'TechZone Colombia', 'Tienda especializada en tecnología y electrónica', '/logos/techzone.png', 'info@techzone.co', '6015550101', 'TechZone SAS', 2, '110931', 'Activa', 1, DATE_ADD(NOW(), INTERVAL 1 YEAR)),
(2, 'ModaExpress', 'Ropa y accesorios para toda la familia', '/logos/modaexpress.png', 'servicio@modaexpress.co', '6015550202', 'ModaExpress LTDA', 3, '050021', 'Activa', 1, DATE_ADD(NOW(), INTERVAL 6 MONTH)),
(3, 'HogarPerfecto', 'Todo para tu hogar', '/logos/hogarperfecto.png', 'ventas@hogarperfecto.co', '6015550303', 'HogarPerfecto SA', 6, '110111', 'Pendiente', 2, DATE_ADD(NOW(), INTERVAL 3 MONTH)),
(4, 'Deportes Total', 'Artículos deportivos y ropa para entrenamiento', '/logos/deportestotal.png', 'contacto@deportestotal.co', '6024440101', 'Deportes Total SAS', 12, '150001', 'Activa', 1, DATE_ADD(NOW(), INTERVAL 9 MONTH)),
(5, 'GamerZone', 'Todo para gaming: consolas, PC y accesorios', '/logos/gamerzone.png', 'soporte@gamerzone.co', '6013330202', 'GamerZone Colombia SAS', 11, '110111', 'Activa', 1, DATE_ADD(NOW(), INTERVAL 1 YEAR)),
(6, 'Cocina & Sabor', 'Utensilios y electrodomésticos de cocina', '/logos/cocinasabor.png', 'pedidos@cocinasabor.co', '6052220303', 'Cocina Sabor LTDA', 8, '760001', 'Inactiva', 2, DATE_ADD(NOW(), INTERVAL 2 MONTH));

-- Productos
INSERT IGNORE INTO TProductos (nProductoID, nTiendaFK, cDescripcionCorta, cDescripcionLarga, cUrlImagenPrincipal, nCategoriaFK, jEspecificaciones, nPrecioUnitario, nCantidadStock) VALUES
-- TechZone (tienda 1)
(1, 1, 'iPhone 15 Pro 256GB', 'Smartphone Apple iPhone 15 Pro con chip A17 Pro, pantalla Super Retina XDR de 6.1", cámara triple 48MP', '/productos/iphone15pro.jpg', 5, '{"color": "Titanio Natural", "almacenamiento": "256GB", "ram": "8GB", "pantalla": "6.1 pulgadas"}', 5999000.0000, 25),
(2, 1, 'MacBook Air M3 15"', 'Laptop Apple MacBook Air con chip M3, 16GB RAM, 512GB SSD, pantalla Liquid Retina 15.3"', '/productos/macbookair-m3.jpg', 6, '{"procesador": "Apple M3", "ram": "16GB", "almacenamiento": "512GB SSD", "pantalla": "15.3 pulgadas"}', 8499000.0000, 15),
(3, 1, 'Audífonos Sony WH-1000XM5', 'Audífonos inalámbricos con cancelación de ruido activa, 30h de batería', '/productos/sony-xm5.jpg', 7, '{"tipo": "Over-ear", "conectividad": "Bluetooth 5.2", "bateria": "30 horas", "cancelacion_ruido": "Si"}', 899000.0000, 50),
(8, 1, 'Samsung Galaxy S24 Ultra', 'Smartphone Samsung Galaxy S24 Ultra con Snapdragon 8 Gen 3, pantalla Dynamic AMOLED 6.8", S Pen incluido', '/productos/s24-ultra.jpg', 5, '{"color": "Negro Titanio", "almacenamiento": "512GB", "ram": "12GB", "pantalla": "6.8 pulgadas"}', 6499000.0000, 30),
(9, 1, 'iPad Pro M4 11"', 'Tablet Apple iPad Pro con chip M4, pantalla Ultra Retina XDR 11", 256GB', '/productos/ipad-pro-m4.jpg', 6, '{"procesador": "Apple M4", "almacenamiento": "256GB", "pantalla": "11 pulgadas", "conectividad": "WiFi + 5G"}', 5499000.0000, 20),
(10, 1, 'Apple Watch Ultra 2', 'Reloj inteligente Apple Watch Ultra 2 con GPS + Cellular, pantalla 49mm, resistencia extrema', '/productos/watch-ultra2.jpg', 9, '{"talla": "49mm", "conectividad": "GPS + Cellular", "bateria": "36 horas", "resistencia": "100 metros"}', 3499000.0000, 18),
(11, 1, 'Cámara Sony A7 IV', 'Cámara mirrorless Sony Alpha 7 IV con sensor full-frame 33MP, grabación 4K 60fps', '/productos/sony-a7iv.jpg', 8, '{"sensor": "Full-frame 33MP", "video": "4K 60fps", "estabilizacion": "5 ejes IBIS"}', 8499000.0000, 8),
(12, 1, 'TV LG OLED 65" C4', 'Televisor LG OLED evo 65" 4K con procesador α9 Gen7, Dolby Vision, webOS 24', '/productos/lg-oled-65.jpg', 10, '{"tamaño": "65 pulgadas", "resolucion": "4K UHD", "tipo": "OLED evo", "smart": "webOS 24"}', 6999000.0000, 12),
(13, 1, 'Nintendo Switch OLED', 'Consola Nintendo Switch con pantalla OLED 7", dock con puerto LAN, almacenamiento 64GB', '/productos/switch-oled.jpg', 11, '{"pantalla": "OLED 7 pulgadas", "almacenamiento": "64GB", "bateria": "4.5-9 horas"}', 1499000.0000, 40),

-- ModaExpress (tienda 2)
(4, 2, 'Camiseta Algodón Premium', 'Camiseta manga corta 100% algodón orgánico, corte regular, disponible en 5 colores', '/productos/camiseta-algodon.jpg', 12, '{"material": "Algodón orgánico", "tallas": "S/M/L/XL", "colores": "Negro, Blanco, Azul, Rojo, Verde"}', 79900.0000, 200),
(5, 2, 'Zapatillas Deportivas AirMax', 'Zapatillas running con amortiguación AirMax, suela antideslizante, diseño transpirable', '/productos/zapatillas-airmax.jpg', 14, '{"talla": "39-44", "material": "Malla y sintético", "tipo": "Running", "colores": "Negro/Gris"}', 249900.0000, 80),
(14, 2, 'Jeans Clásico 5 Bolsillos', 'Jeans de corte recto en denim premium, elástico, costuras reforzadas', '/productos/jeans-clasico.jpg', 13, '{"material": "Denim elástico", "tallas": "28-40", "color": "Azul oscuro", "tipo": "Recto"}', 139900.0000, 150),
(15, 2, 'Chaqueta Impermeable Travel', 'Chaqueta cortavientos impermeable con capucha desmontable, múltiples bolsillos', '/productos/chaqueta-travel.jpg', 15, '{"material": "Poliéster impermeable", "tallas": "S/M/L/XL", "colores": "Negro, Verde Oliva"}', 299900.0000, 60),
(16, 2, 'Reloj Casio G-Shock GA-2100', 'Reloj digital-analógico resistente a golpes, 200m de resistencia al agua', '/productos/gshock-ga2100.jpg', 16, '{"tipo": "Digital/Analógico", "resistencia": "200 metros", "pila": "3 años"}', 429900.0000, 45),
(17, 2, 'Bolso Mochila Urbana 30L', 'Mochila urbana impermeable con compartimiento para laptop 15.6", puerto USB', '/productos/mochila-urbana.jpg', 16, '{"capacidad": "30L", "material": "Poliéster impermeable", "laptop": "15.6 pulgadas"}', 189900.0000, 90),
(18, 2, 'Vestido Floral Verano', 'Vestido midi con estampado floral, tela ligera y fresca, corte en A', '/productos/vestido-floral.jpg', 12, '{"material": "Viscosa", "tallas": "S/M/L", "colores": "Azul Floral, Rojo Floral"}', 159900.0000, 75),

-- HogarPerfecto (tienda 3)
(6, 3, 'Sofá 3 Puestos Milano', 'Sofá tapizado en tela chenille, cojines de espuma de alta densidad, estructura de madera', '/productos/sofa-milano.jpg', 17, '{"material": "Chenille", "capacidad": "3 personas", "color": "Gris oscuro", "incluye": "2 cojines decorativos"}', 1899000.0000, 10),
(19, 3, 'Juego de Sábanas 300 Hilos', 'Sábanas de algodón egipcio 300 hilos, incluye 2 fundas y 2 sábanas', '/productos/sabanas-300.jpg', 18, '{"material": "Algodón egipcio", "hilos": "300", "tamaño": "Doble, Queen, King", "colores": "Blanco, Beige"}', 249900.0000, 100),
(20, 3, 'Lámpara Colgante Nórdica', 'Lámpara colgante de diseño nórdico en metal negro mate, pantalla cónica', '/productos/lampara-nordica.jpg', 19, '{"material": "Metal", "color": "Negro mate", "tipo": "Colgante", "bombilla": "E27 (no incluye)"}', 189900.0000, 40),
(21, 3, 'Set 6 Tazas Porcelana', 'Juego de 6 tazas de porcelana blanca con platos, aptas para microondas y lavavajillas', '/productos/tazas-porcelana.jpg', 18, '{"material": "Porcelana", "cantidad": "6 tazas + 6 platos", "capacidad": "300ml", "apto": "Microondas y lavavajillas"}', 129900.0000, 120),
(22, 3, 'Mesa Comedor 6 Puestos', 'Mesa de comedor rectangular de madera maciza, acabado natural, 180x90cm', '/productos/mesa-comedor.jpg', 17, '{"material": "Madera maciza de pino", "dimensiones": "180x90x75cm", "capacidad": "6 personas", "color": "Natural"}', 1499000.0000, 8),

-- Deportes Total (tienda 4)
(7, 4, 'Set Pesas 20kg', 'Set de pesas con mancuernas ajustables, discos de hierro recubiertos en neopreno', '/productos/set-pesas.jpg', 20, '{"peso_total": "20kg", "material": "Hierro recubierto neopreno", "incluye": "2 mancuernas + 4 discos"}', 149900.0000, 35),
(23, 4, 'Bicicleta Montaña 29"', 'Bicicleta MTW 29" con 21 velocidades, frenos de disco mecánicos, suspensión delantera', '/productos/bici-mtb-29.jpg', 21, '{"rodado": "29 pulgadas", "velocidades": "21", "frenos": "Disco mecánico", "suspension": "Delantera"}', 1499000.0000, 12),
(24, 4, 'Balón Fútbol Profesional', 'Balón de fútbol talla 5, cuero sintético, costura termosellada, avalado por FIFA', '/productos/balon-futbol.jpg', 20, '{"talla": "5", "material": "Cuero sintético", "costura": "Termosellada"}', 159900.0000, 200),
(25, 4, 'Tenis de Campo', 'Raqueta de tenis de grafito, peso 300g, encordado de fábrica, incluye funda', '/productos/raqueta-tenis.jpg', 20, '{"material": "Grafito", "peso": "300g", "incluye": "Funda protectora"}', 449900.0000, 25),
(26, 4, 'Carpa Camping 4 Personas', 'Carpa impermeable para 4 personas, doble techo, armado rápido, incluye bolsa de transporte', '/productos/carpa-camping.jpg', 22, '{"capacidad": "4 personas", "impermeable": "Si", "armado": "Rápido 2 minutos", "peso": "4.5kg"}', 699900.0000, 18),
(27, 4, 'Guantes Boxeo Profesional', 'Guantes de boxeo cuero sintético, espuma de alta densidad, muñequera ancha', '/productos/guantes-boxeo.jpg', 20, '{"material": "Cuero sintético", "peso": "12oz / 14oz / 16oz", "colores": "Rojo, Azul, Negro"}', 189900.0000, 65),

-- GamerZone (tienda 5)
(28, 5, 'PlayStation 5 Slim Digital', 'Consola PlayStation 5 Slim edición digital, 825GB SSD, mando DualSense incluido', '/productos/ps5-slim.jpg', 11, '{"almacenamiento": "825GB SSD", "tipo": "Digital", "incluye": "1 mando DualSense"}', 2499000.0000, 22),
(29, 5, 'Mouse Gamer Logitech G Pro', 'Mouse gaming inalámbrico, sensor HERO 25K, 80g ultraligero', '/productos/logitech-gpro.jpg', 6, '{"tipo": "Inalámbrico", "sensor": "HERO 25K", "peso": "80g", "bateria": "70 horas"}', 499900.0000, 55),
(30, 5, 'Teclado Mecánico RGB', 'Teclado mecánico gaming switches Cherry MX Red, retroiluminación RGB por tecla', '/productos/teclado-rgb.jpg', 6, '{"switches": "Cherry MX Red", "retroiluminacion": "RGB por tecla", "conexion": "USB-C"}', 399900.0000, 40),
(31, 5, 'Monitor Gaming 27" 240Hz', 'Monitor gaming curvo 27" Full HD, tasa de refresco 240Hz, 1ms, FreeSync Premium', '/productos/monitor-27.jpg', 6, '{"tamaño": "27 pulgadas", "refresco": "240Hz", "resolucion": "Full HD", "panel": "VA curvo"}', 1999000.0000, 15),
(32, 5, 'Silla Gamer Reclinable', 'Silla gaming ergonómica reclinable 180°, soporte lumbar, reposabrazos 3D', '/productos/silla-gamer.jpg', 17, '{"reclinable": "180 grados", "material": "Cuero PU", "peso_maximo": "150kg"}', 1299000.0000, 20),

-- Cocina & Sabor (tienda 6)
(33, 6, 'Freidora Sin Aceite 5.5L', 'Freidora de aire digital 5.5L, 8 programas predefinidos, pantalla táctil', '/productos/freidora-aire.jpg', 18, '{"capacidad": "5.5L", "potencia": "1700W", "programas": "8", "pantalla": "Táctil LED"}', 399900.0000, 30),
(34, 6, 'Procesador de Alimentos', 'Procesador de alimentos 10 funciones, bowl 1.2L, cuchilla de acero inoxidable', '/productos/procesador-alimentos.jpg', 18, '{"funciones": "10", "capacidad": "1.2L", "material": "Acero inoxidable"}', 299900.0000, 25),
(35, 6, 'Set Ollas Antiadherentes 10pz', 'Juego de 10 piezas: ollas y sartenes antiadherentes con tapa de vidrio, aptas para inducción', '/productos/set-ollas.jpg', 18, '{"piezas": "10", "material": "Aluminio antiadherente", "apto": "Inducción, gas, eléctrica"}', 549900.0000, 18);

-- Trabajadores
INSERT IGNORE INTO TTrabajador (nTrabajadorID, cIdentificacion, cNombre, cApellido, cPassword, cTelefono, nRolFK) VALUES
(1, '1111111111', 'Admin', 'Sistema', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6000000000', 1),
(2, '2222222222', 'Laura', 'Castro', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6015550102', 2),
(3, '3333333333', 'Andrés', 'López', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6015550103', 3),
(4, '4444444444', 'Diana', 'Pérez', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6015550104', 4),
(5, '5555555555', 'Jorge', 'Mora', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6024440102', 2),
(6, '6666666666', 'Sofía', 'Arias', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6024440103', 3),
(7, '7777777777', 'Miguel', 'Rueda', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', '6013330203', 3);

-- Trabajadores por tienda
INSERT IGNORE INTO TTrabajadorTienda (nID, nTiendaFK, nTrabajadorFK) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 2, 1),
(5, 2, 4),
(6, 3, 1),
(7, 4, 5),
(8, 4, 6),
(9, 5, 7),
(10, 5, 1);

-- Pedidos
INSERT IGNORE INTO TPedido (nPedidoID, nClienteFK, nDireccionClienteFK, cNumeroComprobante, nSubtotal, nCostoEnvio, nTotal, nTransaccionPasarelaFK, nEstadoPedidoFK, dFechaActualizacion) VALUES
(1, 1, 1, 'MVP-ORD-00001', 5999000.0000, 10000.0000, 6009000.0000, 1, 5, NOW()),
(2, 1, 2, 'MVP-ORD-00002', 898000.0000, 10000.0000, 908000.0000, 2, 2, NOW()),
(3, 2, 3, 'MVP-ORD-00003', 329800.0000, 12000.0000, 341800.0000, 3, 1, NOW()),
(4, 4, 5, 'MVP-ORD-00004', 10498000.0000, 15000.0000, 10513000.0000, 4, 4, NOW()),
(5, 4, 12, 'MVP-ORD-00005', 559800.0000, 10000.0000, 569800.0000, 5, 3, NOW()),
(6, 5, 6, 'MVP-ORD-00006', 1648800.0000, 12000.0000, 1660800.0000, 6, 1, NOW()),
(7, 6, 7, 'MVP-ORD-00007', 449700.0000, 15000.0000, 464700.0000, 7, 6, NOW()),
(8, 7, 8, 'MVP-ORD-00008', 129900.0000, 10000.0000, 139900.0000, 8, 5, NOW()),
(9, 8, 9, 'MVP-ORD-00009', 3499000.0000, 10000.0000, 3509000.0000, 9, 4, NOW()),
(10, 9, 10, 'MVP-ORD-00010', 8499000.0000, 20000.0000, 8519000.0000, 10, 2, NOW());

-- Detalle de pedidos
INSERT IGNORE INTO TDetallePedido (nDetallePedidoID, nPedidoFK, nProductoFK, cNombreProducto, nPrecioCompra, nCantidad, nSubtotal) VALUES
(1, 1, 1, 'iPhone 15 Pro 256GB', 5999000.0000, 1, 5999000.0000),
(2, 2, 3, 'Audífonos Sony WH-1000XM5', 899000.0000, 1, 899000.0000),
(3, 2, 4, 'Camiseta Algodón Premium', 79900.0000, 1, 79900.0000),
(4, 3, 5, 'Zapatillas Deportivas AirMax', 249900.0000, 1, 249900.0000),
(5, 3, 7, 'Set Pesas 20kg', 149900.0000, 1, 149900.0000),
(6, 4, 12, 'TV LG OLED 65" C4', 6999000.0000, 1, 6999000.0000),
(7, 4, 13, 'Nintendo Switch OLED', 1499000.0000, 1, 1499000.0000),
(8, 4, 9, 'iPad Pro M4 11"', 1999000.0000, 1, 1999000.0000),
(9, 5, 21, 'Set 6 Tazas Porcelana', 129900.0000, 2, 259800.0000),
(10, 5, 19, 'Juego de Sábanas 300 Hilos', 249900.0000, 1, 249900.0000),
(11, 5, 20, 'Lámpara Colgante Nórdica', 189900.0000, 1, 189900.0000),
(12, 6, 23, 'Bicicleta Montaña 29"', 1499000.0000, 1, 1499000.0000),
(13, 6, 24, 'Balón Fútbol Profesional', 159900.0000, 1, 159900.0000),
(14, 7, 27, 'Guantes Boxeo Profesional', 189900.0000, 1, 189900.0000),
(15, 7, 26, 'Carpa Camping 4 Personas', 699900.0000, 1, 699900.0000),
(16, 8, 21, 'Set 6 Tazas Porcelana', 129900.0000, 1, 129900.0000),
(17, 9, 10, 'Apple Watch Ultra 2', 3499000.0000, 1, 3499000.0000),
(18, 10, 11, 'Cámara Sony A7 IV', 8499000.0000, 1, 8499000.0000),
(19, 6, 14, 'Jeans Clásico 5 Bolsillos', 139900.0000, 1, 139900.0000);

-- Transacciones
INSERT IGNORE INTO TTransaccionPasarela (nTransaccionID, nPedidoFK, cNombrePasarela, cIdTransaccionExterna, cMetodoPago, eFranquicia, cUltimos4Digitos, nCuotas, nValorTransaccion, cEstadoTransaccion, cCodigoAprobacionBanco) VALUES
(1, 1, 'PayPal', 'PAY-001-ABC', 'Tarjeta Crédito', 'Visa', '1234', 12, 6009000.0000, 'Aprobado', 'APR-001'),
(2, 2, 'PayPal', 'PAY-002-DEF', 'Tarjeta Débito', 'Mastercard', '5678', 1, 908000.0000, 'Aprobado', 'APR-002'),
(3, 3, 'PayPal', 'PAY-003-GHI', 'Tarjeta Crédito', 'Visa', '9012', 3, 341800.0000, 'Pendiente', NULL),
(4, 4, 'PayPal', 'PAY-004-JKL', 'Tarjeta Crédito', 'AMEX', '3456', 24, 10513000.0000, 'Aprobado', 'APR-004'),
(5, 5, 'PayPal', 'PAY-005-MNO', 'Tarjeta Débito', 'Visa', '7890', 1, 569800.0000, 'Aprobado', 'APR-005'),
(6, 6, 'PayPal', 'PAY-006-PQR', 'Tarjeta Crédito', 'Mastercard', '1111', 6, 1660800.0000, 'Pendiente', NULL),
(7, 7, 'PayPal', 'PAY-007-STU', 'Tarjeta Crédito', 'Visa', '2222', 3, 464700.0000, 'Rechazado', NULL),
(8, 8, 'PayPal', 'PAY-008-VWX', 'Tarjeta Débito', 'Mastercard', '3333', 1, 139900.0000, 'Aprobado', 'APR-008'),
(9, 9, 'PayPal', 'PAY-009-YZA', 'Tarjeta Crédito', 'Visa', '4444', 12, 3509000.0000, 'Aprobado', 'APR-009'),
(10, 10, 'PayPal', 'PAY-010-BCD', 'Tarjeta Crédito', 'AMEX', '5555', 18, 8519000.0000, 'Aprobado', 'APR-010');

-- Usuarios admin
INSERT IGNORE INTO TUsuarioAdmin (nIdUsuario, cNombre, cApellido, cCorreo, cPassword, eEstado) VALUES
(1, 'Super', 'Admin', 'admin@mvp.com', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Activo'),
(2, 'Admin', 'Tiendas', 'tiendas@mvp.com', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Activo'),
(3, 'Admin', 'PQRS', 'pqrs@mvp.com', '$2y$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Activo');

-- Tiendas admin (gestión desde el panel admin)
INSERT IGNORE INTO TTiendaAdmin (nIdTienda, cNombre, cDireccion, cTelefono, eEstado) VALUES
(1, 'TechZone Colombia', 'Calle 26 # 69-76', '6015550101', 'Activa'),
(2, 'ModaExpress', 'Carrera 43A # 1-50', '6015550202', 'Activa'),
(3, 'HogarPerfecto', 'Avenida 68 # 20-10', '6015550303', 'Pendiente'),
(4, 'Deportes Total', 'Carrera 11 # 100-50', '6024440101', 'Activa'),
(5, 'GamerZone', 'Calle 45 # 28-60', '6013330202', 'Activa'),
(6, 'Cocina & Sabor', 'Calle 5 # 15-80', '6052220303', 'Inactiva');

-- PQRS
INSERT IGNORE INTO TPQRS (nPQRSID, nCreadorFK, cTipoCreador, eTipo, eEstado, cNumeroTicket, cAsunto, nPedidoFK, nTiendaFK) VALUES
(1, 1, 'Usuario', 'Peticion', 'Resuelto', 'TKT-001', 'Solicitud de factura electrónica', 1, 1),
(2, 2, 'Usuario', 'Queja', 'Activo', 'TKT-002', 'Retraso en la entrega del pedido', 3, 2),
(3, 4, 'Usuario', 'Reclamo', 'Activo', 'TKT-003', 'Producto llegó con golpe en la pantalla', 4, 1),
(4, 5, 'Usuario', 'Sugerencia', 'Pendiente', 'TKT-004', 'Sugerencia para incluir más tallas en jeans', NULL, 2),
(5, 6, 'Usuario', 'Queja', 'Resuelto', 'TKT-005', 'Cobro duplicado en la transacción', 7, 4),
(6, 1, 'Usuario', 'Peticion', 'Activo', 'TKT-006', 'Solicitud de cambio de producto', 2, 1),
(7, 8, 'Usuario', 'Peticion', 'Pendiente', 'TKT-007', 'Información sobre garantía del reloj', 9, 1);

-- Hilos de PQRS
INSERT IGNORE INTO THiloPQRS (nHiloPQRSID, nPQRSFK, cMensaje, nActorFK, cTipoActor, bEsMensajeInterno, cEvidencia) VALUES
(1, 1, 'Buenos días, necesito la factura electrónica de mi compra #MVP-ORD-00001. Quedo atento.', 1, 'Usuario', FALSE, NULL),
(2, 1, 'Hola Carlos, te hemos enviado la factura a tu correo carlos@email.com. Quedamos atentos a cualquier otra solicitud.', 1, 'Admin', FALSE, NULL),
(3, 2, 'Compré unas zapatillas y un set de pesas el día lunes y aún no recibo actualización del envío.', 2, 'Usuario', FALSE, NULL),
(4, 2, 'María, tu pedido #MVP-ORD-00003 está en preparación. El número de guía se generará en las próximas 24h.', 2, 'Tienda', FALSE, NULL),
(5, 3, 'Recibí el TV LG OLED y la pantalla tiene una línea vertical. Necesito solución urgente.', 4, 'Usuario', FALSE, '/evidencias/foto-linea-tv.jpg'),
(6, 3, 'Estimada Ana, sentimos los inconvenientes. Generamos la solicitud de cambio. Un transportador pasará el martes.', 1, 'Admin', FALSE, NULL),
(7, 3, 'Nota interna: verificar si el daño fue en transporte o de fábrica. Revisar con transportadora.', 1, 'Admin', TRUE, NULL),
(8, 4, 'Sería excelente que sacaran jeans en tallas 42 y 44, muchos clientes los piden.', 5, 'Usuario', FALSE, NULL),
(9, 4, 'Gracias Luis, tomamos tu sugerencia. La evaluaremos con el equipo de producción.', 2, 'Tienda', FALSE, NULL),
(10, 5, 'Me aparece un cobro doble en mi estado de cuenta por el pedido #MVP-ORD-00007.', 6, 'Usuario', FALSE, '/evidencias/captura-banco.png'),
(11, 5, 'Camila, verificamos con la pasarela de pago. Fue un error de la pasarela, el segundo cargo se reversará en 72h.', 1, 'Admin', FALSE, NULL),
(12, 5, 'Nota interna: contactar a PayPal para acelerar la reversión del pago duplicado.', 1, 'Admin', TRUE, NULL),
(13, 6, 'Quisiera cambiar los audífonos Sony por el modelo inalámbrico deportivo, ¿es posible?', 1, 'Usuario', FALSE, NULL),
(14, 7, 'Buenos días, quisiera saber qué cobertura tiene la garantía del Apple Watch Ultra 2.', 8, 'Usuario', FALSE, NULL);

SET FOREIGN_KEY_CHECKS = 1;

-- ======================================================
-- FIN DEL SCRIPT DE INICIALIZACIÓN
-- ======================================================
