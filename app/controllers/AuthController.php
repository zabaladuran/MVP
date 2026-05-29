<?php
namespace App\Controllers;

use Firebase\JWT\JWT;

class AuthController{

    public function login(){
        $_SESSION['auth']=true;

        $payload=[
            'iat'=>time(),
            'exp'=>time()+3600,
            'user'=>'demo'
        ];

        $jwt = JWT::encode($payload, $_ENV['JWT_SECRET'],'HS256');

        echo json_encode([
            'session'=>'ok',
            'token'=>$jwt
        ]);
    }

    public function logout(){
        session_destroy();
        echo "logout ok";
    }
}