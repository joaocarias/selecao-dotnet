using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class EstudanteRepositorio : IEstudanteRepositorio
    {
        private readonly AppContexto _contexto;

        public EstudanteRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(Estudante entity)
        {
            try
            {
                _contexto.Estudantes.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Apagar(Estudante entity)
        {
            try
            {
                _contexto.Estudantes.Remove(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(Estudante entity)
        {
            try
            {
                _contexto.Estudantes.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public Estudante? Obter(Guid id)
        {
            try
            {
                return _contexto.Estudantes.Where(c => c.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<Estudante>? ObteTodos()
        {
            try
            {
                return _contexto.Estudantes.ToList();
            }
            catch (Exception ex)
            {
                return new List<Estudante>();
            }
        }
    }
}
