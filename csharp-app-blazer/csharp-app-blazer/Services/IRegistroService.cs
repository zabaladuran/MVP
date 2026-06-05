using csharp_app_blazer.Models;

namespace csharp_app_blazer.Services
{
    public interface IRegistroService
    {
        Task<RegistroResultado> RegistrarAdministrador(RegisterViewModel model);
        Task<List<DepartamentoInfo>> ObtenerDepartamentos();
        Task<List<MunicipioInfo>> ObtenerMunicipios(int departamentoId);
    }

    public class RegistroResultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }

    public class DepartamentoInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class MunicipioInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
    }
}
