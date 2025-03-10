﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeLearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class gropuName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Name");
        }
    }
}
