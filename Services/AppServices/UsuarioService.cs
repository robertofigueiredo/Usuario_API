using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public BaseRetorno IncluirUsuario(Usuario usuario)
        {
            var RetornoService = new BaseRetorno();
            try
            {
                var VerificaExistenciaUsuario = _usuarioRepository.BuscaUsuarioId(usuario.Id);
                if(VerificaExistenciaUsuario != null)
                {
                    RetornoService.Validacao = false;
                    RetornoService.MensagemResponse = "Já existe um usuário cadastro com o mesmo ID";
                    return RetornoService;
                }

                var InclusaoService = _usuarioRepository.IncluirUsuario(usuario);
                RetornoService.Validacao = true;
            }
            catch(Exception ex)
            {
                RetornoService.Validacao = false;
                RetornoService.MensagemResponse = ex.Message;
                throw ex;
            }
            return RetornoService;
        }

        public BaseRetorno DeletaUsuario(int id)
        {
            var usuario = _usuarioRepository.BuscaUsuarioId(id);

            if (usuario == null)
            {
                return new BaseRetorno
                {
                    Validacao = false,
                    MensagemResponse = "Usuário não encontrado!"
                };
            }

            _usuarioRepository.Excluirusuario(usuario);

            return new BaseRetorno
            {
                Validacao = true,
                MensagemResponse = "Usuário excluído com sucesso"
            };
        }

    }
}
