<?php
?>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#4CAF50">
    <title>Registro</title>
    <link rel="manifest" href="manifest.json">
    <link rel="icon" href="icons/shopp1.svg" type="image/svg+xml">
    <link rel="stylesheet" href="views/CSS/registerCss.css">
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

<form action="?vista=registro&accion=crear" method="POST">
    <h1>Registro de Usuario</h1>

    <input
        type="text"
        name="nombre"
        placeholder="Nombre"
        required>

    <input
        type="text"
        name="apellido"
        placeholder="Apellido"
        required>

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

    <input
        type="password"
        name="confirmPassword"
        placeholder="Confirmar Contraseña"
        required>

    <input
        type="tel"
        name="telefono"
        placeholder="Teléfono">

    <button type="submit">
        Registrarse
    </button>
    <div class="link">
    <p>¿Ya tienes cuenta? <a href="?vista=login">Inicia sesión aquí</a></p>
    </div>


</form>


</body>
</html>
