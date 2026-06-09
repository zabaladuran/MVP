# Script para cambiar entre configuraciones local y producción (PowerShell)

function Print-Header {
    param([string]$Text)

    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host $Text -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
}

function Print-Error {
    param([string]$Text)
    Write-Host "ERROR: $Text" -ForegroundColor Red
}

function Print-Success {
    param([string]$Text)
    Write-Host "OK: $Text" -ForegroundColor Green
}

function Print-Warning {
    param([string]$Text)
    Write-Host "WARNING: $Text" -ForegroundColor Yellow
}

# Verificar que existen los archivos .env
if (-not (Test-Path ".env.local")) {
    Print-Error ".env.local no encontrado"
    exit 1
}

if (-not (Test-Path ".env.production")) {
    Print-Error ".env.production no encontrado"
    exit 1
}

do {

    Print-Header "Gestor de Configuracion MVP"

    Write-Host "Selecciona el entorno:"
    Write-Host "1) Desarrollo Local (.env.local)"
    Write-Host "2) Produccion (.env.production)"
    Write-Host "3) Ver configuracion actual"
    Write-Host "4) Ver logs en tiempo real"
    Write-Host "5) Detener contenedores"
    Write-Host "6) Eliminar contenedores"
    Write-Host "7) Eliminar imagenes Docker (forza reconstruccion completa)"
    Write-Host "8) Salir"
    Write-Host ""
 
    $choice = Read-Host "Opcion [1-8]"

    switch ($choice) {

        "1" {

            Print-Header "Configurando para DESARROLLO LOCAL"

            $containers = docker compose --env-file .env.local ps -q 2>$null

            if ($containers) {
                Print-Warning "Deteniendo contenedores existentes..."
                docker compose --env-file .env.local down
            }

            Print-Success "Levantando contenedores con .env.local"
            docker compose --env-file .env.local up -d --build

            Print-Success "Entorno local iniciado"

            Write-Host ""
            Write-Host "Acceder a:"
            Write-Host "  PHP:        http://localhost:8000"
            Write-Host "  C# Blazor:  http://localhost:5010"
            Write-Host "  Android:    http://localhost:5037"
            Write-Host "  PhpMyAdmin: http://localhost:8080"
            Write-Host ""

            docker compose --env-file .env.local ps
        }

        "2" {

            Print-Header "Configurando para PRODUCCION"

            Print-Warning "IMPORTANTE: Asegurate de haber editado .env.production"
            Print-Warning "con valores reales antes de continuar."

            Write-Host ""

            $confirm = Read-Host "Deseas continuar? (s/n)"

            if ($confirm -ne "s" -and $confirm -ne "S") {
                Print-Error "Operacion cancelada"
                continue
            }

            $containers = docker compose ps -q 2>$null

            if ($containers) {
                Print-Warning "Deteniendo contenedores existentes..."
                docker compose --env-file .env.production down
            }

            Print-Success "Levantando contenedores con .env.production"
            docker compose --env-file .env.production up -d --build

            Print-Success "Entorno de produccion iniciado"

            Write-Host ""

            docker compose --env-file .env.production ps
        }

        "3" {

            Print-Header "Verificando configuracion"

            Write-Host "Variables en .env.local:" -ForegroundColor Cyan
            Write-Host ""

            Get-Content .env.local |
                Where-Object { $_ -notmatch "^#" -and $_ -ne "" } |
                Sort-Object

            Write-Host ""
            Write-Host "Variables en .env.production:" -ForegroundColor Cyan
            Write-Host ""

            Get-Content .env.production |
                Where-Object { $_ -notmatch "^#" -and $_ -ne "" } |
                Sort-Object
        }

        "4" {

            Print-Header "Logs en tiempo real"

            $environment = Read-Host "De que entorno? (local/production)"

            if ($environment -eq "production") {
                docker compose --env-file .env.production logs -f
            }
            else {
                docker compose --env-file .env.local logs -f
            }
        }

        "5" {

            Print-Header "Deteniendo contenedores"

            $containers = docker compose ps -q 2>$null

            if ($containers) {
                Print-Warning "Deteniendo todos los contenedores..."
                docker compose down
                Print-Success "Contenedores detenidos"
            }
            else {
                Print-Warning "No hay contenedores en ejecucion"
            }
        }

        "6" {

            Print-Header "Eliminando contenedores"

            $containers = docker compose ps -q 2>$null

            if ($containers) {
                Print-Warning "Deteniendo y eliminando contenedores..."
                docker compose down
            }

            $stopped = docker compose ps -aq 2>$null

            if ($stopped) {
                docker compose rm -f
            }

            Print-Success "Contenedores eliminados"

            $removeVolumes = Read-Host "Eliminar tambien los volumenes (datos de BD)? (s/n)"

            if ($removeVolumes -eq "s" -or $removeVolumes -eq "S") {
                docker compose down -v
                Print-Success "Volumenes eliminados"
            }
        }

        "7" {

            Print-Header "Eliminando imagenes Docker"

            $confirm = Read-Host "Esto eliminara TODAS las imagenes del proyecto. Continuar? (s/n)"

            if ($confirm -ne "s" -and $confirm -ne "S") {
                Print-Error "Operacion cancelada"
                continue
            }

            docker compose down -v --rmi all
            Print-Success "Contenedores, volumenes e imagenes eliminados"

            Write-Host ""
            Write-Host "Para reconstruir y arrancar de nuevo, usa la opcion 1 o 2." -ForegroundColor Yellow
        }

        "8" {
            Write-Host "Saliendo..."
        }

        default {

            Print-Error "Opcion no valida"

            Write-Host ""
            Write-Host "Presiona Enter para continuar..." -NoNewline

            $null = Read-Host
        }
    }

    if ($choice -ne "8") {
        Write-Host ""
        Write-Host "Presiona Enter para volver al menu..." -NoNewline
        $null = Read-Host
    }

} while ($choice -ne "7")
