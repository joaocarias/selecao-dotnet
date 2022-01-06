using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class CartaoCredito : EntidadeBase
    {
        public CartaoCredito(Guid estudanteId, string numero, string nomeTitular, string validade, string codigo)
        {
            EstudanteId = estudanteId;
            Numero = numero;
            NomeTitular = nomeTitular;
            Validade = validade;
            Codigo = codigo;

            DataCadastro = DateTime.Now;
        }

        public Guid EstudanteId { get; set; }

        [ForeignKey(nameof(EstudanteId))]
        public Estudante Estudante { get; set; }

        public string Numero { get; set; } = string.Empty;
        public string NomeTitular { get; set; } = string.Empty;
        public string Validade { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;

        public void Editar(string numero, string nomeTitular, string validade, string codigo)
        {
            Numero = numero;
            NomeTitular = nomeTitular;
            Validade = validade;
            Codigo = codigo;

            DataEdicao = DateTime.Now;
        }
    }
}
