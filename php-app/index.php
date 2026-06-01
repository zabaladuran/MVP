<?php

session_start();

if (isset($_SESSION['usuario_id']) && !isset($_GET['vista'])) {
    header('Location: index.php?vista=home');
    exit;
}

require_once 'Router.php';