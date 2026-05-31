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
} else {
    $login = new LoginController();
    $login->mostrarLogin();
}