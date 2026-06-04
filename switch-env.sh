#!/bin/bash

# Script para cambiar entre configuraciones local y producción

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

# Colores para output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

function print_header() {
    echo -e "\n${GREEN}========================================${NC}"
    echo -e "${GREEN}$1${NC}"
    echo -e "${GREEN}========================================${NC}\n"
}

function print_error() {
    echo -e "${RED}❌ Error: $1${NC}"
}

function print_success() {
    echo -e "${GREEN}✅ $1${NC}"
}

function print_warning() {
    echo -e "${YELLOW}⚠️  $1${NC}"
}

# Verificar que existen los archivos .env
if [ ! -f ".env.local" ]; then
    print_error ".env.local no encontrado"
    exit 1
fi

if [ ! -f ".env.production" ]; then
    print_error ".env.production no encontrado"
    exit 1
fi

while true; do
    print_header "Gestor de Configuración MVP"
    echo "Selecciona el entorno:"
    echo "1) Desarrollo Local (.env.local)"
    echo "2) Producción (.env.production)"
    echo "3) Ver configuración actual"
    echo "4) Ver logs en tiempo real"
    echo "5) Detener contenedores"
    echo "6) Eliminar contenedores"
    echo "7) Salir"
    echo ""
    read -p "Opción [1-7]: " choice

    case $choice in
        1)
            print_header "Configurando para DESARROLLO LOCAL"

            if [ "$(docker compose ps -q 2>/dev/null)" ]; then
                print_warning "Deteniendo contenedores existentes..."
                docker compose down
            fi

            print_success "Levantando contenedores con .env.local"
            docker compose up -d

            print_success "Entorno local iniciado"
            echo ""
            echo "Acceder a:"
            echo "  PHP:        http://localhost:8000"
            echo "  C# Blazor:  http://localhost:5010"
            echo "  Android:    http://localhost:5037"
            echo "  PhpMyAdmin: http://localhost:8080"
            echo ""
            docker compose ps
            ;;

        2)
            print_header "Configurando para PRODUCCIÓN"

            print_warning "IMPORTANTE: Asegúrate de haber editado .env.production"
            print_warning "con valores reales antes de continuar."
            echo ""
            read -p "¿Deseas continuar? (s/n): " confirm

            if [ "$confirm" != "s" ] && [ "$confirm" != "S" ]; then
                print_error "Operación cancelada"
                continue
            fi

            if [ "$(docker compose ps -q 2>/dev/null)" ]; then
                print_warning "Deteniendo contenedores existentes..."
                docker compose --env-file .env.production down
            fi

            print_success "Levantando contenedores con .env.production"
            docker compose --env-file .env.production up -d

            print_success "Entorno de producción iniciado"
            echo ""
            docker compose --env-file .env.production ps
            ;;

        3)
            print_header "Verificando configuración"

            echo "Variables de configuración actual:"
            echo ""
            echo "Desde .env.local:"
            grep "^[^#]" .env.local | sort
            echo ""
            echo "Desde .env.production:"
            grep "^[^#]" .env.production | sort
            ;;

        4)
            print_header "Logs en tiempo real"

            read -p "¿De qué entorno? (local/production): " env

            if [ "$env" = "production" ]; then
                docker compose --env-file .env.production logs -f
            else
                docker compose logs -f
            fi
            ;;

        5)
            print_header "Deteniendo contenedores"

            if [ "$(docker compose ps -q 2>/dev/null)" ]; then
                print_warning "Deteniendo todos los contenedores..."
                docker compose down
                print_success "Contenedores detenidos"
            else
                print_warning "No hay contenedores en ejecución"
            fi
            ;;

        6)
            print_header "Eliminando contenedores"

            if [ "$(docker compose ps -q 2>/dev/null)" ]; then
                print_warning "Deteniendo y eliminando contenedores..."
                docker compose down
            fi

            if [ "$(docker compose ps -aq 2>/dev/null)" ]; then
                docker compose rm -f
            fi

            print_success "Contenedores eliminados"

            read -p "¿Eliminar también los volúmenes (datos de BD)? (s/n): " removeVolumes
            if [ "$removeVolumes" = "s" ] || [ "$removeVolumes" = "S" ]; then
                docker compose down -v
                print_success "Volúmenes eliminados"
            fi
            ;;

        7)
            echo "Saliendo..."
            exit 0
            ;;

        *)
            print_error "Opción no válida"
            ;;
    esac

    echo ""
    read -p "Presiona Enter para volver al menú..."
done
