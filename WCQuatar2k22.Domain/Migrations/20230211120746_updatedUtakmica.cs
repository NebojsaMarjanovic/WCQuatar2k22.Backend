using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updatedUtakmica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PredajaMeca",
                table: "Utakmica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PredajaMeca",
                table: "Utakmica",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
