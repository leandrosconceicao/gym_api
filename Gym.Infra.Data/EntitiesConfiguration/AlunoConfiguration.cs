using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
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
                .WithMany(p => p.Alunos)
                .HasForeignKey(p => p.EstabelecimentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
