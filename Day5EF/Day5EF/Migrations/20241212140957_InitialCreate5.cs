using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day5EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeesId", "EmployeeName", "Joindate", "Salary", "dptId" },
                values: new object[,]
                {
                    { 1, "Suhail", new DateOnly(2023, 1, 1), 500, 1 },
                    { 2, "John", new DateOnly(2023, 2, 1), 700, 2 }
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "dptId", "dptName" },
                values: new object[,]
                {
                    { 4, "IT" },
                    { 5, "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "dptId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "dptId",
                keyValue: 5);
        }
    }
}
