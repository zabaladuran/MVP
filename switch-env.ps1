# Script para cambiar entre configuraciones local y producción (PowerShell)

function Print-Header {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host $args[0] -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
}

function Print-Error {
    Write-Host "❌ Error: $($args[0])" -ForegroundColor Red
}

function Print-Success {
    Write-Host "✅ $($args[0])" -ForegroundColor Green
}

function Print-Warning {
    Write-Host "⚠️  $($args[0])" -ForegroundColor Yellow
}

# Verificar que existen los archivos .env
if (-Not (Test-Path ".env.local")) {
    Print-Error ".env.local no encontrado"
    exit 1
}

if (-Not (Test-Path ".env.production")) {
    Print-Error ".env.production no encontrado"
    exit 1
}

# Mostrar menú
Print-Header "Gestor de Configuración MVP"
Write-Host "Selecciona el entorno:"
Write-Host "1) Desarrollo Local (.env.local)"
Write-Host "2) Producción (.env.production)"
Write-Host "3) Ver configuración actual"
Write-Host "4) Ver logs en tiempo real"
Write-Host "5) Detener contenedores"
Write-Host "6) Salir"
Write-Host ""
$choice = Read-Host "Opción [1-6]"

switch ($choice) {
    "1" {
        Print-Header "Configurando para DESARROLLO LOCAL"
        
        # Verificar si hay contenedores en ejecución
        $containers = docker-compose ps -q 2>$null
        if ($containers) {
            Print-Warning "Deteniendo contenedores existentes..."
            docker-compose down
        }
        
        Print-Success "Levantando contenedores con .env.local"
        docker-compose up -d
        
        Print-Success "Entorno local iniciado"
        Write-Host ""
        Write-Host "Acceder a:"
        Write-Host "  PHP:        http://localhost:8000"
        Write-Host "  C#:         http://localhost:5000"
        Write-Host "  Android:    http://localhost:5037"
        Write-Host "  PhpMyAdmin: http://localhost:8080"
        Write-Host ""
        docker-compose ps
    }
    
    "2" {
        Print-Header "Configurando para PRODUCCIÓN"
        
        Print-Warning "IMPORTANTE: Asegúrate de haber editado .env.production"
        Print-Warning "con valores reales antes de continuar."
        Write-Host ""
        $confirm = Read-Host "¿Deseas continuar? (s/n)"
        
        if ($confirm -ne "s" -And $confirm -ne "S") {
            Print-Error "Operación cancelada"
            exit 1
        }
        
        # Verificar si hay contenedores en ejecución
        $containers = docker-compose ps -q 2>$null
        if ($containers) {
            Print-Warning "Deteniendo contenedores existentes..."
            docker-compose --env-file .env.production down
        }
        
        Print-Success "Levantando contenedores con .env.production"
        docker-compose --env-file .env.production up -d
        
        Print-Success "Entorno de producción iniciado"
        Write-Host ""
        docker-compose --env-file .env.production ps
    }
    
    "3" {
        Print-Header "Verificando configuración"
        
        Write-Host "Variables en .env.local:" -ForegroundColor Cyan
        Write-Host ""
        Get-Content .env.local | Where-Object {$_ -notmatch "^#" -And $_ -ne ""} | Sort-Object
        
        Write-Host ""
        Write-Host "Variables en .env.production:" -ForegroundColor Cyan
        Write-Host ""
        Get-Content .env.production | Where-Object {$_ -notmatch "^#" -And $_ -ne ""} | Sort-Object
    }
    
    "4" {
        Print-Header "Logs en tiempo real"
        
        $env = Read-Host "¿De qué entorno? (local/production)"
        
        if ($env -eq "production") {
            docker-compose --env-file .env.production logs -f
        } else {
            docker-compose logs -f
        }
    }
    
    "5" {
        Print-Header "Deteniendo contenedores"
        
        $containers = docker-compose ps -q 2>$null
        if ($containers) {
            Print-Warning "Deteniendo todos los contenedores..."
            docker-compose down
            Print-Success "Contenedores detenidos"
        } else {
            Print-Warning "No hay contenedores en ejecución"
        }
    }
    
    "6" {
        Write-Host "Saliendo..."
        exit 0
    }
    
    default {
        Print-Error "Opción no válida"
        exit 1
    }
}

Write-Host ""
