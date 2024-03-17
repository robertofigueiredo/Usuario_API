using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario_API.Models;

namespace Services.Interfaces
{
    public interface IUsuarioServices
    {
        Usuario BuscaUsuarioId(int id);
        IEnumerable<Usuario> BuscaUsuarioAll();
        BaseRetorno DeletaUsuario(int id);
    }
}
