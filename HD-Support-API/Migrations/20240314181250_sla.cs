using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Support_API.Migrations
{
    /// <inheritdoc />
    public partial class sla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "HelpDesk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "HelpDesk",
                type: "varbinary(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
