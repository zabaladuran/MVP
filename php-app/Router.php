<?php

require_once __DIR__ . '/controller/loginController.php';
require_once __DIR__ . '/controller/registerController.php';

$vista = $_GET['vista'] ?? 'login';
$accion = $_GET['accion'] ?? null;

if ($vista === 'login') {
    $login = new LoginController();
    if ($accion === 'validar') {
        $login->login();
    } elseif ($accion === 'logout') {
        $login->logout();
    } else {
        $login->mostrarLogin();
    }
} elseif ($vista === 'registro') {
    $registro = new RegisterController();
    if ($accion === 'crear') {
        $registro->registro();
    } else {
        $registro->mostrarRegistro();
    }
} elseif ($vista === 'home') {
    require_once 'controller/homenController.php';
    $controller = new HomeController();
    $controller->mostrarHome();
} elseif ($vista === 'producto') {
    require_once 'controller/ProductController.php';
    $controller = new ProductController();

    if ($accion === 'detalle' && isset($_GET['id'])) {
        $controller->mostrarDetalle($_GET['id']);
    } else {
        header('Location: ?vista=home');
        exit;
    }
} else {
    $login = new LoginController();
    $login->mostrarLogin();
}
