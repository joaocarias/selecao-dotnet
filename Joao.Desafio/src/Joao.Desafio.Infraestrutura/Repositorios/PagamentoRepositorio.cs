using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly AppContexto _contexto;

        public PagamentoRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(Pagamento entity)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(Pagamento entity)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(Pagamento entity)
        {
            throw new NotImplementedException();
        }

        public Pagamento? Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Pagamento> ObterPorEstudanteId(Guid estudanteId)
        {
            try
            {
                return _contexto.Pagamentos.Include(p => p.Estudante).Where(p => p.EstudanteId.Equals(estudanteId)).ToList();
            }
            catch (Exception ex)
            {
                return new List<Pagamento>();
            }
        }

        public List<Pagamento>? ObteTodos()
        {
            try
            {
                return _contexto.Pagamentos.Include(p => p.Estudante).ToList();                
            }
            catch (Exception ex)
            {
                return new List<Pagamento>();
            }
        }
    }
}
