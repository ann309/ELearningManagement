using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.DAL.Migrations
{
    public partial class nine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserInformationId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserInformationId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserInformationId",
                table: "Chats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserInformationId",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserInformationId",
                table: "Chats",
                column: "UserInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserInformationId",
                table: "Chats",
                column: "UserInformationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
