using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(
                p => p.Cgc 
            ).IsUnique();

            builder.Property(p => p.Name).HasMaxLength(124).IsRequired();

            builder.Property(p => p.Cgc).HasMaxLength(14).IsRequired();

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();

            builder.HasData(
                new Proprietario(
                    new Guid("0753d561-d066-45e0-b442-572d76f5b94d"), 
                    "Leandro Conceição", 
                     "99999994894",
                     "leandrosc",
                     ""
                )
            );

            builder.HasMany(p => p.Estabelecimentos)
                .WithOne(p => p.Proprietario)
                .HasForeignKey(p => p.ProprietarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
