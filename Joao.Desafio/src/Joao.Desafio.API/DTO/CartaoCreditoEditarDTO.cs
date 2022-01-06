using System.Text.Json.Serialization;

namespace Joao.Desafio.API.DTO
{
    public class CartaoCreditoEditarDTO
    {        
        [JsonPropertyName("numero")]
        public string Numero { get; set; } = string.Empty;

        [JsonPropertyName("nomeTitular")]
        public string NomeTitular { get; set; } = string.Empty;

        [JsonPropertyName("validade")]
        public string Validade { get; set; } = string.Empty;

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; } = string.Empty;
    }
}
