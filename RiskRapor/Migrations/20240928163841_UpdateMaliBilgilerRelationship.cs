using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskRapor.Migrations
{
    public partial class UpdateMaliBilgilerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaliBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnlasmaId = table.Column<int>(type: "int", nullable: false),
                    Gelir = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gider = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VergiOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaliBilgiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaliBilgiler_Anlasmalar_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "Anlasmalar",
                        principalColumn: "AnlasmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaliBilgiler_AnlasmaId",
                table: "MaliBilgiler",
                column: "AnlasmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaliBilgiler");
        }
    }
}
