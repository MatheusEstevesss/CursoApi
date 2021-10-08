using curso.api.Domain.Entities;
using System.Collections.Generic;

namespace curso.api.Domain.Interfaces
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();
        IList<Curso> ObterPorUsuario(int id);
    }
}
