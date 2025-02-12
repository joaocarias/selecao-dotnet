﻿using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;
using Joao.Desafio.Infraestrutura.Contextos;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly AppContexto _contexto;

        public CursoRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(Curso entity)
        {
            try
            {
                _contexto.Cursos.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
               return false;
            }

            return true;
        }

        public bool Apagar(Curso entity)
        {
            try
            {
                entity.Excluir();
                _contexto.Cursos.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false; 
            }

            return true;
        }

        public bool Atualizar(Curso entity)
        {
            try
            {
                _contexto.Cursos.Update(entity);
                _contexto.SaveChanges(); 
            }catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public Curso? Obter(Guid id)
        {
            try
            {
                return _contexto.Cursos.Where(c => c.Id.Equals(id) && c.Ativo).FirstOrDefault();                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<Curso>? ObteTodos()
        {
            try
            {
                return _contexto.Cursos.Where(c => c.Ativo).ToList();
            }
            catch (Exception ex)
            {
                return new List<Curso>();
            }
        }
    }
}
