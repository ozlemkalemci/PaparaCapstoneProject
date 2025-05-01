using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations.Papara
{
    /// <inheritdoc />
    public partial class Add_Store_Prodecure_App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 853, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 853, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 853, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 853, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 853, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 855, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 855, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 856, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 856, DateTimeKind.Unspecified).AddTicks(8359), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 856, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 856, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 856, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3525), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3529), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3531), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3532), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3534), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3535), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3536), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 504, DateTimeKind.Unspecified).AddTicks(3537), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$FI.jUPlnGO1/UZVuOMUVcOplAIY7xynHyIKeIvl1FwKfBZzsY.Hge", "1168e9e0-362f-4b6d-b1f5-7061553a13bd" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$QibIKA0aGOrXkaLpLguQWOcSzwd7z.5M.2MUVIGjMckroawfNyVXS", "bbd92926-f3a4-4dee-b0da-40d7e6ab03f7" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 32, 31, 505, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$sWTx9ScQ8IuzZ88RQ1pP1eXYGY8E9O3nJbMd5IOsoraynfVjJROLu", "1b714027-7a9b-430c-af09-dea74ce9b6fa" });

			migrationBuilder.Sql(@"
		CREATE VIEW vw_PersonnelExpenseHistory AS
		SELECT 
			e.Id AS EmployeeId,
			(e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.LastName) AS EmployeeName,
			exp.Id AS ExpenseId,
			exp.ExpenseDate,
			exp.Amount,
			et.Name AS ExpenseType,
			exp.Description,
			ea.Status AS ApprovalStatus,
			ea.ApprovedDate
		FROM Finance.Expenses exp
		INNER JOIN HR.Employees e ON exp.EmployeeId = e.Id
		LEFT JOIN Finance.ExpenseTypes et ON exp.ExpenseTypeId = et.Id
		LEFT JOIN Finance.ExpenseApprovals ea ON ea.ExpenseId = exp.Id AND ea.IsActive = 1
		WHERE exp.IsActive = 1
	");

			migrationBuilder.Sql(@"
		CREATE PROCEDURE sp_GetAdminExpenseSummaryReport
			@Period NVARCHAR(10)
		AS
		BEGIN
			SET NOCOUNT ON;

			SELECT 
				@Period AS Period,
				SUM(e.Amount) AS TotalAmount,
				COUNT(e.Id) AS ExpenseCount
			FROM Finance.Expenses e
			WHERE e.IsActive = 1
				AND EXISTS (
					SELECT 1 FROM Finance.ExpenseApprovals ea
					WHERE ea.ExpenseId = e.Id AND ea.Status = 2 AND ea.IsActive = 1
				)
				AND (
					(@Period = 'daily' AND CAST(e.ExpenseDate AS DATE) = CAST(GETDATE() AS DATE))
					OR (@Period = 'weekly' AND e.ExpenseDate >= DATEADD(DAY, -7, GETDATE()))
					OR (@Period = 'monthly' AND e.ExpenseDate >= DATEADD(MONTH, -1, GETDATE()))
				)
		END
	");

			migrationBuilder.Sql(@"
		CREATE PROCEDURE sp_GetExpenseApprovalStatusSummary
			@Period NVARCHAR(10)
		AS
		BEGIN
			SET NOCOUNT ON;

			SELECT 
				@Period AS Period,
				ea.Status,
				SUM(e.Amount) AS TotalAmount,
				COUNT(e.Id) AS Count
			FROM Finance.Expenses e
			INNER JOIN Finance.ExpenseApprovals ea ON ea.ExpenseId = e.Id AND ea.IsActive = 1
			WHERE e.IsActive = 1
				AND (
					(@Period = 'daily' AND CAST(e.ExpenseDate AS DATE) = CAST(GETDATE() AS DATE))
					OR (@Period = 'weekly' AND e.ExpenseDate >= DATEADD(DAY, -7, GETDATE()))
					OR (@Period = 'monthly' AND e.ExpenseDate >= DATEADD(MONTH, -1, GETDATE()))
				)
			GROUP BY ea.Status
		END
	");

			migrationBuilder.Sql(@"
		CREATE PROCEDURE sp_GetPersonnelSpendingSummary
			@Period NVARCHAR(10)
		AS
		BEGIN
			SET NOCOUNT ON;

			SELECT 
				@Period AS Period,
				(e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.LastName) AS FullName,
				SUM(exp.Amount) AS TotalAmount,
				COUNT(exp.Id) AS ExpenseCount
			FROM Finance.Expenses exp
			INNER JOIN HR.Employees e ON exp.EmployeeId = e.Id
			WHERE exp.IsActive = 1
				AND (
					(@Period = 'daily' AND CAST(exp.ExpenseDate AS DATE) = CAST(GETDATE() AS DATE))
					OR (@Period = 'weekly' AND exp.ExpenseDate >= DATEADD(DAY, -7, GETDATE()))
					OR (@Period = 'monthly' AND exp.ExpenseDate >= DATEADD(MONTH, -1, GETDATE()))
				)
			GROUP BY e.FirstName, e.MiddleName, e.LastName
		END
	");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

			// DROP VIEW
			migrationBuilder.Sql("DROP VIEW IF EXISTS vw_PersonnelExpenseHistory");

			// DROP STORED PROCEDURES
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetAdminExpenseSummaryReport");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetExpenseApprovalStatusSummary");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetPersonnelSpendingSummary");


			migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 173, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 173, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 173, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 173, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 173, DateTimeKind.Unspecified).AddTicks(8231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 175, DateTimeKind.Unspecified).AddTicks(3836), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 175, DateTimeKind.Unspecified).AddTicks(3836), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 176, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 176, DateTimeKind.Unspecified).AddTicks(6899), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 176, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 176, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 23, 176, DateTimeKind.Unspecified).AddTicks(2498), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4941), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4944), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4947), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4950), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4951), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 826, DateTimeKind.Unspecified).AddTicks(4953), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$xo0G1w/V13iQbLbwm09ZoeLdbYrAhi8oi203gNMClgKh7wLLW1Z6u", "d4318bbf-ed5c-4a07-8c55-e30a522691ad" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$vOYtWTmRZZqMjsBUQCD70eDgC1jRz65YWWRiFdZPTiStm7GrLIDmi", "932de3d7-48b6-49fd-9b32-502392847451" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 1, 17, 29, 22, 827, DateTimeKind.Unspecified).AddTicks(2622), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$BlvQhEqYmdM6p8PEsEhJIuSCrzkzPnH.Onewhg9Y2TFogsePwTd8y", "aa163e8c-465f-43ac-9a81-1f180c3fd47f" });
        }
    }
}
