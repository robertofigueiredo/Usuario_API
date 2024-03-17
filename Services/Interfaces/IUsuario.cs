using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> BuscaProdutoId(int id);
        IEnumerable<Usuario> BuscaProdutoAll();
    }
}
