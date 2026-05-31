<?php

require_once __DIR__ . '/../models/loginModel.php';

class LoginController
{
    public function login()
    {
        session_start();

        if ($_SERVER['REQUEST_METHOD'] === 'POST') {

            $correo = trim($_POST['correo']);
            $password = trim($_POST['password']);

            $usuarioModel = new Usuario();

            $usuario = $usuarioModel->obtenerPorCorreo($correo);

            if ($usuario) {

                if (password_verify($password, $usuario['cContrasena'])) {

                    $_SESSION['usuario_id'] =
                        $usuario['nUsuarioClienteID'];

                    $_SESSION['nombre'] =
                        $usuario['cNombre'];

                    header('Location: index.php');
                    exit;

                } else {

                    $_SESSION['error'] =
                        'Contraseña incorrecta';
                }

            } else {

                $_SESSION['error'] =
                    'Usuario no encontrado';
            }
        }

        require_once __DIR__ . '/../views/loginView.php';
    }

    public function mostrarLogin()
    {
        require_once __DIR__ . '/../views/loginView.php';
    }

    public function logout()
    {
        session_start();

        session_destroy();

        header('Location: index.php');
        exit;
    }
}