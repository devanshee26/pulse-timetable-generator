using Microsoft.EntityFrameworkCore.Migrations;

namespace Pulse.Migrations
{
    public partial class CourseRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseByFacultyId",
                table: "Courses",
                column: "CourseByFacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_User_CourseByFacultyId",
                table: "Courses",
                column: "CourseByFacultyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_User_CourseByFacultyId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseByFacultyId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
