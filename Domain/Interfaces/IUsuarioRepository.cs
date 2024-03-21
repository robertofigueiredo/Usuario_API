using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario_API.Models;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscaUsuarioId(int id);
        IEnumerable<Usuario> BuscaUsuarioAll();
        void Excluirusuario(Usuario DadosUsuario);
        BaseRetorno IncluirUsuario(Usuario usuario);
        BaseRetorno AtualizarUsuario(Usuario usuario);
    }
}
