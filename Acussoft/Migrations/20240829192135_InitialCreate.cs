using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accusoft.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusNota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusNota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaEmitida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroIdentificacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCobranca = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DocumentoNotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentoBoleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CredorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaEmitida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaEmitida_Credor_CredorId",
                        column: x => x.CredorId,
                        principalTable: "Credor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaEmitida_StatusNota_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusNota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaEmitida_CredorId",
                table: "NotaEmitida",
                column: "CredorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEmitida_StatusId",
                table: "NotaEmitida",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaEmitida");

            migrationBuilder.DropTable(
                name: "Credor");

            migrationBuilder.DropTable(
                name: "StatusNota");
        }
    }
}
