using Domain.Models;
using Usuario_API.Models;

namespace Services.Interfaces
{
    public interface IUsuarioServices
    {
        Usuario BuscaUsuarioId(int id);
        IEnumerable<Usuario> BuscaUsuarioAll();
        BaseRetorno DeletaUsuario(int id);
        BaseRetorno IncluirUsuario(UsuarioAPIViewModel usuario);
    }
}
