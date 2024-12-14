using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day5EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_departmentdptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departmentdptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departmentdptId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_dptId",
                table: "Employees",
                column: "dptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_dptId",
                table: "Employees",
                column: "dptId",
                principalTable: "departments",
                principalColumn: "dptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
               table: "Employees",
               columns: new[] { "EmployeeName", "Salary", "dptId" },
               values: new object[] { "Suhail", 500, 1 }
               );
            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "dptName" },
                values: new object[] { "IT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_dptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_dptId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "departmentdptId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentdptId",
                table: "Employees",
                column: "departmentdptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_departmentdptId",
                table: "Employees",
                column: "departmentdptId",
                principalTable: "departments",
                principalColumn: "dptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
