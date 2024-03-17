using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Usuario_API.Models;

namespace Usuario_API.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _UsuarioService;
        public UsuarioController(IUsuario UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet("BuscaProdutoId/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Usuario>> BuscaProdutoId(int id)
        {
            var BuscaId = _UsuarioService.BuscaProdutoId(id).ToList();
            return Ok(BuscaId);
        }

        [HttpGet("BuscaProdutoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Usuario>> BuscaProdutoAll(int id)
        {
            var BuscaId = _UsuarioService.BuscaProdutoAll().ToList();
            return Ok(BuscaId);
        }
    }
}
