using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class TipoBairroConfiguration : IEntityTypeConfiguration<TipoBairro>
    {
        public void Configure(EntityTypeBuilder<TipoBairro> builder)
        {
            builder
                .ToTable("tbtipobairro");

            builder.HasKey(b => b.Id);

            builder
                .Property<int>(a => a.Id)
                .HasColumnName("tipobairrocod");

            builder
                .Property(a => a.Nome)
                .HasColumnName("tipobairronome")
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder
                .Property(a => a.Abreviacao)
                .HasColumnName("tipobairroabrev")
                .HasColumnType("varchar(8)");

        }
    }
}
