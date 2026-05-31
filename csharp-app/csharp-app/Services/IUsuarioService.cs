namespace csharp_app.Services
{
    public interface IUsuarioService
    {
        bool Autenticar(string nombre, string password);
    }
}