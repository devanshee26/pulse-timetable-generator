using Microsoft.EntityFrameworkCore.Migrations;

namespace Pulse.Migrations
{
    public partial class UpdateTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course1Id",
                table: "TimeTable");

            migrationBuilder.AddColumn<int>(
                name: "Course2Id",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course3Id",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course4Id",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course5Id",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course6Id",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Course2Id",
                table: "TimeTable",
                column: "Course2Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Course3Id",
                table: "TimeTable",
                column: "Course3Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Course4Id",
                table: "TimeTable",
                column: "Course4Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Course5Id",
                table: "TimeTable",
                column: "Course5Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Course6Id",
                table: "TimeTable",
                column: "Course6Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course1Id",
                table: "TimeTable",
                column: "Course1Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course2Id",
                table: "TimeTable",
                column: "Course2Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course3Id",
                table: "TimeTable",
                column: "Course3Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course4Id",
                table: "TimeTable",
                column: "Course4Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course5Id",
                table: "TimeTable",
                column: "Course5Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course6Id",
                table: "TimeTable",
                column: "Course6Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course1Id",
                table: "TimeTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course2Id",
                table: "TimeTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course3Id",
                table: "TimeTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course4Id",
                table: "TimeTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course5Id",
                table: "TimeTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_Courses_Course6Id",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Course2Id",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Course3Id",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Course4Id",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Course5Id",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Course6Id",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Course2Id",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Course3Id",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Course4Id",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Course5Id",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Course6Id",
                table: "TimeTable");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_User_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_Courses_Course1Id",
                table: "TimeTable",
                column: "Course1Id",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
