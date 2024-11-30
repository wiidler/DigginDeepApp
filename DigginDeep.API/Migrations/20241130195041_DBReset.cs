using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigginDeep.API.Migrations
{
    /// <inheritdoc />
    public partial class DBReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Major = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentHead = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    website = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Major = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentEmail", "DepartmentHead", "Major" },
                values: new object[,]
                {
                    { 1, "danlin@mst.edu", "Dr. Dan Lin", "Computer Science" },
                    { 2, "bmcmillin@mst.edu", "Dr. Bruce McMillin", "Computer Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Email", "Name", "website" },
                values: new object[,]
                {
                    { 1, "Designing and building a rover to compete in the University Rover Challenge", "marsrover@mst.edu", "Mars Rover Design Team", "marsrover.mst.edu" },
                    { 2, "The Institute of Electrical and Electronics Engineers student chapter at Missouri S&T", "ieee@mst.edu", "IEEE", "ieee.mst.edu" },
                    { 3, "The Association for Computing Machinery student chapter at Missouri S&T", "acm@mst.edu", "ACM", "acm.mst.edu" },
                    { 4, "Designing and building a rocket to compete in the Spaceport America Cup", "rocket@mst.edu", "Rocket Design Team", "rocket.mst.edu" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Major", "Name" },
                values: new object[,]
                {
                    { 1, "johndoe@mst.edu", "Computer Science", "John Doe" },
                    { 2, "janedoe@mst.edu", "Computer Engineering", "Jane Doe" },
                    { 3, "johnsmith@mst.edu", "Information Science and Technology", "John Smith" }
                });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "Id", "Description", "DueDate", "IsComplete", "Task" },
                values: new object[] { 1, "Complete the homework for the week", new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), false, "Complete Homework" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ToDoLists");
        }
    }
}
