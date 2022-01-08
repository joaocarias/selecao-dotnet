using Joao.Desafio.Dominio.Entidades;

namespace Joao.Desafio.Dominio.IServico
{
    public interface IEmailServico
    {
        void EnviarEmail(Matricula? matricula);
       // void EnviarEmail(string emailRemetente, string emailDestinatario, string mensagem);
    }
}
