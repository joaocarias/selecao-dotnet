namespace Joao.Desafio.Dominio.Entidades
{
    public class CartaoCredito : EntidadeBase
    {
        public string Numero { get; set; } = string.Empty;
        public string NomeTitular { get; set; } = string.Empty;
        public string Validade { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
    }
}
