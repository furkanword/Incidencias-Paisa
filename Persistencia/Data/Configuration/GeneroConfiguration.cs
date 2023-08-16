using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class  GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Genero");

        builder.HasKey(e => e. IdGeneroFk);

        builder.Property(e => e.IdGeneroFk);
        

        builder.Property(p => p.NombreGenero)
          .IsRequired()
          .HasMaxLength(50);

    }
}
    
