﻿using System.Text.Json.Serialization;

namespace Joao.Desafio.API.DTO
{
    public class EstudanteDTO
    {
        [JsonPropertyName("nomeCompleto")]
        public string NomeCompleto { get; set; } = string.Empty;
        
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

    }
}
