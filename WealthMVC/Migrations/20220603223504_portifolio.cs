using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WealthMVC.Migrations
{
    public partial class portifolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATIVOS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "PORTIFOLIO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AtivosId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperacoesId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORTIFOLIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PORTIFOLIO_ATIVOS_AtivosId",
                        column: x => x.AtivosId,
                        principalTable: "ATIVOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PORTIFOLIO_OPERACOES_OperacoesId",
                        column: x => x.OperacoesId,
                        principalTable: "OPERACOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OPERACOES_AtivosId",
                table: "OPERACOES",
                column: "AtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_PORTIFOLIO_AtivosId",
                table: "PORTIFOLIO",
                column: "AtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_PORTIFOLIO_OperacoesId",
                table: "PORTIFOLIO",
                column: "OperacoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PORTIFOLIO");

            migrationBuilder.DropTable(
                name: "OPERACOES");

            migrationBuilder.DropTable(
                name: "ATIVOS");
        }
    }
}
