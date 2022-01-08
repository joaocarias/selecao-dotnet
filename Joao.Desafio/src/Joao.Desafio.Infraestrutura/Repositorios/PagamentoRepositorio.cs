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
            try
            {
                _contexto.Pagamentos.Add(entity);
                _contexto.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }                
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
            try
            {
                return _contexto.Pagamentos.Include(p => p.Estudante).Where(p => p.Id.Equals(id)).FirstOrDefault(); 
            }
            catch (Exception ex)
            {
                return null;
            }
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

        public IList<Pagamento>? ObteTodos()
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
