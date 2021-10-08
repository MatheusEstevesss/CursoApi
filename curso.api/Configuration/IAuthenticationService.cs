using curso.api.Models.Usuarios;

namespace curso.api.Configuration
{
    public interface IAuthenticationService
    {
        public string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
