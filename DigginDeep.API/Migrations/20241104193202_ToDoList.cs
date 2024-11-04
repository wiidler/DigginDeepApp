using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigginDeep.API.Migrations
{
    /// <inheritdoc />
    public partial class ToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "ToDoLists",
                columns: new[] { "Id", "Description", "DueDate", "IsComplete", "Task" },
                values: new object[] { 1, "Complete the homework for the week", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), false, "Complete Homework" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");
        }
    }
}
