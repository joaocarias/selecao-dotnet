using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Estudante : EntidadeBase
    {
        public Estudante(string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            
            DataCadastro = DateTime.Now;
        }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public void Editar(string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;   
            
            DataEdicao = DateTime.Now;
        }
    }
}
