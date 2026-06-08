<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#7c3aed">
    <title>Registro</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="views/CSS/global.css">
    <link rel="manifest" href="android-app/manifest.json">
    <link rel="icon" href="android-app/icons/shopp1.svg" type="image/svg+xml">
    <script src="android-app/pwa.js" defer></script>
</head>

<body>
    <div class="container py-5">
        <div class="auth-card card-surface">
            <div class="text-center mb-4">
                <h1 class="form-heading">Registro de Usuario</h1>
                <p class="form-subtitle">Crea tu cuenta y comienza a comprar con el diseño morado.</p>
            </div>

            <?php if(isset($_SESSION['error'])): ?>
                <div class="alert alert-danger alert-custom">
                    <?= $_SESSION['error']; ?>
                </div>
                <?php unset($_SESSION['error']); ?>
            <?php endif; ?>

            <?php if(isset($_SESSION['exito'])): ?>
                <div class="alert alert-success alert-custom">
                    <?= $_SESSION['exito']; ?>
                </div>
                <?php unset($_SESSION['exito']); ?>
            <?php endif; ?>

            <form action="?vista=registro&accion=crear" method="POST" class="row g-3">
                <div class="col-12 col-md-6">
                    <label class="form-label" for="nombre">Nombre</label>
                    <input type="text" id="nombre" name="nombre" placeholder="Nombre" class="form-control input-field" required>
                </div>

                <div class="col-12 col-md-6">
                    <label class="form-label" for="apellido">Apellido</label>
                    <input type="text" id="apellido" name="apellido" placeholder="Apellido" class="form-control input-field" required>
                </div>

                <div class="col-12">
                    <label class="form-label" for="correo">Correo</label>
                    <input type="email" id="correo" name="correo" placeholder="Correo" class="form-control input-field" required>
                </div>

                <div class="col-12 col-md-6">
                    <label class="form-label" for="password">Contraseña</label>
                    <input type="password" id="password" name="password" placeholder="Contraseña" class="form-control input-field" required>
                </div>

                <div class="col-12 col-md-6">
                    <label class="form-label" for="confirmPassword">Confirmar Contraseña</label>
                    <input type="password" id="confirmPassword" name="confirmPassword" placeholder="Confirmar Contraseña" class="form-control input-field" required>
                </div>

                <div class="col-12">
                    <label class="form-label" for="telefono">Teléfono</label>
                    <input type="tel" id="telefono" name="telefono" placeholder="Teléfono" class="form-control input-field">
                </div>

                <div class="col-12">
                    <button type="submit" class="btn btn-primary btn-lg w-100">Registrarse</button>
                </div>
            </form>

            <div class="link text-center mt-3">
                <p class="mb-0">¿Ya tienes cuenta? <a href="?vista=login" class="link-primary">Inicia sesión aquí</a></p>
            </div>
        </div>
    </div>


</body>
</html>
