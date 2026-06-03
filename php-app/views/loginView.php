<?php
?>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#4CAF50">
    <title>Login</title>
    <link rel="manifest" href="manifest.json">
    <link rel="icon" href="icons/shopp1.svg" type="image/svg+xml">
    <link rel="stylesheet" href="views/CSS/loginCss.css">
    <script src="pwa.js" defer></script>
</head>

<body>



<?php if(isset($_SESSION['error'])): ?>
    <p class="error">
        <?= $_SESSION['error']; ?>
    </p>
    <?php unset($_SESSION['error']); ?>
<?php endif; ?>

<?php if(isset($_SESSION['exito'])): ?>
    <p class="exito">
        <?= $_SESSION['exito']; ?>
    </p>
    <?php unset($_SESSION['exito']); ?>
<?php endif; ?>

<form action="?vista=login&accion=validar" method="POST">
    <h1>Iniciar sesión</h1>

    <input
        type="email"
        name="correo"
        placeholder="Correo"
        required>

    <input
        type="password"
        name="password"
        placeholder="Contraseña"
        required>

    <button type="submit">
        Ingresar
    </button>
    
    <div class="link">
    <p>¿No tienes cuenta? <a href="?vista=registro">Regístrate aquí</a></p>
    </div>

</form>



</body>
</html>