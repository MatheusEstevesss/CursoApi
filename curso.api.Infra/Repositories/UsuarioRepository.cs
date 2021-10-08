﻿using curso.api.Domain.Entities;
using curso.api.Domain.Interfaces;
using curso.api.Infra.Data;
using System.Linq;

namespace curso.api.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _context;

        public UsuarioRepository(CursoDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);            
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _context.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
