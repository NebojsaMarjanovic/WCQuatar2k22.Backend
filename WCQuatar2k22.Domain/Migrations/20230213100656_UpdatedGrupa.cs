using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGrupa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JeZakljucana",
                table: "Grupa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeZakljucana",
                table: "Grupa");
        }
    }
}
