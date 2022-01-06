using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joao.Desafio.Dominio.Entidades
{
    public class Matricula : EntidadeBase
    {
        public Matricula(Guid estudanteId, Guid cursoId)
        {
            EstudanteId = estudanteId;
            CursoId = cursoId;

            DataCadastro = DateTime.Now;
        }

        [Required]
        public Guid EstudanteId { get; set; }

        [ForeignKey(nameof(EstudanteId))]
        public Estudante Estudante { get; set; }

        [Required]
        public Guid CursoId { get; set; }

        [ForeignKey(nameof(CursoId))]
        public Curso Curso { get; set; }
    }
}
