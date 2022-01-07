using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class CartaoCreditoRepositorio : ICartaoCreditoRepositorio
    {
        private readonly AppContexto _contexto;

        public CartaoCreditoRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(CartaoCredito entity)
        {
            try
            {
                _contexto.CartaoCreditos.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Apagar(CartaoCredito entity)
        {
            try
            {
                _contexto.CartaoCreditos.Remove(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(CartaoCredito entity)
        {
            try
            {
                _contexto.CartaoCreditos.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public CartaoCredito? Obter(Guid id)
        {
            try
            {
                return _contexto.CartaoCreditos.Include(c => c.Estudante).Where(c => c.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<CartaoCredito>? ObteTodos()
        {
            try
            {
                return _contexto.CartaoCreditos.Include(c => c.Estudante).ToList();                
            }
            catch (Exception ex)
            {
                return new List<CartaoCredito>();
            }
        }
    }
}
