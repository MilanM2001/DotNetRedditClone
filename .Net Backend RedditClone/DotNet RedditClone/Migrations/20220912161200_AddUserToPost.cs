using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet_RedditClone.Migrations
{
    public partial class AddUserToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Post");
        }
    }
}
