using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Support_API.Migrations
{
    /// <inheritdoc />
    public partial class chamados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HelpDesk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusConversa",
                table: "HelpDesk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoConversa",
                table: "Conversa",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HelpDesk");

            migrationBuilder.DropColumn(
                name: "StatusConversa",
                table: "HelpDesk");

            migrationBuilder.DropColumn(
                name: "TipoConversa",
                table: "Conversa");
        }
    }
}
