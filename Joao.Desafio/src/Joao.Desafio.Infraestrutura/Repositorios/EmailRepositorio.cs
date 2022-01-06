using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Infraestrutura.Contextos;

namespace Joao.Desafio.Infraestrutura.Repositorios
{
    public class EmailRepositorio : IEmailRepositorio
    {
        private readonly AppContexto _contexto;

        public EmailRepositorio(AppContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Adicionar(Email entity)
        {
            try
            {
                _contexto.Emails.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Apagar(Email entity)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(Email entity)
        {
            throw new NotImplementedException();
        }

        public Email? Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Email> ObterPorRemetentes(string rementente)
        {
            try
            {
                return _contexto.Emails.Where(e => e.Equals(rementente)).ToList();
            }
            catch (Exception ex)
            {
                return new List<Email>();
            }
        }

        public List<Email>? ObteTodos()
        {
            throw new NotImplementedException();
        }
    }
}
