<?php

require_once __DIR__ . '/../database/conexion.php';

class ProductModel
{
    private $db;

    public function __construct()
    {
        $this->db = Database::conectar();
    }

    public function obtenerProductos($categoria = null, $busqueda = '')
    {
        $sql = "SELECT p.*, c.cNombreCategoria
                FROM TProductos p
                LEFT JOIN TCategoria c ON p.nCategoriaFK = c.nCategoriaID
                WHERE 1 = 1";

        $params = [];

        if (!empty($categoria) && is_numeric($categoria)) {
            $sql .= " AND p.nCategoriaFK = :categoria";
            $params[':categoria'] = $categoria;
        }

        if (!empty($busqueda)) {
            $sql .= " AND (
                        p.cDescripcionCorta LIKE :busqueda OR
                        p.cDescripcionLarga LIKE :busqueda
                     )";
            $params[':busqueda'] = '%' . $busqueda . '%';
        }

        $sql .= " ORDER BY COALESCE(p.cNombreProducto, p.cDescripcionCorta) ASC";

        $stmt = $this->db->prepare($sql);

        foreach ($params as $key => $value) {
            $stmt->bindValue($key, $value);
        }

        $stmt->execute();

        $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);

        // Decodificar JSON de especificaciones si existe
        foreach ($rows as &$row) {
            if (!empty($row['jEspecificaciones'])) {
                $decoded = json_decode($row['jEspecificaciones'], true);
                $row['especificaciones'] = $decoded ?: [];
            } else {
                $row['especificaciones'] = [];
            }
        }

        return $rows;
    }

    public function obtenerCategorias()
    {
        $sql = "SELECT nCategoriaID, cNombreCategoria
                FROM TCategoria
                ORDER BY cNombreCategoria ASC";

        $stmt = $this->db->prepare($sql);
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function obtenerProductoPorId($id)
    {
        if (!is_numeric($id)) {
            return null;
        }

        $sql = "SELECT p.*, c.cNombreCategoria
                FROM TProductos p
                LEFT JOIN TCategoria c ON p.nCategoriaFK = c.nCategoriaID
                WHERE p.nProductoID = :id";

        $stmt = $this->db->prepare($sql);
        $stmt->bindParam(':id', $id, PDO::PARAM_INT);
        $stmt->execute();

        $row = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($row) {
            if (!empty($row['jEspecificaciones'])) {
                $decoded = json_decode($row['jEspecificaciones'], true);
                $row['especificaciones'] = $decoded ?: [];
            } else {
                $row['especificaciones'] = [];
            }
        }

        return $row;
    }
}
