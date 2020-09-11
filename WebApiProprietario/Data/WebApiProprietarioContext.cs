using Microsoft.EntityFrameworkCore;
using WebApiProprietario.Domain;

namespace WebApiProprietario.Data
{
    public class WebApiProprietarioContext : DbContext
    {
        public WebApiProprietarioContext (DbContextOptions<WebApiProprietarioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>().ToTable("Carro");
        }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Carro> Carros { get; set; }
    }
}
