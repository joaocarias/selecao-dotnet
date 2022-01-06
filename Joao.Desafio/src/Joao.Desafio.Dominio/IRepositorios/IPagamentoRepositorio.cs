using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;

namespace Joao.Desafio.Dominio.IRepositorios
{
    public interface IPagamentoRepositorio : IRepositorioBase<Pagamento>
    {
        IList<Pagamento> ObterPorEstudanteId(Guid estudanteId);
    }
}
