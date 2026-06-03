#!/bin/bash

# Script para cambiar entre configuraciones local y producción

set -e

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

# Mostrar menú
print_header "Gestor de Configuración MVP"
echo "Selecciona el entorno:"
echo "1) Desarrollo Local (.env.local)"
echo "2) Producción (.env.production)"
echo "3) Ver configuración actual"
echo "4) Salir"
echo ""
read -p "Opción [1-4]: " choice

case $choice in
    1)
        print_header "Configurando para DESARROLLO LOCAL"
        
        # Detener contenedores si están en ejecución
        if [ "$(docker-compose ps -q 2>/dev/null)" ]; then
            print_warning "Deteniendo contenedores existentes..."
            docker-compose down
        fi
        
        print_success "Levantando contenedores con .env.local"
        docker-compose up -d
        
        print_success "Entorno local iniciado"
        echo ""
        echo "Acceder a:"
        echo "  PHP:        http://localhost:8000"
        echo "  C#:         http://localhost:5000"
        echo "  Android:    http://localhost:5037"
        echo "  PhpMyAdmin: http://localhost:8080"
        echo ""
        docker-compose ps
        ;;
    
    2)
        print_header "Configurando para PRODUCCIÓN"
        
        print_warning "IMPORTANTE: Asegúrate de haber editado .env.production"
        print_warning "con valores reales antes de continuar."
        echo ""
        read -p "¿Deseas continuar? (s/n): " confirm
        
        if [ "$confirm" != "s" ] && [ "$confirm" != "S" ]; then
            print_error "Operación cancelada"
            exit 1
        fi
        
        # Detener contenedores si están en ejecución
        if [ "$(docker-compose ps -q 2>/dev/null)" ]; then
            print_warning "Deteniendo contenedores existentes..."
            docker-compose --env-file .env.production down
        fi
        
        print_success "Levantando contenedores con .env.production"
        docker-compose --env-file .env.production up -d
        
        print_success "Entorno de producción iniciado"
        echo ""
        docker-compose --env-file .env.production ps
        ;;
    
    3)
        print_header "Verificando configuración"
        
        if [ -f "docker-compose.yml" ]; then
            echo "Variables de configuración actual:"
            echo ""
            echo "Desde .env.local:"
            grep "^[^#]" .env.local | sort
            echo ""
            echo "Desde .env.production:"
            grep "^[^#]" .env.production | sort
        else
            print_error "docker-compose.yml no encontrado"
        fi
        ;;
    
    4)
        echo "Saliendo..."
        exit 0
        ;;
    
    *)
        print_error "Opción no válida"
        exit 1
        ;;
esac

echo ""
