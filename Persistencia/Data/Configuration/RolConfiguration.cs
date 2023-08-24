
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class RolConfiguration
{
    public void Configure(EntityTypeBuilder<Rol> builder){
        builder.ToTable("Rol");

        builder.Property(x => x.Id)
        .IsRequired();

        builder.Property(x => x.Nombre)
        .HasMaxLength(50);
    }
}
