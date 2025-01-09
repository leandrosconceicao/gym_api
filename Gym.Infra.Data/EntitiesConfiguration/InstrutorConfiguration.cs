using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(EntityTypeBuilder<Instrutor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.Property(p => p.Username).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Password).HasMaxLength(256).IsRequired();

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Estabelecimento)
                .WithMany(p => p.Instrutores)
                .HasForeignKey(p => p.EstabelecimentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
