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

        [HttpGet("BuscausuarioId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Usuario> BuscausuarioId(int id)
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

        [HttpGet("BuscaUsuarioAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Usuario>> BuscaUsuarioAll()
        {
            var BuscaId = _usuarioService.BuscaUsuarioAll().ToList();
            return Ok(BuscaId);
        }

        [HttpDelete("DeletaUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletaUsuario(int id)
        {
            var resultado = _usuarioService.DeletaUsuario(id);

            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.MensagemResponse);
            }

            return NoContent();
        }
    }
}
