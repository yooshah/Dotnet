using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day5EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    dptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.dptId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Joindate = table.Column<DateOnly>(type: "date", nullable: false),
                    dptId = table.Column<int>(type: "int", nullable: false),
                    departmentdptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeesId);
                    table.ForeignKey(
                        name: "FK_Employees_departments_departmentdptId",
                        column: x => x.departmentdptId,
                        principalTable: "departments",
                        principalColumn: "dptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeName", "Salary", "dptId" },
                values: new object[] { "Suhail", 500, 1 }
                );

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentdptId",
                table: "Employees",
                column: "departmentdptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
