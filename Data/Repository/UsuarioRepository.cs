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
        public UsuarioRepository()
        {
            
        }

        public IEnumerable<Usuario> BuscaProdutoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
