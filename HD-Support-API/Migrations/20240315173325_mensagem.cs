using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Support_API.Migrations
{
    /// <inheritdoc />
    public partial class mensagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionariosId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Criptografia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_conclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversa_HelpDesk_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "HelpDesk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversa_HelpDesk_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "HelpDesk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConversaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Data_envio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_HelpDesk_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "HelpDesk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_ClienteId",
                table: "Conversa",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_FuncionariosId",
                table: "Conversa",
                column: "FuncionariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_UsuarioId",
                table: "Mensagens",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversa");

            migrationBuilder.DropTable(
                name: "Mensagens");
        }
    }
}
