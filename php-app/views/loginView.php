<!-- filepath: c:\xampp\htdocs\MVP\MVP\php-app\views\loginView.php -->
<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#7c3aed">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
    <link rel="stylesheet" href="views/CSS/global.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" defer></script>
</head>

<body>
    <div class="container py-5">
        <div class="auth-card card-surface">
            <div class="text-center mb-4">
                <h1 class="form-heading">Iniciar sesión</h1>
                <p class="form-subtitle">Accede a tu cuenta para ver los productos disponibles.</p>
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

            <form action="?vista=login&accion=validar" method="POST" class="row g-3">
                <div class="col-12">
                    <label for="correo" class="form-label">Correo</label>
                    <input
                        type="email"
                        name="correo"
                        id="correo"
                        class="form-control input-field"
                        placeholder="Correo"
                        required>
                </div>

                <div class="col-12">
                    <label for="password" class="form-label">Contraseña</label>
                    <div class="input-group">
                        <input
                            type="password"
                            name="password"
                            id="password"
                            class="form-control input-field"
                            placeholder="Contraseña"
                            required>
                        <button type="button" class="btn btn-outline-secondary" id="togglePassword" aria-label="Mostrar contraseña">
                            <i class="bi bi-eye"></i>
                        </button>
                    </div>
                </div>

                <div class="col-12">
                    <button type="submit" class="btn btn-primary btn-lg w-100">Ingresar</button>
                </div>
            </form>

            <div class="text-center mt-3">
                <p class="mb-0">¿No tienes cuenta? <a href="?vista=registro" class="link-primary">Regístrate aquí</a></p>
            </div>
        </div>
    </div>

    <script>
        const togglePassword = document.getElementById('togglePassword');
        const passwordInput = document.getElementById('password');

        togglePassword.addEventListener('click', () => {
            const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
            passwordInput.setAttribute('type', type);

            togglePassword.innerHTML = type === 'password' 
                ? '<i class="bi bi-eye"></i>' 
                : '<i class="bi bi-eye-slash"></i>';
        });
    </script>

</body>
</html>