using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentationID",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentsID",
                table: "Uploads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsID",
                table: "Uploads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_DocumentsID",
                table: "Uploads",
                column: "DocumentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_ProjectsID",
                table: "Uploads",
                column: "ProjectsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uploads_Documentations_DocumentsID",
                table: "Uploads",
                column: "DocumentsID",
                principalTable: "Documentations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uploads_Projects_ProjectsID",
                table: "Uploads",
                column: "ProjectsID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uploads_Documentations_DocumentsID",
                table: "Uploads");

            migrationBuilder.DropForeignKey(
                name: "FK_Uploads_Projects_ProjectsID",
                table: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Uploads_DocumentsID",
                table: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Uploads_ProjectsID",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "DocumentationID",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "DocumentsID",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "ProjectsID",
                table: "Uploads");
        }
    }
}
