using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
