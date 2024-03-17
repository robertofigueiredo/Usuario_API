using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public Usuario BuscaUsuarioId(int id)
        {
            return _context.UsuarioAPI.Find(id);
        }
        public IEnumerable<Usuario> BuscaUsuarioAll()
        {
            return _context.UsuarioAPI.ToList();
        }

        public void Excluirusuario(Usuario usuario) 
        {
            _context.UsuarioAPI.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
