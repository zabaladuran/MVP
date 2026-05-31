namespace csharp_app.Services
{
    public class UsuarioService : IUsuarioService
    {
        public bool Autenticar(string nombre, string password)
        {
            return nombre == "admin" && password == "1234";
        }
    }
}
