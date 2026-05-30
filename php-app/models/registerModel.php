<?php

require_once __DIR__ . '/../database/conexion.php';

class UsuarioRegistro
{
    private $db;

    public function __construct()
    {
        $this->db = Database::conectar();
    }

    public function verificarCorreo($correo)
    {
        $sql = "SELECT cCorreo FROM TUsuarioCliente WHERE cCorreo = :correo";
        $stmt = $this->db->prepare($sql);
        $stmt->bindParam(':correo', $correo);
        $stmt->execute();
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }

    public function crearUsuario($nombre, $apellido, $correo, $password, $telefono)
    {
        try {
            // Hashear la contraseña
            $passwordHash = password_hash($password, PASSWORD_BCRYPT);

            $sql = "INSERT INTO TUsuarioCliente (cNombre, cApellido, cCorreo, cContrasena, cTelefono)
                    VALUES (:nombre, :apellido, :correo, :password, :telefono)";

            $stmt = $this->db->prepare($sql);
            $stmt->bindParam(':nombre', $nombre);
            $stmt->bindParam(':apellido', $apellido);
            $stmt->bindParam(':correo', $correo);
            $stmt->bindParam(':password', $passwordHash);
            $stmt->bindParam(':telefono', $telefono);

            return $stmt->execute();
        } catch (PDOException $e) {
            throw new Exception("Error al crear usuario: " . $e->getMessage());
        }
    }
}
