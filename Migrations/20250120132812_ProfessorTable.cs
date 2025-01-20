using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeLearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProfessorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Staff_ProfessorId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "SubjectArea",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Staff");

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectArea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Staff_Id",
                        column: x => x.Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Professor_ProfessorId",
                table: "Resources",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Professor_ProfessorId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Staff",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubjectArea",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Staff_ProfessorId",
                table: "Resources",
                column: "ProfessorId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
