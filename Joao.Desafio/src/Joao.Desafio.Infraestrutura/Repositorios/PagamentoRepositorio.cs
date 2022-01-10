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
            try
            {
                entity.Excluir();
                _contexto.Pagamentos.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(Pagamento entity)
        {
            try
            {
                _contexto.Pagamentos.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public Pagamento? Obter(Guid id)
        {
            try
            {
                return _contexto.Pagamentos.Include(p => p.Estudante).Where(p => p.Id.Equals(id) && p.Ativo).FirstOrDefault(); 
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
                return _contexto.Pagamentos.Include(p => p.Estudante).Include(p => p.CartaoCredito).Where(p => p.EstudanteId.Equals(estudanteId) && p.Ativo).ToList();
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
                return _contexto.Pagamentos.Include(p => p.Estudante).Include(p => p.CartaoCredito).Where(p => p.Ativo).ToList();                
            }
            catch (Exception ex)
            {
                return new List<Pagamento>();
            }
        }
    }
}
