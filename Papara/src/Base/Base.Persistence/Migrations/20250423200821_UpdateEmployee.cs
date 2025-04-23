using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                schema: "Expense",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "Expense",
                table: "Employees",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                schema: "Expense",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "Expense",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
