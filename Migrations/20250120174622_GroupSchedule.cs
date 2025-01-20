using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeLearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class GroupSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_GroupId",
                table: "Schedule",
                column: "GroupId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Groups_GroupId",
                table: "Schedule",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Groups_GroupId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_GroupId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Schedule");
        }
    }
}
