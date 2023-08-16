using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class  SalonConfiguration : IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
        builder.ToTable("Salon");

        builder.HasKey(e => e. IdSalon);

        builder.Property(e => e.IdSalon)
          .HasMaxLength(3);

        builder.Property(p => p.NombreSalon)
          .IsRequired()
          .HasMaxLength(50);

        builder.Property(p => p. Capacidad)
        .HasColumnType("int");

       
    }
}
    