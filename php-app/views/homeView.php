<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#7c3aed">
    <title>Inicio - Tienda</title>
    <link rel="manifest" href="android-app/manifest.json">
    <link rel="icon" href="android-app/icons/shopp1.svg" type="image/svg+xml">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="views/CSS/homeCss1.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" defer></script>
    <script src="android-app/pwa.js" defer></script>
</head>

<body>
    <div class="page-shell">
        <header class="topbar">
            <div class="brand">
                <span class="brand-mark">Ti</span>
                <span class="brand-name">Tienda MVP</span>
            </div>
            <nav class="nav-links">
                <a href="#catalogo">Catálogo</a>
                <a href="#destacados">Destacados</a>
                <a href="?vista=login&accion=logout" class="button button-secondary">Cerrar sesión</a>
            </nav>
        </header>

        <main>
            <section class="hero">
                <div class="hero-copy">
                    <p class="eyebrow">Bienvenido a tu tienda</p>
                    <h1>Hola, <?= htmlspecialchars(($usuario['cNombre'] ?? '') . ' ' . ($usuario['cApellido'] ?? ''), ENT_QUOTES, 'UTF-8'); ?></h1>
                    <p class="hero-text">Explora los productos más populares, ofertas exclusivas y disfruta de una experiencia de compra rápida y segura.</p>
                    <a href="#catalogo" class="button button-primary">Ver catálogo</a>
                </div>
                <div class="hero-visual">
                    <div class="hero-card">
                        <span class="hero-card-text">Productos en oferta</span>
                        <img src="android-app/icons/shopp1.svg" alt="Tienda" class="hero-visual-img">
                    </div>
                </div>
            </section>

            <section id="destacados" class="features">
                <article>
                    <h2>Envío rápido</h2>
                    <p>Recibe tus pedidos en tiempo récord con seguimiento y entrega segura.</p>
                </article>
                <article>
                    <h2>Mejores precios</h2>
                    <p>Ofertas especiales y descuentos para clientes frecuentes.</p>
                </article>
                <article>
                    <h2>Atención 24/7</h2>
                    <p>Soporte disponible siempre que lo necesites para ayudarte con tus compras.</p>
                </article>
            </section>

            <section id="catalogo" class="catalogue">
                <div class="section-header">
                    <div>
                        <p class="eyebrow">Colección</p>
                        <h2>Productos destacados</h2>
                    </div>
                    <a href="?vista=home" class="link-secondary">Ver todo</a>
                </div>

                <form method="GET" class="filters">
                    <input type="hidden" name="vista" value="home">
                    <div class="filter-group">
                        <label for="categoria">Categoría</label>
                        <select id="categoria" name="categoria">
                            <option value="">Todas las categorías</option>
                            <?php foreach ($categorias as $categoria) : ?>
                                <option value="<?= htmlspecialchars($categoria['nCategoriaID'], ENT_QUOTES, 'UTF-8'); ?>" <?= ($categoriaSeleccionada == $categoria['nCategoriaID']) ? 'selected' : ''; ?>>
                                    <?= htmlspecialchars($categoria['cNombreCategoria'], ENT_QUOTES, 'UTF-8'); ?>
                                </option>
                            <?php endforeach; ?>
                        </select>
                    </div>
                    <div class="filter-group">
                        <label for="busqueda">Buscar</label>
                        <input
                            id="busqueda"
                            name="busqueda"
                            type="text"
                            placeholder="Buscar producto..."
                            value="<?= htmlspecialchars($busqueda, ENT_QUOTES, 'UTF-8'); ?>">
                    </div>
                    <button type="submit" class="button button-primary">Filtrar</button>
                </form>

                <?php if (empty($productos)) : ?>
                    <p>No se encontraron productos con esos criterios.</p>
                <?php else : ?>
                    <div class="product-grid">
                        <?php foreach ($productos as $producto) : ?>
                            <?php
                                $imagenUrl = $producto['cUrlImagenPrincipal'] ?? '';
                                $imagenUrl = ltrim($imagenUrl, '/');
                                if (empty($imagenUrl)) {
                                    $imagenUrl = '../android-app/icons/shopp1.svg';
                                }
                            ?>
                            <article class="product-card">
                                <div class="product-image" style="background-image: url('<?= htmlspecialchars($imagenUrl, ENT_QUOTES, 'UTF-8'); ?>');"></div>
                                <h3><?= htmlspecialchars($producto['cNombreProducto'] ?? $producto['cDescripcionCorta'] ?? 'Sin nombre', ENT_QUOTES, 'UTF-8'); ?></h3>
                                <p><?= htmlspecialchars($producto['cDescripcionCorta'] ?: 'Sin descripción corta', ENT_QUOTES, 'UTF-8'); ?></p>
                                <p><strong>Precio:</strong> $<?= number_format($producto['nPrecioUnitario'], 2); ?></p>
                                <p><strong>Categoría:</strong> <?= htmlspecialchars($producto['cNombreCategoria'] ?: 'General', ENT_QUOTES, 'UTF-8'); ?></p>
                                <a href="?vista=producto&accion=detalle&id=<?= htmlspecialchars($producto['nProductoID'], ENT_QUOTES, 'UTF-8'); ?>" class="button button-tertiary">Ver producto</a>
                            </article>
                        <?php endforeach; ?>
                    </div>
                <?php endif; ?>
            </section>
        </main>
    </div>
    <script>
        // Inicializar ScrollSpy para mantener activas las secciones en la navbar
        document.addEventListener('DOMContentLoaded', function () {
            if (typeof bootstrap !== 'undefined') {
                try {
                    new bootstrap.ScrollSpy(document.body, { target: '.nav-links', offset: 100 });
                } catch(e) { console.warn(e); }
            }

            // IntersectionObserver para animaciones slide-in
            const io = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('in-view');
                    }
                });
            }, { threshold: 0.12 });

            document.querySelectorAll('.slide-in, .product-card, .features article, .hero-card').forEach(el => io.observe(el));
        });
    </script>
</body>

</html>