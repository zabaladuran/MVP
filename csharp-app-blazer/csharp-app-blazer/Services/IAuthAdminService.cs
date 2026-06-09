namespace csharp_app_blazer.Services
{
    public interface IAuthAdminService
    {
        Task<LoginResultado> LoginAsync(string correo, string password);
    }
}
