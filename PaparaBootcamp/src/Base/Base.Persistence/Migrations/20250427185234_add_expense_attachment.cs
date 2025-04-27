using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_expense_attachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "Finance",
                table: "ExpenseAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ApprovedDate",
                schema: "Finance",
                table: "ExpenseApprovals",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<long>(
                name: "ApprovedById",
                schema: "Finance",
                table: "ExpenseApprovals",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "Finance",
                table: "ExpenseAttachments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ApprovedDate",
                schema: "Finance",
                table: "ExpenseApprovals",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ApprovedById",
                schema: "Finance",
                table: "ExpenseApprovals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 528, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 528, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 528, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 528, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 530, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 530, DateTimeKind.Unspecified).AddTicks(8140), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 532, DateTimeKind.Unspecified).AddTicks(1395), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 532, DateTimeKind.Unspecified).AddTicks(1395), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 531, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 531, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 531, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4311), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4314), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4315), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4316), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4317), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4319), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4320), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4321), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 175, DateTimeKind.Unspecified).AddTicks(4322), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$jsxVbJa4YiHz8.ivpx1Afe2F9pOiTg3x88C2wPBnyqzo4WX6mHtdm", "ac06738f-8e89-4ac8-adac-8e1deec83e97" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$qzzTA268fQm78sUaiVhIwur54mYGM4jTub/FMjBjH/EPuWbzJuthu", "d7db060e-145b-419a-97a7-b51f3890ed82" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$AUS4Q5.Qf9IA12F3UAOnI.EQnBueFv.cI6uTMoGqm6uZvbPt4idmG", "5541c763-f3d9-4d7b-856c-df803d0473b5" });
        }
    }
}
