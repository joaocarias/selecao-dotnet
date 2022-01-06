using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Estudante : EntidadeBase
    {
        public Estudante(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
            
            DataCadastro = DateTime.Now;
        }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        public void Editar(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
            
            DataEdicao = DateTime.Now;
        }
    }
}
