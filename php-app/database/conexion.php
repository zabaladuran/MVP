<?php

$configPath = __DIR__ . '/configLink.php';
if (!file_exists($configPath)) {
    die("Error: Archivo configLink.php no encontrado en: " . $configPath);
}
require_once $configPath;

if (!defined('DB_HOST')) {
    die("Error: Constantes de base de datos no definidas. Verifica configLink.php");
}

class Database
{
    private static $conexion = null;

    public static function conectar()
    {
        if (self::$conexion === null) {

            try {

                $dsn = "mysql:host=" . DB_HOST .
                       ";dbname=" . DB_NAME .
                       ";charset=utf8mb4";

                self::$conexion = new PDO(
                    $dsn,
                    DB_USER,
                    DB_PASS
                );

                self::$conexion->setAttribute(
                    PDO::ATTR_ERRMODE,
                    PDO::ERRMODE_EXCEPTION
                );

                self::$conexion->setAttribute(
                    PDO::ATTR_DEFAULT_FETCH_MODE,
                    PDO::FETCH_ASSOC
                );

            } catch (PDOException $e) {

                die("Error de conexión: " . $e->getMessage());
            }
        }

        return self::$conexion;
    }
}