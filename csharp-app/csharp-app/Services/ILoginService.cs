namespace csharp_app.Services
{
    public interface ILoginService
    {
        bool Autenticar(string nombre, string password);
    }
}