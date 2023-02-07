using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupa",
                columns: table => new
                {
                    GrupaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGrupe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.GrupaId);
                });

            migrationBuilder.CreateTable(
                name: "Stadion",
                columns: table => new
                {
                    StadionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivStadiona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadion", x => x.StadionId);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zastava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojOdigranihMeceva = table.Column<int>(type: "int", nullable: false),
                    BrojPobeda = table.Column<int>(type: "int", nullable: false),
                    BrojNeresenih = table.Column<int>(type: "int", nullable: false),
                    BrojIzgubljenih = table.Column<int>(type: "int", nullable: false),
                    BrojPrimljenihGolova = table.Column<int>(type: "int", nullable: false),
                    BrojDatihGolova = table.Column<int>(type: "int", nullable: false),
                    OsvojeniPoeni = table.Column<int>(type: "int", nullable: false),
                    GrupaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaId);
                    table.ForeignKey(
                        name: "FK_Drzava_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "GrupaId");
                });

            migrationBuilder.CreateTable(
                name: "Utakmica",
                columns: table => new
                {
                    UtakmicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomacinId = table.Column<int>(type: "int", nullable: false),
                    GostId = table.Column<int>(type: "int", nullable: false),
                    DomacinRezultat = table.Column<int>(type: "int", nullable: false),
                    GostRezultat = table.Column<int>(type: "int", nullable: false),
                    VremeOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StadionId = table.Column<int>(type: "int", nullable: false),
                    PredajaMeca = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmica", x => x.UtakmicaId);
                    table.ForeignKey(
                        name: "FK_Utakmica_Drzava_DomacinId",
                        column: x => x.DomacinId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId");
                    table.ForeignKey(
                        name: "FK_Utakmica_Drzava_GostId",
                        column: x => x.GostId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId");
                    table.ForeignKey(
                        name: "FK_Utakmica_Stadion_StadionId",
                        column: x => x.StadionId,
                        principalTable: "Stadion",
                        principalColumn: "StadionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drzava_GrupaId",
                table: "Drzava",
                column: "GrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_DomacinId",
                table: "Utakmica",
                column: "DomacinId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_GostId",
                table: "Utakmica",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_StadionId",
                table: "Utakmica",
                column: "StadionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utakmica");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Stadion");

            migrationBuilder.DropTable(
                name: "Grupa");
        }
    }
}
