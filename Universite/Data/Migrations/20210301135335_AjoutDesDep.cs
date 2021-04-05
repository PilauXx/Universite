using Microsoft.EntityFrameworkCore.Migrations;

namespace Universite.Data.Migrations
{
    public partial class AjoutDesDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroEtudiant",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormationSuivieID",
                table: "Etudiant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_FormationSuivieID",
                table: "Etudiant",
                column: "FormationSuivieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiant_Formation_FormationSuivieID",
                table: "Etudiant",
                column: "FormationSuivieID",
                principalTable: "Formation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiant_Formation_FormationSuivieID",
                table: "Etudiant");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropIndex(
                name: "IX_Etudiant_FormationSuivieID",
                table: "Etudiant");

            migrationBuilder.DropColumn(
                name: "FormationSuivieID",
                table: "Etudiant");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroEtudiant",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Etudiant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
