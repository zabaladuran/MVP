<?php

require_once __DIR__ . '/../models/homeModel.php';
require_once __DIR__ . '/../models/ProductModel.php';

class HomeController
{
    public function mostrarHome()
    {
        if (!isset($_SESSION['usuario_id'])) {
            header('Location: ?vista=login');
            exit;
        }

        $homeModel = new HomeModel();
        $productModel = new ProductModel();

        $usuario = $homeModel->obtenerUsuarioPorId(
            $_SESSION['usuario_id']
        );

        $categoriaSeleccionada = trim($_GET['categoria'] ?? '');
        $busqueda = trim($_GET['busqueda'] ?? '');

        $categorias = $productModel->obtenerCategorias();
        $productos = $productModel->obtenerProductos(
            $categoriaSeleccionada,
            $busqueda
        );

        require_once __DIR__ . '/../views/homeView.php';
    }
}