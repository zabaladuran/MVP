using csharp_app_blazer.Data;
using MySql.Data.MySqlClient;

namespace csharp_app_blazer.Services
{
    public class ProductoService : IProductoService
    {
        private readonly DbConnectionFactory _db;

        public ProductoService(DbConnectionFactory db)
        {
            _db = db;
        }

        public async Task<List<ProductoDbItem>> ObtenerProductosAsync(int tiendaId)
        {
            var productos = new List<ProductoDbItem>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                SELECT p.nProductoID, p.cDescripcionCorta, cat.cNombreCategoria, p.nPrecioUnitario, p.nCantidadStock
                FROM TProductos p
                INNER JOIN TCategoria cat ON p.nCategoriaFK = cat.nCategoriaID
                WHERE p.nTiendaFK = @id
                ORDER BY p.nProductoID", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                productos.Add(new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(4)));
            return productos;
        }

        public async Task<List<CategoriaFull>> ObtenerCategoriasConIdAsync(int tiendaId)
        {
            var result = new List<CategoriaFull>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                SELECT DISTINCT cat.nCategoriaID, cat.cNombreCategoria
                FROM TProductos p
                INNER JOIN TCategoria cat ON p.nCategoriaFK = cat.nCategoriaID
                WHERE p.nTiendaFK = @id", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                result.Add(new(reader.GetInt32(0), reader.GetString(1)));
            return result;
        }

        public async Task<List<string>> ObtenerCategoriasAsync(int tiendaId)
        {
            var categorias = new List<string>();
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                SELECT DISTINCT cat.cNombreCategoria
                FROM TProductos p
                INNER JOIN TCategoria cat ON p.nCategoriaFK = cat.nCategoriaID
                WHERE p.nTiendaFK = @id
                ORDER BY cat.cNombreCategoria", conn);
            cmd.Parameters.AddWithValue("@id", tiendaId);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                categorias.Add(reader.GetString(0));
            return categorias;
        }

        public async Task<int> CrearProductoAsync(int tiendaId, string nombre, int categoriaId, decimal precio, int stock)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                INSERT INTO TProductos (nTiendaFK, cDescripcionCorta, cDescripcionLarga, nCategoriaFK, nPrecioUnitario, nCantidadStock)
                VALUES (@tienda, @nombre, @nombre, @cat, @precio, @stock);
                SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@tienda", tiendaId);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@cat", categoriaId);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@stock", stock);
            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task ActualizarProductoAsync(int productoId, string nombre, int categoriaId, decimal precio, int stock)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand(@"
                UPDATE TProductos
                SET cDescripcionCorta = @nombre, nCategoriaFK = @cat, nPrecioUnitario = @precio, nCantidadStock = @stock
                WHERE nProductoID = @id", conn);
            cmd.Parameters.AddWithValue("@id", productoId);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@cat", categoriaId);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@stock", stock);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task EliminarProductoAsync(int productoId)
        {
            using var conn = _db.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new MySqlCommand("DELETE FROM TProductos WHERE nProductoID = @id", conn);
            cmd.Parameters.AddWithValue("@id", productoId);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
