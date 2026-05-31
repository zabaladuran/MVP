using System;
using System.Collections.Generic;
using csharp_app.Models;

namespace csharp_app.Services
{
    public class StoreService : IStoreService
    {
        public IEnumerable<Tienda> ObtenerTiendas()
        {
            return new List<Tienda>
            {
                new Tienda
                {
                    Id = 1,
                    NombreComercial = "Mi Tienda Central",
                    Descripcion = "Tienda principal con catálogo amplio y productos destacados.",
                    CorreoAtencion = "contacto@mitienda.com",
                    TelefonoAtencion = "+57 300 123 4567",
                    RazonSocial = "Mi Tienda S.A.S.",
                    Direccion = "Calle 123 #45-67, Bogotá",
                    CodigoPostal = "110111",
                    EstadoTienda = "Activa",
                    FechaVencimientoSuscripcion = DateTime.Today.AddDays(38),
                    PlanId = 2,
                    UrlLogo = string.Empty
                },
                new Tienda
                {
                    Id = 2,
                    NombreComercial = "Sucursal Norte",
                    Descripcion = "Sucursal con alto volumen de ventas y servicios de despacho rápido.",
                    CorreoAtencion = "norte@mitienda.com",
                    TelefonoAtencion = "+57 310 987 6543",
                    RazonSocial = "Mi Tienda Norte S.A.S.",
                    Direccion = "Av. Norte 40 #20-10, Bogotá",
                    CodigoPostal = "110222",
                    EstadoTienda = "Pendiente",
                    FechaVencimientoSuscripcion = DateTime.Today.AddDays(5),
                    PlanId = 1,
                    UrlLogo = string.Empty
                },
                new Tienda
                {
                    Id = 3,
                    NombreComercial = "Tienda Express",
                    Descripcion = "Local pequeño orientado a compras rápidas y atención al cliente.",
                    CorreoAtencion = "express@mitienda.com",
                    TelefonoAtencion = "+57 315 555 1212",
                    RazonSocial = "Mi Tienda Express S.A.S.",
                    Direccion = "Calle 80 #12-45, Bogotá",
                    CodigoPostal = "110333",
                    EstadoTienda = "Inactiva",
                    FechaVencimientoSuscripcion = DateTime.Today.AddDays(-2),
                    PlanId = 3,
                    UrlLogo = string.Empty
                }
            };
        }
    }
}