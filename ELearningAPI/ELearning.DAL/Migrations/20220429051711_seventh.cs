using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_UserID",
                table: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_UserID",
                table: "Chats",
                newName: "IX_Chats_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserID",
                table: "Chats",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserID",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserID",
                table: "Chat",
                newName: "IX_Chat_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_UserID",
                table: "Chat",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
