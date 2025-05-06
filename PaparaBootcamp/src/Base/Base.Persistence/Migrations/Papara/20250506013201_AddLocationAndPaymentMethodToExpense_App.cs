using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Persistence.Migrations.Papara
{
    /// <inheritdoc />
    public partial class AddLocationAndPaymentMethodToExpense_App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "Finance",
                table: "Expenses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PaymentMethod",
                schema: "Finance",
                table: "Expenses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 340, DateTimeKind.Unspecified).AddTicks(3634), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 340, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 340, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 340, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 340, DateTimeKind.Unspecified).AddTicks(6952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 342, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 342, DateTimeKind.Unspecified).AddTicks(4516), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 343, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 343, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 343, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 343, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 343, DateTimeKind.Unspecified).AddTicks(2827), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7799), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7801), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7802), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7803), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7804), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7805), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 0, DateTimeKind.Unspecified).AddTicks(7806), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$1SAO5DJ3/4a8iG1mkvYUM.qMt2LOUsZz4m8vH9E/zIcChFz90WkXa", "a80bf3fe-2d1f-4b69-8885-0115ad2e2d97" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$VZxT/2w7H1eym90zUtAUX.2UqI3q1LPOTHnjD73L16KvFb.R3F.PO", "7b9a5754-122f-4daf-8de3-b58c50a372f0" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 6, 1, 32, 1, 1, DateTimeKind.Unspecified).AddTicks(5008), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$z7TyM/WAUJ4IAZDGb/GCKuBwsaDO9HdJEo8sLsx1asYwa9PvEE0s6", "90c5e80d-9904-4232-828f-711e9a9db6fe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "Finance",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                schema: "Finance",
                table: "Expenses");

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 644, DateTimeKind.Unspecified).AddTicks(3596), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 644, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 644, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 644, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Corporation",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 644, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 646, DateTimeKind.Unspecified).AddTicks(4364), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 646, DateTimeKind.Unspecified).AddTicks(4364), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 647, DateTimeKind.Unspecified).AddTicks(7415), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmployeePhones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 647, DateTimeKind.Unspecified).AddTicks(7415), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 647, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 647, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 647, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(945), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(952), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(980), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(985), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Finance",
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(986), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$ziFo2.s3cw.CUN8LGcDvf.SpDpIkR0GF9LwS2rD7SSCA3J0/Nr90q", "fedf42ce-b648-4408-87a3-2748b33bbe6f" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$Gt9Syv6XF0gYISnzVKHwKOm626elyMDsrEcrxd0nbZH9EjOJIQbYq", "e94c11a8-0df9-48ea-9995-0e2a3bae18ba" });

            migrationBuilder.UpdateData(
                schema: "Base",
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "OpenDate", "PasswordHash", "Secret" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 5, 4, 19, 53, 46, 296, DateTimeKind.Unspecified).AddTicks(8384), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$B6uJB0q4vhbn.MMhRA4Ccunqyf0ISCm2iyFLE9jpAVGD4nA8xr7Qe", "87491126-4439-4498-b96b-7074fab9e23f" });
        }
    }
}
