namespace csharp_app.Services
{
    public class LoginService : ILoginService
    {
        public bool Autenticar(string nombre, string password)
        {
            return nombre == "admin" && password == "1234";
        }
    }
}
