using Joao.Desafio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Joao.Desafio.Infraestrutura.Contextos
{
    public class AppContexto : DbContext
    {
        public AppContexto(DbContextOptions<AppContexto> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Email> Emails { get; set; }

    }
}
