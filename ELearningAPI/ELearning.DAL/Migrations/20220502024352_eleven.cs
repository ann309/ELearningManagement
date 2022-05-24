using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Documentations_DocumentationId",
                table: "Assign");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Projects_ProjectId",
                table: "Assign");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign");

            migrationBuilder.AlterColumn<int>(
                name: "UploadId",
                table: "Assign",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Assign",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentationId",
                table: "Assign",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Documentations_DocumentationId",
                table: "Assign",
                column: "DocumentationId",
                principalTable: "Documentations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Projects_ProjectId",
                table: "Assign",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Documentations_DocumentationId",
                table: "Assign");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Projects_ProjectId",
                table: "Assign");

            migrationBuilder.DropForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign");

            migrationBuilder.AlterColumn<int>(
                name: "UploadId",
                table: "Assign",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Assign",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentationId",
                table: "Assign",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Documentations_DocumentationId",
                table: "Assign",
                column: "DocumentationId",
                principalTable: "Documentations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Projects_ProjectId",
                table: "Assign",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assign_Uploads_UploadId",
                table: "Assign",
                column: "UploadId",
                principalTable: "Uploads",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
