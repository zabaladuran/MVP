<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <title>Inicio</title>
</head>

<body>

    <h1>
        Bienvenido
        <?= $usuario['cNombre']; ?>
        <?= $usuario['cApellido']; ?>
    </h1>

    <p>
        Has iniciado sesión correctamente.
    </p>

    <a href="?vista=productos">
        Ver catálogo
    </a>

    <br><br>

    <a href="?vista=logout">
        Cerrar sesión
    </a>

</body>

</html>