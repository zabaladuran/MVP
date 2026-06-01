<?php

require_once __DIR__ . '/../models/homeModel.php';

class HomeController
{
    public function mostrarHome()
    {
        if (!isset($_SESSION['usuario_id'])) {

            header('Location: ?vista=login');
            exit;
        }

        $homeModel = new HomeModel();

        $usuario = $homeModel->obtenerUsuarioPorId(
            $_SESSION['usuario_id']
        );

        require_once __DIR__ . '/../views/homeView.php';
    }
}