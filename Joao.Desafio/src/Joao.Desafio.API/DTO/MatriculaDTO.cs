using System.Text.Json.Serialization;

namespace Joao.Desafio.API.DTO
{
    public class MatriculaDTO
    {
        [JsonPropertyName("estudanteId")]
        public Guid EstudanteId { get; set; }

        [JsonPropertyName("cursoId")]
        public Guid CursoId { get; set; }
    }
}
