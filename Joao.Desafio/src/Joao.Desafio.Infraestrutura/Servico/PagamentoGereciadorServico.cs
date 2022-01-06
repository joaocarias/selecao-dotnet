using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;

namespace Joao.Desafio.Infraestrutura.Servico
{
    public class PagamentoGereciadorServico : IPagamentoGerenciadorServico
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;

        public PagamentoGereciadorServico(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        public bool VerificarExistePagamento(Guid estudanteId)
        {
            if (_pagamentoRepositorio.ObterPorEstudanteId(estudanteId).Any())
            {
                return true;
            }           

            return false;
        }
    }
}
