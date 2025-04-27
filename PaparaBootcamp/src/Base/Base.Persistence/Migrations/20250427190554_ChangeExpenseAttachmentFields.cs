using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExpenseAttachmentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 346, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 346, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 346, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 346, DateTimeKind.Unspecified).AddTicks(7607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 348, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 348, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 349, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 349, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 349, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 349, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 349, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2237), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2238), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2239), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2240), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$8BXUb7RbhA6JTCWIVJGnoeI09O6OcZox2KICDPy8bYhzW5Mf1CnNq", "ae6daa72-6a47-400c-a73c-9f71b9aac582" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$9yc/nf9C.unoN39Ku4J8O.xdKj2k7CWwHNjjqhkDca9IYZVe2enCa", "720db2de-39f1-4e21-9d07-0c1cb07970ab" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 19, 5, 54, 21, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$/5o6Ll18v3HHrZhEJxTtP.4yntfFh3xbD.bm64J26dk8ZLFbUiY42", "4628f07a-a363-4115-ac03-2471a3017690" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.DropColumn(
                name: "FileSize",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 244, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 244, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 244, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 244, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 246, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 246, DateTimeKind.Unspecified).AddTicks(9837), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 248, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 248, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 247, DateTimeKind.Unspecified).AddTicks(9402), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 247, DateTimeKind.Unspecified).AddTicks(9402), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 34, 247, DateTimeKind.Unspecified).AddTicks(9402), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8239), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8243), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8245), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8246), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8247), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8296), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8297), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 919, DateTimeKind.Unspecified).AddTicks(8298), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$GUaDs7hPEph1NKYWkcNH1elBXqZfK2mEVRTvj9dKF7rjmRUYftfOG", "b537b8c5-c470-4698-aca5-55726a374ea9" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$./rVjFFFMcUI9lHeozG2nOjzzdxcJUQCzMl8vNS6wdgVshEQ4gdFS", "d9589856-1cce-4586-ae87-371a26078fef" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 27, 18, 52, 33, 920, DateTimeKind.Unspecified).AddTicks(5198), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$ChwCbOFUwHtj0PxYUG3qq.CL/Ph7r/TuPr0O9qExoeMPU2aRgNfAG", "9e292d48-f5f4-4441-91e1-273618cc36fa" });
        }
    }
}
