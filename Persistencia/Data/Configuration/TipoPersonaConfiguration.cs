using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class  TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("TipoPersona");

        builder.HasKey(e => e. IdTipoPersona);

        builder.Property(e => e.IdTipoPersona)
          .HasMaxLength(3);

        builder.Property(p => p.DescripcionTipoPersona)
          .IsRequired()
          .HasMaxLength(50);
       
    }
}
    