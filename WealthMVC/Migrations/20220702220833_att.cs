using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WealthMVC.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATIVOS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATIVOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERACOES",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtivosId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERACOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPERACOES_ATIVOS_AtivosId",
                        column: x => x.AtivosId,
                        principalTable: "ATIVOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portifolio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AtivosId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portifolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portifolio_ATIVOS_AtivosId",
                        column: x => x.AtivosId,
                        principalTable: "ATIVOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OPERACOES_AtivosId",
                table: "OPERACOES",
                column: "AtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Portifolio_AtivosId",
                table: "Portifolio",
                column: "AtivosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPERACOES");

            migrationBuilder.DropTable(
                name: "Portifolio");

            migrationBuilder.DropTable(
                name: "ATIVOS");
        }
    }
}
