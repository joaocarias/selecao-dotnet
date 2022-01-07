using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public bool Atualizar(Matricula entity)
        {
            throw new NotImplementedException();
        }

        public Matricula? Obter(Guid id)
        {
            return _contexto.Matriculas.Include(m => m.Estudante).Include(m => m.Curso).Where(m => m.Id.Equals(id)).FirstOrDefault();
        }

        public IList<Matricula>? ObteTodos()
        {
            throw new NotImplementedException();
        }
    }
}
