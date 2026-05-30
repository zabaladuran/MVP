namespace csharp_app
{
    public interface IUsuarioService
    {
        bool Autenticar(string nombre, string password);
    }
}