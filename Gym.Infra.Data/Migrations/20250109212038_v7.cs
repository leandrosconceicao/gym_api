using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gym.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercicios",
                type: "varchar(124)",
                maxLength: 124,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Exercicios",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_GruposMusculares_Name_EstabelecimentoId",
                table: "GruposMusculares",
                columns: new[] { "Name", "EstabelecimentoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_Name_GrupoMuscularId",
                table: "Exercicios",
                columns: new[] { "Name", "GrupoMuscularId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GruposMusculares_Name_EstabelecimentoId",
                table: "GruposMusculares");

            migrationBuilder.DropIndex(
                name: "IX_Exercicios_Name_GrupoMuscularId",
                table: "Exercicios");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercicios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(124)",
                oldMaxLength: 124);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Exercicios",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}
