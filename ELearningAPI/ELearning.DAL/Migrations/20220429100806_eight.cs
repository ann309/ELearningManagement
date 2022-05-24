using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserID",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Chats",
                newName: "UserInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserID",
                table: "Chats",
                newName: "IX_Chats_UserInformationId");

            migrationBuilder.AddColumn<string>(
                name: "RecieverName",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserInformationId",
                table: "Chats",
                column: "UserInformationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserInformationId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "RecieverName",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "UserInformationId",
                table: "Chats",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserInformationId",
                table: "Chats",
                newName: "IX_Chats_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserID",
                table: "Chats",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
