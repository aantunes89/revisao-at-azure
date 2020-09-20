using Microsoft.EntityFrameworkCore;
using WebApiPessoa.Models;

namespace WebApiPessoa.Data
{
    public class WebApiPessoaContext : DbContext
    {
        public WebApiPessoaContext (DbContextOptions<WebApiPessoaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Pessoa>()
                .HasMany(x => x.Filhos);
        }

        public DbSet<WebApiPessoa.Models.Pessoa> Pessoa { get; set; }
    }
}
