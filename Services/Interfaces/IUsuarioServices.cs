using Domain.Models;
using Usuario_API.Models;

namespace Services.Interfaces
{
    public interface IUsuarioServices
    {
        ServiceResponse<Usuario> BuscaUsuarioPorId(int id);
        ServiceResponse<List<Usuario>> BuscaUsuarioAll();
        BaseRetorno DeletaUsuario(int id);
        BaseRetorno IncluirUsuario(UsuarioAPIViewModel usuario);
        ServiceResponse<Usuario> AtualizaUsuario(UsuarioAPIViewModel usuario);
    }
}
