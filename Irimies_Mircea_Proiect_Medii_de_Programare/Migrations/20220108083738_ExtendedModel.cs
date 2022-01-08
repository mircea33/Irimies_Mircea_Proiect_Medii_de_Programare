using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Migrations
{
    public partial class ExtendedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferinta",
                columns: table => new
                {
                    ConferintaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nume_divizie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferinta", x => x.ConferintaID);
                });

            migrationBuilder.CreateTable(
                name: "Echipa",
                columns: table => new
                {
                    EchipaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferintaID = table.Column<int>(type: "int", nullable: false),
                    nume_echipa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echipa", x => x.EchipaID);
                    table.ForeignKey(
                        name: "FK_Echipa_Conferinta_ConferintaID",
                        column: x => x.ConferintaID,
                        principalTable: "Conferinta",
                        principalColumn: "ConferintaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Antrenor",
                columns: table => new
                {
                    AntrenorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipaID = table.Column<int>(type: "int", nullable: false),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_nasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenor", x => x.AntrenorID);
                    table.ForeignKey(
                        name: "FK_Antrenor_Echipa_EchipaID",
                        column: x => x.EchipaID,
                        principalTable: "Echipa",
                        principalColumn: "EchipaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jucator",
                columns: table => new
                {
                    JucatorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipaID = table.Column<int>(type: "int", nullable: false),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inaltime = table.Column<float>(type: "real", nullable: false),
                    greutate = table.Column<float>(type: "real", nullable: false),
                    data_nasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pozitie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jucator", x => x.JucatorID);
                    table.ForeignKey(
                        name: "FK_Jucator_Echipa_EchipaID",
                        column: x => x.EchipaID,
                        principalTable: "Echipa",
                        principalColumn: "EchipaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antrenor_EchipaID",
                table: "Antrenor",
                column: "EchipaID");

            migrationBuilder.CreateIndex(
                name: "IX_Echipa_ConferintaID",
                table: "Echipa",
                column: "ConferintaID");

            migrationBuilder.CreateIndex(
                name: "IX_Jucator_EchipaID",
                table: "Jucator",
                column: "EchipaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antrenor");

            migrationBuilder.DropTable(
                name: "Jucator");

            migrationBuilder.DropTable(
                name: "Echipa");

            migrationBuilder.DropTable(
                name: "Conferinta");
        }
    }
}
