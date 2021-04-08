using Microsoft.EntityFrameworkCore.Migrations;

namespace Pulse.Migrations
{
    public partial class ScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    EachSlotTime = table.Column<int>(type: "int", nullable: false),
                    MondayTTId = table.Column<int>(type: "int", nullable: false),
                    TuesdayTTId = table.Column<int>(type: "int", nullable: false),
                    WednesdayTTId = table.Column<int>(type: "int", nullable: false),
                    ThursdayTTId = table.Column<int>(type: "int", nullable: false),
                    FridayTTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_TimeTable_FridayTTId",
                        column: x => x.FridayTTId,
                        principalTable: "TimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_TimeTable_MondayTTId",
                        column: x => x.MondayTTId,
                        principalTable: "TimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_TimeTable_ThursdayTTId",
                        column: x => x.ThursdayTTId,
                        principalTable: "TimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_TimeTable_TuesdayTTId",
                        column: x => x.TuesdayTTId,
                        principalTable: "TimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_TimeTable_WednesdayTTId",
                        column: x => x.WednesdayTTId,
                        principalTable: "TimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FridayTTId",
                table: "Schedules",
                column: "FridayTTId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MondayTTId",
                table: "Schedules",
                column: "MondayTTId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ThursdayTTId",
                table: "Schedules",
                column: "ThursdayTTId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TuesdayTTId",
                table: "Schedules",
                column: "TuesdayTTId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_WednesdayTTId",
                table: "Schedules",
                column: "WednesdayTTId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
