using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<Usuario> BuscaProdutoId(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Usuario> BuscaProdutoAll()
        {
            var busca = _context.UsuarioAPI.ToList();
            return busca;
        }
    }
}
