using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly AppContexto _contexto;

        public MatriculaRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(Matricula entity)
        {
            try
            {
                _contexto.Matriculas.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Apagar(Matricula entity)
        {
            try
            {
                entity.Excluir();
                _contexto.Matriculas.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(Matricula entity)
        {
            try
            {
                _contexto.Matriculas.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public Matricula? Obter(Guid id)
        {
            return _contexto.Matriculas.Include(m => m.Estudante).Include(m => m.Curso).Where(m => m.Id.Equals(id) && m.Ativo).FirstOrDefault();
        }

        public IList<Matricula> ObterMatriculasPorEstudante(Guid estudanteId)
        {
            return _contexto.Matriculas.Include(m => m.Estudante).Include(m => m.Curso).Where(m => m.EstudanteId.Equals(estudanteId)).ToList();
        }

        public IList<Matricula>? ObteTodos()
        {
            return _contexto.Matriculas.Include(m => m.Estudante).Include(m => m.Curso).Where(x => x.Ativo).ToList();
        }
    }
}
