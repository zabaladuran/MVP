<?php

require_once __DIR__ . '/../database/conexion.php';

class HomeModel
{
    private $db;

    public function __construct()
    {
        $this->db = Database::conectar();
    }

    public function obtenerUsuarioPorId($id)
    {
        $sql = "SELECT
                    nUsuarioClienteID,
                    cNombre,
                    cApellido,
                    cCorreo
                FROM TUsuarioCliente
                WHERE nUsuarioClienteID = :id";

        $stmt = $this->db->prepare($sql);

        $stmt->bindParam(':id', $id);

        $stmt->execute();

        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
}