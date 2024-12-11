using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gym.Repository.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TreinoId",
                table: "Exercicios",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    AlunoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EstabelecimentoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treinos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TreinoId",
                table: "Exercicios",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_EstabelecimentoId",
                table: "Treinos",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropIndex(
                name: "IX_Exercicios_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropColumn(
                name: "TreinoId",
                table: "Exercicios");
        }
    }
}
