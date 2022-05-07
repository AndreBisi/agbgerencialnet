using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class PlanoContext : DbContext
    {
        public DbSet<Plano> Planos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = DBGerencialNET; User Id = postgres; Password = porcos128");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanoConfiguration());
        }
    }
}
