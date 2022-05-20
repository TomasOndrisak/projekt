using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastruktura.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozicie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PozicieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pozicie_Pozicie_PozicieId",
                        column: x => x.PozicieId,
                        principalTable: "Pozicie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamestnanci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priezvisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumNarodenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumNastupu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPozicie = table.Column<int>(type: "int", nullable: false),
                    Plat = table.Column<float>(type: "real", nullable: false),
                    Archivovany = table.Column<bool>(type: "bit", nullable: false),
                    pozicieId = table.Column<int>(type: "int", nullable: true),
                    ZamestnanciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamestnanci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zamestnanci_Pozicie_idPozicie",
                        column: x => x.idPozicie,
                        principalTable: "Pozicie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamestnanci_Pozicie_pozicieId",
                        column: x => x.pozicieId,
                        principalTable: "Pozicie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zamestnanci_Zamestnanci_ZamestnanciId",
                        column: x => x.ZamestnanciId,
                        principalTable: "Zamestnanci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predoslepozicie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUkoncenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumNastupu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idZamestnanca = table.Column<int>(type: "int", nullable: false),
                    idPozicie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predoslepozicie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predoslepozicie_Zamestnanci_idZamestnanca",
                        column: x => x.idZamestnanca,
                        principalTable: "Zamestnanci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pozicie_PozicieId",
                table: "Pozicie",
                column: "PozicieId");

            migrationBuilder.CreateIndex(
                name: "IX_Predoslepozicie_idZamestnanca",
                table: "Predoslepozicie",
                column: "idZamestnanca");

            migrationBuilder.CreateIndex(
                name: "IX_Zamestnanci_idPozicie",
                table: "Zamestnanci",
                column: "idPozicie");

            migrationBuilder.CreateIndex(
                name: "IX_Zamestnanci_pozicieId",
                table: "Zamestnanci",
                column: "pozicieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamestnanci_ZamestnanciId",
                table: "Zamestnanci",
                column: "ZamestnanciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predoslepozicie");

            migrationBuilder.DropTable(
                name: "Zamestnanci");

            migrationBuilder.DropTable(
                name: "Pozicie");
        }
    }
}
