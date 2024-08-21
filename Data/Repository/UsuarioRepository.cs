using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Usuario_API.Models;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public Usuario BuscaUsuarioId(int id)
        {
            return _context.UsuarioAPI.Find(id);
        }
        public IEnumerable<Usuario> BuscaUsuarioAll()
        {
            return _context.UsuarioAPI.ToList();
        }

        public void Excluirusuario(Usuario usuario)
        {
            _context.UsuarioAPI.Remove(usuario);
            _context.SaveChanges();
        }

        public BaseRetorno IncluirUsuario(Usuario usuario)
        {
            var retorno = new BaseRetorno();
            try
            {
                _context.UsuarioAPI.Add(usuario);
                _context.SaveChanges();

                retorno.Validacao = true;
                retorno.MensagemResponse = "Usuário incluído com sucesso.";
            }
            catch (DbUpdateException ex)
            {
                retorno.Validacao = false;
                retorno.MensagemResponse = "Erro ao inserir usuário: " + ex.Message;
            }
            catch (Exception ex)
            {
                retorno.Validacao = false;
                retorno.MensagemResponse = "Erro desconhecido ao inserir usuário: " + ex.Message;
            }

            return retorno;
        }

        public BaseRetorno AtualizarUsuario(Usuario usuario)
        {
            var retorno = new BaseRetorno();
            try
            {
                _context.UsuarioAPI.Update(usuario);
                _context.SaveChanges();
                retorno.Validacao = true;

            }
            catch (Exception ex)
            {
                retorno.Validacao = false;
                retorno.MensagemResponse = ex.Message;
            }
            return retorno;
        }

    }
}
