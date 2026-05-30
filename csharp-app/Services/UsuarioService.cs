namespace csharp_app
{
    public class UsuarioService : IUsuarioService
    {
        public bool Autenticar(string nombre, string password)
        {
            return nombre == "admin" && password == "1234";
        }
    }
}
