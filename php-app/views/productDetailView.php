<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#4CAF50">
    <title>Detalle del producto</title>
    <link rel="manifest" href="manifest.json">
    <link rel="icon" href="icons/shopp1.svg" type="image/svg+xml">
    <link rel="stylesheet" href="views/CSS/homeCss1.css">
    <script src="pwa.js" defer></script>
</head>

<body>
    <div class="page-shell">
        <header class="topbar">
            <div class="brand">
                <span class="brand-mark">Ti</span>
                <span class="brand-name">Tienda MVP</span>
            </div>
            <nav class="nav-links">
                <a href="?vista=home">Catálogo</a>
                <a href="?vista=login&accion=logout" class="button button-secondary">Cerrar sesión</a>
            </nav>
        </header>

        <main class="product-detail-page">
            <section class="product-detail">
                <div class="detail-image" style="background-image: url('<?= htmlspecialchars($producto['cUrlImagenPrincipal'] ?: 'icons/shopp1.svg', ENT_QUOTES, 'UTF-8'); ?>');"></div>
                <div class="detail-content">
                    <span class="eyebrow">Detalle del producto</span>
                    <h1><?= htmlspecialchars($producto['cNombreProducto'], ENT_QUOTES, 'UTF-8'); ?></h1>
                    <p class="detail-category">Categoría: <?= htmlspecialchars($producto['cNombreCategoria'] ?: 'Sin categoría', ENT_QUOTES, 'UTF-8'); ?></p>
                    <p class="detail-price">Precio: $<?= number_format($producto['nPrecioUnitario'], 2); ?></p>
                    <p class="detail-stock">Stock disponible: <?= htmlspecialchars($producto['nCantidadStock'], ENT_QUOTES, 'UTF-8'); ?></p>
                    <p class="detail-description">
                        <?= nl2br(htmlspecialchars($producto['cDescripcionLarga'] ?: $producto['cDescripcionCorta'], ENT_QUOTES, 'UTF-8')); ?>
                    </p>

                    <div class="detail-actions">
                        <a href="?vista=home" class="button button-secondary">Volver al catálogo</a>
                        <button class="button button-primary" type="button">Agregar al carrito</button>
                    </div>
                </div>
            </section>
        </main>
    </div>
</body>

</html>
