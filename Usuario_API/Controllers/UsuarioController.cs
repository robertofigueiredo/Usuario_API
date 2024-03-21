using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Usuario_API.Models;

namespace Usuario_API.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioService;
        public UsuarioController(IUsuarioServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("BuscaUsuarioId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPIViewModel> BuscaUsuarioId(int id)
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

        [HttpGet("BuscaTodosUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<UsuarioAPIViewModel>> BuscaTodosUsuario()
        {
            var BuscaId = _usuarioService.BuscaUsuarioAll().ToList();
            return Ok(BuscaId);
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

        [HttpDelete("DeletaUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletaUsuario(int id)
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
