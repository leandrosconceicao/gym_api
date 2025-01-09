using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class ExercicioConfiguration : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(124).IsRequired();

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(
                p => new { p.Name, p.GrupoMuscularId }    
            ).IsUnique();

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnUpdate();
        }
    }
}
