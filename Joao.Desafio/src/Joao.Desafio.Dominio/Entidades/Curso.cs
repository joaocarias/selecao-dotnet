using System.ComponentModel.DataAnnotations;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Curso : EntidadeBase
    {
        [Required]
        public string Descricao { get; set; } = string.Empty;  
    }
}
