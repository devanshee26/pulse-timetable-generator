using Microsoft.EntityFrameworkCore.Migrations;

namespace Pulse.Migrations
{
    public partial class ResourcesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Resources_UserId",
                table: "Resources",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_User_UserId",
                table: "Resources",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_User_UserId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_UserId",
                table: "Resources");
        }
    }
}
