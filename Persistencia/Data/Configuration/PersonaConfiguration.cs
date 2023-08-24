using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class  PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.HasKey(e => e. IdPersona);

        builder.Property(e => e.IdPersona)
          .HasMaxLength(20);
          
        builder.Property(e => e.IdCiudadFk)
        .HasMaxLength(3);

        builder.Property(p => p.NombrePersona)
          .IsRequired()
          .HasMaxLength(50);

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdGeneroFk);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdCiudadFk);

        builder.HasOne(p => p.TipoPersona)
       .WithMany(p => p.Personas)
       .HasForeignKey(p => p.IdTipoPerFk);
        
        builder.HasMany(p => p.Roles)
        .WithMany(p => p.Personas)
        .UsingEntity<PersonaRol>(
          j => j. HasOne(pt => pt.Rol)
          .WithMany(t => t.PersonRoles)
          .HasForeignKey(pt => pt.RolId),
        
          j => j.HasOne(pt => pt.Persona)
          .WithMany(t => t.PersonaRoles)
          .HasForeignKey(pt => pt.UsuarioId),
          j =>{
            j.HasKey(t => new {t.UsuarioId,t.RolId});
          });
        
      
    }
}
    
  