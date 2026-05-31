using System.Collections.Generic;
using csharp_app.Models;

namespace csharp_app.Services
{
    public interface IStoreService
    {
        IEnumerable<Tienda> ObtenerTiendas();
    }
}