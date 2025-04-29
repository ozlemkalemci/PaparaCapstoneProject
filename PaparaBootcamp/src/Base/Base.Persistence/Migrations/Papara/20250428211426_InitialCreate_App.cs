using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Base.Persistence.Migrations.Papara
{
    /// <inheritdoc />
    public partial class InitialCreate_App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Corporation");

            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Corporation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyIBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Corporation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false),
                    OpenDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Corporation",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Base",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TokenSalt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Expiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Base",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddresses",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhones",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpenseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpenseTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalSchema: "Finance",
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseApprovals",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseApprovals_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalSchema: "Finance",
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseAttachments",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalSchema: "Finance",
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Corporation",
                table: "Companies",
                columns: new[] { "Id", "CompanyIBAN", "CompanyName", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsActive", "TaxNumber", "UpdatedById", "UpdatedDate" },
                values: new object[] { 1L, "TR000000000000000000000999", "Papara Şirketi", 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 20, DateTimeKind.Unspecified).AddTicks(5052), new TimeSpan(0, 0, 0, 0, 0)), null, null, true, "1234567890", null, null });

            migrationBuilder.InsertData(
                schema: "Corporation",
                table: "Departments",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "DepartmentName", "IsActive", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 20, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Yönetim", true, null, null },
                    { 2L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 20, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Operasyon", true, null, null },
                    { 3L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 20, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Finans", true, null, null },
                    { 4L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 20, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Yazılım Geliştirme", true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Finance",
                table: "ExpenseTypes",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Description", "IsActive", "Name", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5381), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ulaşım biletleri (uçak, tren, taksi vb.)", true, "Ulaşım", null, null },
                    { 2L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5384), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Yakıt, bakım, otopark, otoyol geçişleri", true, "Araç Giderleri", null, null },
                    { 3L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5385), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Kişisel yemek harcamaları", true, "Yemek", null, null },
                    { 4L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5387), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Otel, konaklama giderleri", true, "Konaklama", null, null },
                    { 5L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 0, 0, 0, 0)), null, null, "İlaç, hastane, tedavi vs.", true, "Sağlık Harcamaları", null, null },
                    { 6L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5389), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Eğitim programları, sertifika ücretleri", true, "Eğitim ve Sertifikalar", null, null },
                    { 7L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5390), new TimeSpan(0, 0, 0, 0, 0)), null, null, "GSM faturaları, internet", true, "Telekomünikasyon", null, null },
                    { 8L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5391), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ofis ekipmanları, kırtasiye", true, "Ofis ve Kırtasiye Giderleri", null, null },
                    { 9L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 654, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Müşteri ağırlama, toplantı ikramları", true, "Ağırlama ve İkram", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Base",
                table: "Users",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Email", "IsActive", "LastLoginDate", "OpenDate", "PasswordHash", "Role", "Secret", "UpdatedById", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), null, null, "admin@papara.com", true, null, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$jAtiDpJSiBwBboPwrI8n9.uDldI.jW77aq9MaSwZVb0Odd6vKKO7G", (byte)1, "a1f91392-0470-4487-affa-6528d19818ba", null, null, "admin" },
                    { 2L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), null, null, "ozlem.kalemci@papara.com", true, null, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$YHVG/PhIa1vHV9QD5wqqt.ZgMSnsZJToLiExodghzwGABil49lFKi", (byte)2, "8197572f-2184-41ee-b5b3-f6c7f16a74d6", null, null, "ozlem.kalemci" },
                    { 3L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), null, null, "personel@papara.com", true, null, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 25, 655, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)), "$2a$11$jY3nIcvSigoZgON3gj43YurWDScDUzSj2g6CuiEmsYryaow7JZlGG", (byte)2, "f0abaffd-d7eb-456d-9e3b-a23f3bf360d0", null, null, "personel1" }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "Employees",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "DepartmentId", "FirstName", "IBAN", "IdentityNumber", "IsActive", "LastName", "MiddleName", "UpdatedById", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 23, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 0, 0, 0, 0)), null, null, 1L, "Papara", "TR000000000000000000000000", "23456789012", true, "Admin", null, null, null, 1L },
                    { 2L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 23, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 0, 0, 0, 0)), null, null, 4L, "Özlem", "TR000000000000000000000001", "12345678901", true, "Kalemci", null, null, null, 2L },
                    { 3L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 23, DateTimeKind.Unspecified).AddTicks(6062), new TimeSpan(0, 0, 0, 0, 0)), null, null, 2L, "Personel", "TR000000000000000000000002", "34567890123", true, "Personel", null, null, null, 3L }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "EmployeeAddresses",
                columns: new[] { "Id", "City", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "Detail", "District", "EmployeeId", "IsActive", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Eskişehir", 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 22, DateTimeKind.Unspecified).AddTicks(6445), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Çamlıca mahallesi Figen sokak civarı", "Tepebaşı", 2L, true, null, null },
                    { 2L, "İstanbul", 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 22, DateTimeKind.Unspecified).AddTicks(6445), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Bahariye Caddesi", "Kadıköy", 3L, true, null, null }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "EmployeePhones",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "EmployeeId", "IsActive", "IsPrimary", "PhoneNumber", "Type", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 23, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 0, 0, 0, 0)), null, null, 2L, true, true, "5551234567", (byte)1, null, null },
                    { 2L, 0L, new DateTimeOffset(new DateTime(2025, 4, 28, 21, 14, 26, 23, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 0, 0, 0, 0)), null, null, 3L, true, true, "2129876543", (byte)3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_EmployeeId",
                schema: "HR",
                table: "EmployeeAddresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhones_EmployeeId",
                schema: "HR",
                table: "EmployeePhones",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                schema: "HR",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "HR",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseApprovals_ExpenseId",
                schema: "Finance",
                table: "ExpenseApprovals",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseAttachments_ExpenseId",
                schema: "Finance",
                table: "ExpenseAttachments",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeeId",
                schema: "Finance",
                table: "Expenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                schema: "Finance",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "Base",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Base",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Corporation");

            migrationBuilder.DropTable(
                name: "EmployeeAddresses",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmployeePhones",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ExpenseApprovals",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "ExpenseAttachments",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ExpenseTypes",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Corporation");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Base");
        }
    }
}
