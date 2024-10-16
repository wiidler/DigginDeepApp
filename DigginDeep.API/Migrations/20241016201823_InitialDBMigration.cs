using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigginDeep.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
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
                table: "Students",
                columns: new[] { "Id", "Email", "Major", "Name" },
                values: new object[,]
                {
                    { 1, "johndoe@mst.edu", "Computer Science", "John Doe" },
                    { 2, "janedoe@mst.edu", "Computer Engineering", "Jane Doe" },
                    { 3, "johnsmith@mst.edu", "Information Science and Technology", "John Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
