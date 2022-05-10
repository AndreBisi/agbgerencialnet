using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class Context : DbContext
    {
        public DbSet<Bairro>? Bairros { get; set; }
        public DbSet<TipoBairro>? TiposBairro { get; set; }
        public DbSet<Plano>? Planos { get; set; }

        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = DBGerencialNET; User Id = postgres; Password = porcos128");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BairroConfiguration());
            modelBuilder.ApplyConfiguration(new TipoBairroConfiguration());
            modelBuilder.ApplyConfiguration(new PlanoConfiguration());

        }
    }
}
