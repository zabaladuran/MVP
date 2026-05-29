<?php
require_once __DIR__.'/../vendor/autoload.php';

use Dotenv\Dotenv;

$dotenv = Dotenv::createImmutable(__DIR__.'/..');
$dotenv->safeLoad();

session_start();

$url = strtolower($_GET['url'] ?? 'home');
$action = $_GET['accion'] ?? 'index';

$class = "App\\Controllers\\".ucfirst($url)."Controller";
$file = __DIR__."/../app/controllers/".ucfirst($url)."Controller.php";

if(!file_exists($file)){ http_response_code(404); exit("404"); }

require_once $file;

$c = new $class();

if(!method_exists($c,$action)){ http_response_code(404); exit("404 action"); }

$c->$action();