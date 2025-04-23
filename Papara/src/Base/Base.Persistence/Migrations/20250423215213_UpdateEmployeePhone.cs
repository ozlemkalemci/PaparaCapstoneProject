using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePhones_Employees_EmployeeId",
                schema: "Expense",
                table: "EmployeePhones");

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "Expense",
                table: "EmployeePhones",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePhones_Employees_EmployeeId",
                schema: "Expense",
                table: "EmployeePhones",
                column: "EmployeeId",
                principalSchema: "Expense",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePhones_Employees_EmployeeId",
                schema: "Expense",
                table: "EmployeePhones");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Expense",
                table: "EmployeePhones");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePhones_Employees_EmployeeId",
                schema: "Expense",
                table: "EmployeePhones",
                column: "EmployeeId",
                principalSchema: "Expense",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
