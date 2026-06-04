// Models/ProductoItem.cs
namespace csharp_app_blazer.Models
{
    public record ProductoItem(int Id, string Nombre, string Categoria, decimal Precio, int Stock);
    public record MetricaItem(string Titulo, decimal Valor, string Subtitulo);
}