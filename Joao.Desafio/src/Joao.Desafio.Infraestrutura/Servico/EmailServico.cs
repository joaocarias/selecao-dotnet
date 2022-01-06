using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;

namespace Joao.Desafio.Infraestrutura.Servico
{
    public class EmailServico : IEmailServico
    {
        private readonly IEmailRepositorio _emailRepositorio;

        public EmailServico(IEmailRepositorio emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }

        public void EnviarEmail(string emailRemetente, string emailDestinatario, string mensagem)
        {
            _emailRepositorio.Adicionar(new Email(emailRemetente, emailDestinatario, mensagem));
        }
    }
}
