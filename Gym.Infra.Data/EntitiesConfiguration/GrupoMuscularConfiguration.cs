using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class GrupoMuscularConfiguration : IEntityTypeConfiguration<GrupoMuscular>
    {
        public void Configure(EntityTypeBuilder<GrupoMuscular> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(124).IsRequired();

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.HasIndex(
                p => new {p.Name, p.EstabelecimentoId}    
            ).IsUnique();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Exercicios)
                .WithOne(p => p.GrupoMuscular)
                .HasForeignKey(p => p.GrupoMuscularId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
