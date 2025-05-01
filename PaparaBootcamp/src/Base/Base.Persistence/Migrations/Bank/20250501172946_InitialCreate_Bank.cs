using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Base.Persistence.Migrations.Bank
{
    /// <inheritdoc />
    public partial class InitialCreate_Bank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bank");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpensePayments",
                schema: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenderIBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    ReceiverIBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    TransferType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensePayments", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Bank",
                table: "BankAccounts",
                columns: new[] { "Id", "AccountHolderName", "AccountType", "IBAN", "IdentityNumber", "TaxNumber" },
                values: new object[,]
                {
                    { 1L, "Papara Şirketi", (byte)2, "TR000000000000000000000999", null, "1234567890" },
                    { 2L, "Özlem Kalemci", (byte)1, "TR000000000000000000000001", "12345678901", null },
                    { 3L, "Personel Personel", (byte)1, "TR000000000000000000000002", "34567890123", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "Bank");

            migrationBuilder.DropTable(
                name: "ExpensePayments",
                schema: "Bank");
        }
    }
}
