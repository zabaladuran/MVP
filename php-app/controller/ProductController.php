<?php

require_once __DIR__ . '/../models/ProductModel.php';

class ProductController
{
    public function mostrarDetalle($id)
    {
        if (!isset($_SESSION['usuario_id'])) {
            header('Location: ?vista=login');
            exit;
        }

        $productModel = new ProductModel();
        $producto = $productModel->obtenerProductoPorId($id);

        if (!$producto) {
            $_SESSION['error'] = 'Producto no encontrado';
            header('Location: ?vista=home');
            exit;
        }

        require_once __DIR__ . '/../views/productDetailView.php';
    }
}
