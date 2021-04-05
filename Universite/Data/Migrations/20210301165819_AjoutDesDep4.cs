using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AjoutDesDep4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseigner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LEnseignantID = table.Column<int>(type: "int", nullable: false),
                    LUEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseigner", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enseigner_Enseignant_LEnseignantID",
                        column: x => x.LEnseignantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseigner_UE_LUEID",
                        column: x => x.LUEID,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_LEnseignantID",
                table: "Enseigner",
                column: "LEnseignantID");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigner_LUEID",
                table: "Enseigner",
                column: "LUEID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enseigner");
        }
    }
}
