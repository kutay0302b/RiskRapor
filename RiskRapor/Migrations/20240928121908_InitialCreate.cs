using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskRapor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anlasmalar",
                columns: table => new
                {
                    AnlasmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnlasmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RiskTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskDegeri = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anlasmalar", x => x.AnlasmaId);
                });

            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sektor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.FirmaId);
                });

            migrationBuilder.CreateTable(
                name: "IsKonulari",
                columns: table => new
                {
                    IsKonuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnlasmaId = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskAnalizi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsKonulari", x => x.IsKonuId);
                    table.ForeignKey(
                        name: "FK_IsKonulari_Anlasmalar_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "Anlasmalar",
                        principalColumn: "AnlasmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsKonulari_AnlasmaId",
                table: "IsKonulari",
                column: "AnlasmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropTable(
                name: "IsKonulari");

            migrationBuilder.DropTable(
                name: "Anlasmalar");
        }
    }
}
