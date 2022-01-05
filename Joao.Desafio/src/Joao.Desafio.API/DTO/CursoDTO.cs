using System.Text.Json.Serialization;

namespace Joao.Desafio.API.DTO
{
    public class CursoDTO
    {
        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
