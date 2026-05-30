<?php

require_once __DIR__ . '/../database/conexion.php';

class Usuario
{
    private $db;

    public function __construct()
    {
        $this->db = Database::conectar();
    }

    public function obtenerPorCorreo($correo)
    {
        $sql = "SELECT * FROM TUsuarioCliente
                WHERE cCorreo = :correo";

        $stmt = $this->db->prepare($sql);

        $stmt->bindParam(':correo', $correo);

        $stmt->execute();

        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
}