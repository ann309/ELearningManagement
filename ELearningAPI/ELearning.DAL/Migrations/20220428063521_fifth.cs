using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "Calender",
                newName: "EventStart");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Calender",
                type: "nvarchar(Max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventEnd",
                table: "Calender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Calender");

            migrationBuilder.DropColumn(
                name: "EventEnd",
                table: "Calender");

            migrationBuilder.RenameColumn(
                name: "EventStart",
                table: "Calender",
                newName: "EventTime");
        }
    }
}
