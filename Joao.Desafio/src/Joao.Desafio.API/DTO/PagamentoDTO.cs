using System.Text.Json.Serialization;

namespace Joao.Desafio.API.DTO
{
    public class PagamentoDTO
    {
        [JsonPropertyName("estudanteId")]
        public Guid EstudanteId { get; set; }

        [JsonPropertyName("valor")]
        public double Valor { get; set; }
    }
}
