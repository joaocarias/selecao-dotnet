using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Joao.Desafio.Dominio.Uteis;

namespace Joao.Desafio.Infraestrutura.Servico
{
    public class EmailServico : IEmailServico
    {
        private readonly IEmailRepositorio _emailRepositorio;
       
        public EmailServico(IEmailRepositorio emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }

        public void EnviarEmail(Matricula? matricula)
        {
            //var info = _matriculaRepositorio.Obter(matricula.Id);
            if (matricula != null)
            {
                var mensagem = $"Olá {matricula.Estudante.NomeCompleto}, sua matricula realizada com " +
                    $" Sucesso no curso {matricula.Curso.Descricao} na data {matricula.DataCadastro}. ";

                EnviarEmail(Constantes.EMAIL_REMETENTE, matricula.Estudante.Email, mensagem);
            }
        }

        private void EnviarEmail(string emailRemetente, string emailDestinatario, string mensagem)
        {
            _emailRepositorio.Adicionar(new Email(emailRemetente, emailDestinatario, mensagem));
        }


    }
}
