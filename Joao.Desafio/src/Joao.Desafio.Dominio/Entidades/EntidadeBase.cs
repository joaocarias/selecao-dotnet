using System.ComponentModel.DataAnnotations;

namespace Joao.Desafio.Dominio.Entidades
{
    public class EntidadeBase
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataEdicao { get; set;}
    }
}
