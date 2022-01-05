using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Estudante : EntidadeBase
    {
        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        public Guid? CartaoCreditoId { get; set; }

        [ForeignKey(nameof(CartaoCreditoId))]
        public CartaoCredito? CartaoCredito { get; set; } 
    }
}
