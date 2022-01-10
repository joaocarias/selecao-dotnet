using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;

namespace Joao.Desafio.Dominio.IRepositorios
{
    public interface IMatriculaRepositorio : IRepositorioBase<Matricula>
    {
        IList<Matricula> ObterMatriculasPorEstudante(Guid estudanteId);
    }
}
