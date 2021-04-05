using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AjoutDesDep6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LUEID",
                table: "Note",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "etudiantID",
                table: "Note",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_etudiantID",
                table: "Note",
                column: "etudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_LUEID",
                table: "Note",
                column: "LUEID");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Etudiant_etudiantID",
                table: "Note",
                column: "etudiantID",
                principalTable: "Etudiant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_UE_LUEID",
                table: "Note",
                column: "LUEID",
                principalTable: "UE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Etudiant_etudiantID",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_UE_LUEID",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_etudiantID",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_LUEID",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "LUEID",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "etudiantID",
                table: "Note");
        }
    }
}
