using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeLearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class TaskFeedbackRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TaskId",
                table: "Feedbacks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Tasks_TaskId",
                table: "Feedbacks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Tasks_TaskId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_TaskId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Feedbacks");
        }
    }
}
