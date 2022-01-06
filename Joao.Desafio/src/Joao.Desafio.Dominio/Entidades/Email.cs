using System.ComponentModel.DataAnnotations;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Email : EntidadeBase
    {
        [Required]
        public string Remetente { get; set; }

        [Required]
        public string Destinatario { get; set; }

        [Required]
        public string Mensagem { get; set; }

        public Email(string remetente, string destinatario, string mensagem)
        {
            Remetente = remetente;
            Destinatario = destinatario;
            Mensagem = mensagem;

            DataCadastro = DateTime.Now;
        }
    }
}
