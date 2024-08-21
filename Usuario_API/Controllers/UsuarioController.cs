using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Usuario_API.Models;

namespace Usuario_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioService;
        public UsuarioController(IUsuarioServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("GetAllUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<IEnumerable<UsuarioAPIViewModel>>> BuscarTodosUsuario()
        {
            return Ok(_usuarioService.BuscaUsuarioAll());
        }

        [HttpGet("GetIdUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<IEnumerable<UsuarioAPIViewModel>>> BuscarUsuarioId(int id)
        {
            try
            {
                var usuario = _usuarioService.BuscaUsuarioPorId(id);

                if (usuario is null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(usuario);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost("CreateUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPIViewModel> IncluirUsuario([FromBody] UsuarioAPIViewModel DadosAPI)
        {
           
            try
            {
                var retornoInclusao = _usuarioService.IncluirUsuario(DadosAPI);
                if (!retornoInclusao.Validacao)
                {
                    return BadRequest(retornoInclusao.MensagemResponse);
                }

                return StatusCode(201, retornoInclusao.MensagemResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro interno no servidor. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<IEnumerable<UsuarioAPIViewModel>>> UpdateUsuario([FromBody] UsuarioAPIViewModel usuario)
        {
            try
            {
                var ResponseServiceUpdate = _usuarioService.AtualizaUsuario(usuario);
                if (!ResponseServiceUpdate.Sucesso)
                {
                    return BadRequest(ResponseServiceUpdate.Mensagem);
                }
                return Ok(ResponseServiceUpdate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<IEnumerable<UsuarioAPIViewModel>>> DeletarUsuario(int id)
        {
            try
            {
                var resultado = _usuarioService.DeletaUsuario(id);

                return Ok(resultado);
            }
            catch(Exception ex)
            {
                return StatusCode(500,"Ocorreu um erro interno na api");
            }
        }
    }
}
