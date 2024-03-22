using Domain.Models;
using Usuario_API.Models;

namespace Services.Interfaces
{
    public interface IUsuarioServices
    {
        Usuario BuscaUsuarioId(int id);
        ServiceResponse<List<Usuario>> BuscaUsuarioAll();
        BaseRetorno DeletaUsuario(int id);
        BaseRetorno IncluirUsuario(UsuarioAPIViewModel usuario);
        BaseRetorno AtualizaUsuario(UsuarioAPIViewModel usuario);
    }
}
