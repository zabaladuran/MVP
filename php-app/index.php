<?php

session_start();

if (isset($_SESSION['usuario_id']) && !isset($_GET['vista'])) {
    echo '<!DOCTYPE html>';
    echo '<html lang="es">';
    echo '<head>';
    echo '    <meta charset="UTF-8">';
    echo '    <meta name="viewport" content="width=device-width, initial-scale=1.0">';
    echo '    <title>Inicio</title>';
    echo '    <style>body{font-family:Arial,sans-serif;margin:50px;} a{color:#007BFF;text-decoration:none;}</style>';
    echo '</head>';
    echo '<body>';
    echo '    <h1>Hello World</h1>';
    echo '    <p>Bienvenido, ' . htmlspecialchars($_SESSION['nombre']) . '.</p>';
    echo '    <p><a href="?vista=login&accion=logout">Cerrar sesión</a></p>';
    echo '</body>';
    echo '</html>';
    exit;
}

require_once 'Router.php';