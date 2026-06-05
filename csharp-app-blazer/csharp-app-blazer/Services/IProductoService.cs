namespace csharp_app_blazer.Services
{
    public record ProductoDbItem(int Id, string Nombre, string Categoria, decimal Precio, int Stock);
    public record CategoriaFull(int Id, string Nombre);

    public interface IProductoService
    {
        Task<List<ProductoDbItem>> ObtenerProductosAsync(int tiendaId);
        Task<List<string>> ObtenerCategoriasAsync(int tiendaId);
        Task<List<CategoriaFull>> ObtenerCategoriasConIdAsync(int tiendaId);
        Task<int> CrearProductoAsync(int tiendaId, string nombre, int categoriaId, decimal precio, int stock);
        Task ActualizarProductoAsync(int productoId, string nombre, int categoriaId, decimal precio, int stock);
        Task EliminarProductoAsync(int productoId);
    }
}
