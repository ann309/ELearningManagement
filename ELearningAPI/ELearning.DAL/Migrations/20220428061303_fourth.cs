using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectFile",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DocumentationFile",
                table: "Documentations");

            migrationBuilder.AddColumn<int>(
                name: "UploadId",
                table: "Assign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assign_UploadId",
                table: "Assign",
                column: "UploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign");

            migrationBuilder.DropTable(
                name: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Assign_UploadId",
                table: "Assign");

            migrationBuilder.DropColumn(
                name: "UploadId",
                table: "Assign");

            migrationBuilder.AddColumn<string>(
                name: "ProjectFile",
                table: "Projects",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentationFile",
                table: "Documentations",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
