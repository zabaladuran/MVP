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
    <script src="pwa.js" defer></script>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 50px;
        }
        form {
            max-width: 400px;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 5px;
        }
        input {
            width: 100%;
            padding: 8px;
            margin: 5px 0 15px;
            box-sizing: border-box;
        }
        button {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        button:hover {
            background-color: #45a049;
        }
        .error {
            color: red;
            margin: 10px 0;
        }
        .exito {
            color: green;
            margin: 10px 0;
        }
        .link {
            text-align: center;
            margin-top: 15px;
        }
        a {
            color: #007BFF;
            text-decoration: none;
        }
    </style>
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
