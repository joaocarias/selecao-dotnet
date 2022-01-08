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
            try
            {
                entity.Excluir();
                _contexto.Emails.Update(entity);
                _contexto.SaveChanges();                  
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(Email entity)
        {
            try
            {
                _contexto.Emails.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }

        public Email? Obter(Guid id)
        {
            try
            {
                return _contexto.Emails.Where(c => c.Id.Equals(id) && c.Ativo).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<Email> BuscarPorDestinatario(string destinatario)
        {
            try
            {
                return _contexto.Emails.Where(e => e.Destinatario.Equals(destinatario) && e.Ativo).ToList();
            }
            catch (Exception ex)
            {
                return new List<Email>();
            }
        }

        public IList<Email>? ObteTodos()
        {
            return _contexto.Emails.Where(e => e.Ativo).ToList();
        }
    }
}
