using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    /// <inheritdoc />
    public partial class dodatSesir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GrupaId",
                table: "Drzava",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Sesir",
                table: "Drzava",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sesir",
                table: "Drzava");

            migrationBuilder.AlterColumn<int>(
                name: "GrupaId",
                table: "Drzava",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
