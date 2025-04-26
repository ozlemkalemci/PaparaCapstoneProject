using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "HR",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Base",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "Email", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "admin@papara.com", new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$jsxVbJa4YiHz8.ivpx1Afe2F9pOiTg3x88C2wPBnyqzo4WX6mHtdm", "ac06738f-8e89-4ac8-adac-8e1deec83e97" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Email", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "ozlem.kalemci@papara.com", new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$qzzTA268fQm78sUaiVhIwur54mYGM4jTub/FMjBjH/EPuWbzJuthu", "d7db060e-145b-419a-97a7-b51f3890ed82" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "Email", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "personel@papara.com", new DateTimeOffset(new DateTime(2025, 4, 26, 9, 19, 46, 176, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$AUS4Q5.Qf9IA12F3UAOnI.EQnBueFv.cI6uTMoGqm6uZvbPt4idmG", "5541c763-f3d9-4d7b-856c-df803d0473b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Base",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "HR",
                table: "Employees",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 96, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 96, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 96, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 96, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 99, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 99, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 101, DateTimeKind.Unspecified).AddTicks(2444), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 101, DateTimeKind.Unspecified).AddTicks(2444), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 100, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 0, 0, 0, 0)), "admin@papara.com" });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 100, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 0, 0, 0, 0)), "ozlem.kalemci@papara.com" });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "Email" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 27, 100, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 0, 0, 0, 0)), "personel@papara.com" });

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7668), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7674), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7676), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7677), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7681), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 703, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$.7sdAy6qoezVF3TzizPNleMpeXRCuiF/4wuiLWnYyIisteft7RL4y", "6ba07f5f-73f1-4cf8-8422-10aa82d178d6" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$QR4bxK13LlJnVsXw91iESe1Z2h.n.XeyMIxnreyvwGfMtucRKrwzC", "2b3e55ab-f2be-45c5-a4db-b58c854a4f67" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 26, 8, 26, 26, 704, DateTimeKind.Unspecified).AddTicks(9010), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$LE.Gsd.uCbqEZy3SgmSL4OMGexHJtJVIQuC0HKRnMiIG7NA334iEC", "96524ef7-8fea-449c-818c-50a5ab61d5dc" });
        }
    }
}
