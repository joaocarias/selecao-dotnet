using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;

namespace Joao.Desafio.Dominio.IRepositorios
{
    public interface IEmailRepositorio : IRepositorioBase<Email>
    {
        IList<Email> ObterPorRemetentes(string rementente);
    }
}
