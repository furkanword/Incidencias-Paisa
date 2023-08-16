using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration;

public class  TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
{
    public void Configure(EntityTypeBuilder<TrainerSalon> builder)
    {
        builder.ToTable("Trainersalon");

        builder.HasKey(e => new{e.IdSalonFk, e.IdPerTrainerFk});

        builder.Property(e => e. IdPerTrainerFk)
        .HasMaxLength(20);

        builder.Property(e => e.IdSalonFk)
        .HasColumnType("int");

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdPerTrainerFk);

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.TrainerSalones)
        .HasForeignKey(p => p.IdSalonFk);


       
    }
}