using System.ComponentModel.DataAnnotations;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Curso : EntidadeBase
    {
        [Required]
        public string Descricao { get; set; } = string.Empty;

        public Curso(string descricao)
        {
            Descricao = descricao;

            DataCadastro = DateTime.Now;
        }

        public void Editar(string descricao)
        {
            Descricao = descricao;

            DataEdicao = DateTime.Now;
        }
    }
}
