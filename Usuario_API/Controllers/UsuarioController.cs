using Domain.Models;
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

        [HttpGet("BuscarTodosUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<IEnumerable<UsuarioAPIViewModel>>> BuscarTodosUsuario()
        {
            return Ok(_usuarioService.BuscaUsuarioAll());
        }

        [HttpGet("BuscarUsuarioId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPIViewModel> BuscarUsuarioId(int id)
        {
            try
            {
                var usuario = _usuarioService.BuscaUsuarioId(id);

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


        [HttpPost("IncluirUsuario")]
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

        [HttpPut("AtualizarUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPIViewModel> AtualizarUsuario([FromBody] UsuarioAPIViewModel usuario)
        {
            try
            {
                var ResponseServiceUpdate = _usuarioService.AtualizaUsuario(usuario);
                if (!ResponseServiceUpdate.Validacao)
                {
                    return BadRequest(ResponseServiceUpdate.MensagemResponse);
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletarUsuario(int id)
        {
            try
            {
                var resultado = _usuarioService.DeletaUsuario(id);

                if (!resultado.Validacao)
                {
                    return BadRequest(resultado.MensagemResponse);
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500,"Ocorreu um erro interno na api");
            }
        }
    }
}
