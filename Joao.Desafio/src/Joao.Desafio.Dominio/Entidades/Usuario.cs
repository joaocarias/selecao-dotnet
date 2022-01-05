using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        [Required]
        public Guid EstudanteId { get; set; }

        [ForeignKey(nameof(EstudanteId))]
        public Estudante? Estudante { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
