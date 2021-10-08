using curso.api.Domain.Entities;

namespace curso.api.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
