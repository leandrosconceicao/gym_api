using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository.RepositoryContext
{
    public class ApiContext(DbContextOptions<ApiContext> opts) : DbContext(opts)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estabelecimento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity
                    .HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Aluno>()
                .HasIndex(aluno => new 
                {
                    aluno.Username, aluno.EstabelecimentoId
                })
                .IsUnique();

            modelBuilder.Entity<Instrutor>()
                .HasIndex(instrutor => new
                {
                    instrutor.Username, instrutor.EstabelecimentoId
                })
                .IsUnique();

            modelBuilder.Entity<GrupoMuscular>()
                .HasIndex(grupo => new
                {
                    grupo.Name, grupo.EstabelecimentoId
                })
                .IsUnique();
        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<Treino> Treinos {get; set;}
    }
}
