using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class PlanoConfiguration : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder
                .ToTable("tbplano");

            builder
                .Property<int>(a => a.Id)
                .HasColumnName("planocod");

            builder
                .Property(a => a.Nome)
                .HasColumnName("planonome")
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder
                .Property<bool>(a => a.Ativo)
                .HasColumnName("planoativo")
                .HasDefaultValue(true);
        }
    }
}
