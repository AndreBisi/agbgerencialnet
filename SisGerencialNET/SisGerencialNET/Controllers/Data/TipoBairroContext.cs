using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class TipoBairroContext : DbContext
    {
        public DbSet<TipoBairro>? TiposBairro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = DBGerencialNET; User Id = postgres; Password = porcos128");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoBairroConfiguration()); 
        }

    }
}