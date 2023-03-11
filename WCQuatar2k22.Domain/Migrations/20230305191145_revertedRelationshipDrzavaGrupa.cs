using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    /// <inheritdoc />
    public partial class revertedRelationshipDrzavaGrupa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drzava_Grupa_GrupaId",
                table: "Drzava");

            migrationBuilder.AddForeignKey(
                name: "FK_Drzava_Grupa_GrupaId",
                table: "Drzava",
                column: "GrupaId",
                principalTable: "Grupa",
                principalColumn: "GrupaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drzava_Grupa_GrupaId",
                table: "Drzava");

            migrationBuilder.AddForeignKey(
                name: "FK_Drzava_Grupa_GrupaId",
                table: "Drzava",
                column: "GrupaId",
                principalTable: "Grupa",
                principalColumn: "GrupaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
