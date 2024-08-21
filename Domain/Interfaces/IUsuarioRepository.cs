using Domain.Models;
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
