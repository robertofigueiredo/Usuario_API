using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
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

        public ServiceResponse<Usuario> BuscaUsuarioPorId(int id)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();

            if (id == 0)
            {
                serviceResponse.Mensagem = "Id não pode ser 0";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            try
            {
                var usuario = _usuarioRepository.BuscaUsuarioId(id);
                if (usuario == null)
                {
                    serviceResponse.Mensagem = "Nenhum usuário foi localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = usuario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public ServiceResponse<List<Usuario>> BuscaUsuarioAll()
        {
            ServiceResponse<List<Usuario>> serviceResponse = new ServiceResponse<List<Usuario>>();

            try
            {
                serviceResponse.Dados = _usuarioRepository.BuscaUsuarioAll().ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public BaseRetorno IncluirUsuario(UsuarioAPIViewModel DadosAPI)
        {
            var RetornoService = new BaseRetorno();
            try
            {
                var NovoUsuario = new Usuario
                {
                    Id = DadosAPI.Id,
                    Nome = DadosAPI.Nome,
                    Sobrenome = DadosAPI.Sobrenome,
                    Ativo = DadosAPI.Ativo,
                    Departamento = DadosAPI.Departamento,
                    Turno = DadosAPI.Turno,
                    DataDeAlteracao = DateTime.Now.ToLocalTime(),
                    DataDeCriacao = DateTime.Now.ToLocalTime()
                };

                var VerificaExistenciaUsuario = _usuarioRepository.BuscaUsuarioId(DadosAPI.Id);
                if(VerificaExistenciaUsuario != null)
                {
                    RetornoService.Validacao = false;
                    RetornoService.MensagemResponse = "Já existe um usuário cadastro com o mesmo ID";
                    return RetornoService;
                }

                var InclusaoService = _usuarioRepository.IncluirUsuario(NovoUsuario);
                RetornoService.MensagemResponse = "Usuário incluido com sucesso";
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
            try
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
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public ServiceResponse<Usuario> AtualizaUsuario(UsuarioAPIViewModel usuario)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();
            try
            {
                var VerificaExiste = _usuarioRepository.BuscaUsuarioId(usuario.Id);
                if(VerificaExiste == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    return serviceResponse;
                }
                VerificaExiste.Turno = usuario.Turno;
                VerificaExiste.Departamento = usuario.Departamento;
                VerificaExiste.Nome = usuario.Nome;
                VerificaExiste.Sobrenome = usuario.Sobrenome;
                VerificaExiste.Ativo = usuario.Ativo;
                VerificaExiste.DataDeAlteracao = DateTime.Now.ToLocalTime();

                var UpdateRepository = _usuarioRepository.AtualizarUsuario(VerificaExiste);
                if (!UpdateRepository.Validacao)
                {
                    serviceResponse.Mensagem = UpdateRepository.MensagemResponse;
                    serviceResponse.Sucesso = UpdateRepository.Validacao;
                    return serviceResponse;
                }
                var NovoUsuario = _usuarioRepository.BuscaUsuarioId(usuario.Id);

                serviceResponse.Mensagem = "Usuário atualizado com sucesso!";
                serviceResponse.Sucesso = true;
                serviceResponse.Dados = NovoUsuario;
            }
            catch(Exception ex) 
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

    }
}
