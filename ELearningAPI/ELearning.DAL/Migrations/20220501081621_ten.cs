using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calender_AspNetUsers_userID",
                table: "Calender");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Calender");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Calender",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Calender_userID",
                table: "Calender",
                newName: "IX_Calender_UserID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Uploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Uploads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uploads_UserID",
                table: "Uploads",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Calender_AspNetUsers_UserID",
                table: "Calender",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uploads_AspNetUsers_UserID",
                table: "Uploads",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calender_AspNetUsers_UserID",
                table: "Calender");

            migrationBuilder.DropForeignKey(
                name: "FK_Uploads_AspNetUsers_UserID",
                table: "Uploads");

            migrationBuilder.DropIndex(
                name: "IX_Uploads_UserID",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Uploads");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Uploads");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Calender",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Calender_UserID",
                table: "Calender",
                newName: "IX_Calender_userID");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Uploads",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Calender",
                type: "nvarchar(Max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calender_AspNetUsers_userID",
                table: "Calender",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
