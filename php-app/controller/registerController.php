<?php

require_once __DIR__ . '/../models/registerModel.php';

class RegisterController
{
    public function registro()
    {
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {

            $nombre = trim($_POST['nombre'] ?? '');
            $apellido = trim($_POST['apellido'] ?? '');
            $correo = trim($_POST['correo'] ?? '');
            $password = trim($_POST['password'] ?? '');
            $confirmPassword = trim($_POST['confirmPassword'] ?? '');
            $telefono = trim($_POST['telefono'] ?? '');

            // Validaciones
            if (empty($nombre) || empty($apellido) || empty($correo) || empty($password) || empty($confirmPassword)) {
                $_SESSION['error'] = 'Todos los campos son requeridos';
            } elseif (!filter_var($correo, FILTER_VALIDATE_EMAIL)) {
                $_SESSION['error'] = 'El correo no es válido';
            } elseif ($password !== $confirmPassword) {
                $_SESSION['error'] = 'Las contraseñas no coinciden';
            } elseif (strlen($password) < 6) {
                $_SESSION['error'] = 'La contraseña debe tener al menos 6 caracteres';
            } else {
                $usuarioRegistro = new UsuarioRegistro();

                // Verificar si el correo ya existe
                if ($usuarioRegistro->verificarCorreo($correo)) {
                    $_SESSION['error'] = 'El correo ya está registrado';
                } else {
                    try {
                        if ($usuarioRegistro->crearUsuario($nombre, $apellido, $correo, $password, $telefono)) {
                            $_SESSION['exito'] = 'Usuario registrado exitosamente. Por favor inicia sesión.';
                            header('Location: ?vista=login');
                            exit;
                        }
                    } catch (Exception $e) {
                        $_SESSION['error'] = $e->getMessage();
                    }
                }
            }
        }

        require_once __DIR__ . '/../views/registerView.php';
    }

    public function mostrarRegistro()
    {
        require_once __DIR__ . '/../views/registerView.php';
    }
}
