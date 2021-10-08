using curso.api.Domain.Entities;
using curso.api.Domain.Interfaces;
using curso.api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curso.api.Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _context;
        public CursoRepository(CursoDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int id)
        {
            return _context.Curso.Include(i => i.Usuario).Where(w => w.CodigoUsuario == id).ToList();
        }
    }
}
