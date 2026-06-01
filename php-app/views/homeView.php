<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#4CAF50">
    <title>Inicio - Tienda</title>
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
                <a href="#catalogo">Catálogo</a>
                <a href="#destacados">Destacados</a>
                <a href="?vista=login&accion=logout" class="button button-secondary">Cerrar sesión</a>
            </nav>
        </header>

        <main>
            <section class="hero">
                <div class="hero-copy">
                    <p class="eyebrow">Bienvenido a tu tienda</p>
                    <h1>Hola, <?= htmlspecialchars($usuario['cNombre'] . ' ' . $usuario['cApellido'], ENT_QUOTES, 'UTF-8'); ?></h1>
                    <p class="hero-text">Explora los productos más populares, ofertas exclusivas y disfruta de una experiencia de compra rápida y segura.</p>
                    <a href="#catalogo" class="button button-primary">Ver catálogo</a>
                </div>
                <div class="hero-visual">
                    <div class="hero-card">Productos en oferta</div>
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
                    <a href="#" class="link-secondary">Ver todo</a>
                </div>

                <div class="product-grid">
                    <article class="product-card">
                        <div class="product-image image-1"></div>
                        <h3>Producto 1</h3>
                        <p>Calidad premium y diseño moderno para uso diario.</p>
                        <button class="button button-tertiary">Ver producto</button>
                    </article>
                    <article class="product-card">
                        <div class="product-image image-2"></div>
                        <h3>Producto 2</h3>
                        <p>La elección perfecta para tus compras con envío garantizado.</p>
                        <button class="button button-tertiary">Ver producto</button>
                    </article>
                    <article class="product-card">
                        <div class="product-image image-3"></div>
                        <h3>Producto 3</h3>
                        <p>Diseño elegante y cómodo para tu estilo de vida activo.</p>
                        <button class="button button-tertiary">Ver producto</button>
                    </article>
                </div>
            </section>
        </main>
    </div>
</body>

</html>