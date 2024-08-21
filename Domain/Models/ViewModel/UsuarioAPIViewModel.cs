using System.ComponentModel.DataAnnotations;

namespace Usuario_API.Models
{
    public class UsuarioAPIViewModel
    {
 
        [Required(ErrorMessage = "Inclua o Id do Usuário")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inclua o Nome do Usuário")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Inclua o Sobrenome do Usuário")]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage = "Inclua a Situação do Usuário")]
        public bool Ativo { get; set; }
        public string? Departamento { get; set; }
        public string? Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
