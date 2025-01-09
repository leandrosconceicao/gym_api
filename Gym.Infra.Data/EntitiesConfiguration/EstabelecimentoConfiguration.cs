using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class EstabelecimentoConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(p => p.GruposMusculares)
                .WithOne(p => p.Estabelecimento)
                .HasForeignKey(p => p.EstabelecimentoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
