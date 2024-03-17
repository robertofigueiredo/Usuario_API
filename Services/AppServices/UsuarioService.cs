using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System.Net.Http;
using Usuario_API.Models;

namespace Services.AppServices
{
    public class UsuarioService : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario BuscaUsuarioId(int id)
        {
            if (id == 0)
            {
                return null; 
            }

            try
            {
                return _usuarioRepository.BuscaUsuarioId(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao buscar o usuário por ID.", ex);
            }
        }

        public IEnumerable<Usuario> BuscaUsuarioAll()
        {
            return _usuarioRepository.BuscaUsuarioAll().ToList();
        }

        public BaseRetorno DeletaUsuario(int id)
        {
            var usuario = _usuarioRepository.BuscaUsuarioId(id);

            if (usuario == null)
            {
                return new BaseRetorno
                {
                    Sucesso = false,
                    MensagemResponse = "Usuário não encontrado!"
                };
            }

            _usuarioRepository.Excluirusuario(usuario);

            return new BaseRetorno
            {
                Sucesso = true,
                MensagemResponse = "Usuário excluído com sucesso"
            };
        }

    }
}
