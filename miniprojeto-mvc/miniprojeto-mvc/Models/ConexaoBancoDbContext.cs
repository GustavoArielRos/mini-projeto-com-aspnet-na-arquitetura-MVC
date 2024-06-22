using Microsoft.EntityFrameworkCore;

namespace miniprojeto_mvc.Models
{
    public class ConexaoBancoDbContext : DbContext
    {

        public DbSet<Aluno> Alunos { get; set; }

        public ConexaoBancoDbContext(DbContextOptions<ConexaoBancoDbContext> options) : base(options)
        {

        }

    }
}
