using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Pagamento : EntidadeBase
    {
        [Required]
        public Guid EstudanteId { get; set; }

        [ForeignKey(nameof(EstudanteId))]
        public Estudante? Estudante { get; set; }

        [Required]
        public DateTime DataPagamento { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public Guid CartaoCreditoId { get; set; }

        [ForeignKey(nameof(CartaoCreditoId))]
        public CartaoCredito? CartaoCredito { get; set; }

        public Pagamento(Guid estudanteId, double valor, Guid cartaoCreditoId)
        {
            EstudanteId = estudanteId;
            DataPagamento = DateTime.Now;
            Valor = valor;
            CartaoCreditoId = cartaoCreditoId;

            DataCadastro = DateTime.Now;
        }
    }
}
