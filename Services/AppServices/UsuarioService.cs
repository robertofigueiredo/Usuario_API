using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;

namespace Services.AppServices
{
    public class UsuarioService : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IEnumerable<Usuario> BuscaProdutoId(int id)
        {
            var BuscaRepository = _usuarioRepository.BuscaProdutoId(id);
            return null;
        }

        public IEnumerable<Usuario> BuscaProdutoAll()
        {
            var BuscaRepository = _usuarioRepository.BuscaProdutoAll().ToList();
            return BuscaRepository;
        }
    }
}
