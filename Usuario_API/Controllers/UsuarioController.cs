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

        [HttpGet("BuscausuarioId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPI> BuscausuarioId(int id)
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
        public ActionResult<IEnumerable<UsuarioAPI>> BuscaTodosUsuario()
        {
            var BuscaId = _usuarioService.BuscaUsuarioAll().ToList();
            return Ok(BuscaId);
        }

        [HttpPost("IncluirUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioAPI> IncluirUsuario([FromBody] UsuarioAPI DadosAPI)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Ocorreu um erro durante sua solicitação",
                    Detail = "Os Parametros fornecidos são invalidos"
                });
            }

            var UsuarioService = new Usuario
            {
                Id = DadosAPI.Id,
                Nome = DadosAPI.Nome, 
                Sobrenome = DadosAPI.Sobrenome,
                Ativo = DadosAPI.Ativo,
                DataDeAlteracao = DateTime.Now,
                DataDeCriacao = DateTime.Now,   
            };
            var RetornoInclusao = _usuarioService.IncluirUsuario(UsuarioService);
            if (!RetornoInclusao.Validacao)
            {
                return BadRequest(RetornoInclusao.MensagemResponse);
            }
            return StatusCode(201, RetornoInclusao.MensagemResponse);
        }

        [HttpDelete("DeletaUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletaUsuario(int id)
        {
            var resultado = _usuarioService.DeletaUsuario(id);

            if (!resultado.Validacao)
            {
                return BadRequest(resultado.MensagemResponse);
            }

            return NoContent();
        }
    }
}
