using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AjoutDesDep3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormationID",
                table: "UE",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UE_FormationID",
                table: "UE",
                column: "FormationID");

            migrationBuilder.AddForeignKey(
                name: "FK_UE_Formation_FormationID",
                table: "UE",
                column: "FormationID",
                principalTable: "Formation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UE_Formation_FormationID",
                table: "UE");

            migrationBuilder.DropIndex(
                name: "IX_UE_FormationID",
                table: "UE");

            migrationBuilder.DropColumn(
                name: "FormationID",
                table: "UE");
        }
    }
}
