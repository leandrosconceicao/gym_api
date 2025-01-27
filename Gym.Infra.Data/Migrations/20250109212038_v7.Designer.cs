﻿// <auto-generated />
using System;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gym.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250109212038_v7")]
    partial class v7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gym.Domain.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EstabelecimentoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Estabelecimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("ProprietarioId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("GrupoMuscularId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124)
                        .HasColumnType("varchar(124)");

                    b.Property<Guid?>("TreinoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoMuscularId");

                    b.HasIndex("TreinoId");

                    b.HasIndex("Name", "GrupoMuscularId")
                        .IsUnique();

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Gym.Domain.Entities.GrupoMuscular", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EstabelecimentoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124)
                        .HasColumnType("varchar(124)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("Name", "EstabelecimentoId")
                        .IsUnique();

                    b.ToTable("GruposMusculares");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Instrutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EstabelecimentoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Instrutores");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Proprietario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cgc")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124)
                        .HasColumnType("varchar(124)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Cgc")
                        .IsUnique();

                    b.ToTable("Proprietarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0753d561-d066-45e0-b442-572d76f5b94d"),
                            Cgc = "99999994894",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Leandro Conceição",
                            Password = "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=",
                            Username = "leandrosc"
                        });
                });

            modelBuilder.Entity("Gym.Domain.Entities.Treino", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("EstabelecimentoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("Gym.Domain.Entities.Estabelecimento", "Estabelecimento")
                        .WithMany("Alunos")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Estabelecimento", b =>
                {
                    b.HasOne("Gym.Domain.Entities.Proprietario", "Proprietario")
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Exercicio", b =>
                {
                    b.HasOne("Gym.Domain.Entities.GrupoMuscular", "GrupoMuscular")
                        .WithMany("Exercicios")
                        .HasForeignKey("GrupoMuscularId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Gym.Domain.Entities.Treino", null)
                        .WithMany("Exercicios")
                        .HasForeignKey("TreinoId");

                    b.Navigation("GrupoMuscular");
                });

            modelBuilder.Entity("Gym.Domain.Entities.GrupoMuscular", b =>
                {
                    b.HasOne("Gym.Domain.Entities.Estabelecimento", "Estabelecimento")
                        .WithMany("GruposMusculares")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Instrutor", b =>
                {
                    b.HasOne("Gym.Domain.Entities.Estabelecimento", "Estabelecimento")
                        .WithMany("Instrutores")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Treino", b =>
                {
                    b.HasOne("Gym.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Domain.Entities.Estabelecimento", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Estabelecimento", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("GruposMusculares");

                    b.Navigation("Instrutores");
                });

            modelBuilder.Entity("Gym.Domain.Entities.GrupoMuscular", b =>
                {
                    b.Navigation("Exercicios");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Proprietario", b =>
                {
                    b.Navigation("Estabelecimentos");
                });

            modelBuilder.Entity("Gym.Domain.Entities.Treino", b =>
                {
                    b.Navigation("Exercicios");
                });
#pragma warning restore 612, 618
        }
    }
}
