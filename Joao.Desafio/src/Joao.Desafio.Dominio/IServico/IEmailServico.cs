namespace Joao.Desafio.Dominio.IServico
{
    public interface IEmailServico
    {
        void EnviarEmail(string emailRemetente, string emailDestinatario, string mensagem);
    }
}
