using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SectionNumber",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SectionNumber",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
