using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisGerencialNET.Models;

namespace SisGerencialNET.Controllers.Data
{
    public class BairroConfiguration : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder
                .ToTable("tbbairro");

            builder.HasKey(x => x.Id);

            builder                
                .Property(a => a.Id)
                .HasColumnName("bairrocod");

            builder
                .Property(a => a.Nome)
                .HasColumnName("bairronome")
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder
                .Property(a => a.TipoBairroID)
                .HasColumnName("tipobairrocod");
               
        }
    }
}
