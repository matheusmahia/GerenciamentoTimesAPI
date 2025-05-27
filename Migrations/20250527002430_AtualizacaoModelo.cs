using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoTimesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "DataFundacao",
                table: "Times");

            migrationBuilder.RenameTable(
                name: "Times",
                newName: "TimesEsportivos");

            migrationBuilder.RenameColumn(
                name: "NumeroDeJogadores",
                table: "TimesEsportivos",
                newName: "NumeroJogadores");

            migrationBuilder.AddColumn<int>(
                name: "AnoFundacao",
                table: "TimesEsportivos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimesEsportivos",
                table: "TimesEsportivos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimesEsportivos",
                table: "TimesEsportivos");

            migrationBuilder.DropColumn(
                name: "AnoFundacao",
                table: "TimesEsportivos");

            migrationBuilder.RenameTable(
                name: "TimesEsportivos",
                newName: "Times");

            migrationBuilder.RenameColumn(
                name: "NumeroJogadores",
                table: "Times",
                newName: "NumeroDeJogadores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFundacao",
                table: "Times",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "Id");
        }
    }
}
