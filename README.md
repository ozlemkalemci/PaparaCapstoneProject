# 📘 Papara Masraf Yönetim Sistemi – Backend API

Bu proje, bir şirket bünyesinde sahada çalışan personelin masraflarını yönetebilmesi, yöneticilerin bu masrafları onaylayıp banka simülasyonu üzerinden ödeme yapabilmesi amacıyla geliştirilmiş modüler bir .NET 8 Web API çözümüdür.

## 🔧 Teknoloji Yığını

- .NET 8 Web API
- Entity Framework Core (Code First)
- MediatR + CQRS + FluentValidation
- Dapper (raporlama için)
- Redis (JWT Blacklist için)
- MSSQL (PaparaDb, BankDb)
- Swagger / Postman
- Stored Procedure & View

## 🔐 Kimlik Doğrulama

- JWT + Refresh Token
- Redis ile token blacklist kontrolü
- Login sonrası token Postman değişkenine otomatik atanır

```http
Authorization: Bearer {{bearerToken}}
```

## 🧩 Modüller

### 🔑 Auth
- `POST /api/auth/login`
- `POST /api/auth/register`
- `POST /api/auth/logout`
- `POST /api/auth/refresh-token`

### 👤 Kullanıcı Yönetimi
- Çalışanlar: `GET/POST/PUT/DELETE /api/employees`
- Adresler: `.../employeeaddresses`
- Telefonlar: `.../employeephones`
- Departmanlar: `.../departments`

### 💰 Masraf Yönetimi
- Masraflar: `.../expenses`
- Masraf Türleri: `.../expensetypes`
- Dosya Eki: `.../expenseattachments`

### ✔️ Masraf Onay / Red
- Onay: `POST /api/expense-approvals`
- Red: `POST /api/expense-approvals/revert/{id}`

### 🏦 Banka Simülasyonu
- Masraf onayı sonrası otomatik simülasyon ile ödeme yapılır (`BankDbContext`)
- Ödeme detayları `ExpensePayment` tablosunda tutulur

### 📊 Raporlama (Dapper + SP + View)
#### API Endpoint’leri:
- `GET /api/reports/personnel-history?employeeId=3`
- `GET /api/reports/admin-summary?period=weekly`
- `GET /api/reports/personnel-summary?period=weekly`
- `GET /api/reports/approval-status-summary?period=weekly`

#### Teknik:
- `vw_PersonnelExpenseHistory` – View
- `sp_GetAdminExpenseSummaryReport` – SP
- `sp_GetPersonnelSpendingSummary` – SP
- `sp_GetExpenseApprovalStatusSummary` – SP

## 🛠️ Kurulum

### 1️⃣ Bağımlılıklar

> Redis çalışır durumda olmalıdır:

---

## ⚙️ appsettings.json Yapılandırması

```json
"ConnectionStrings": {
  "PaparaSqlConnection": "Server=YOUR_SERVER;Initial Catalog=PaparaDb;Integrated Security=true;TrustServerCertificate=True;",
  "BankSqlConnection": "Server=YOUR_SERVER;Initial Catalog=BankDb;Integrated Security=true;TrustServerCertificate=True;"
},
                        
"RedisConnection": "localhost:6379",
                        
"JwtSettings": {
  "SecretKey": "YOUR_SECRET_KEY",
  "Issuer": "Papara.Auth",
  "Audience": "Papara.WebApi",
  "ExpirationInMinutes": 60
},
                        
"FileSettings": {
  "RootPath": "UploadedFiles"
}
```

> 🔔 **Not:** `YOUR_SERVER` ve `YOUR_SECRET_KEY` alanlarını kendi ortamınıza göre güncelleyin. Redis servisinizin çalıştığından emin olun.

---

### 2️⃣ Migration & Database Kurulumu

```bash
dotnet ef migrations add InitialCreate_App --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext --output-dir Migrations/Papara
dotnet ef migrations add InitialCreate_Bank --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext --output-dir Migrations/Bank

dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext
```

> 📌 Bu işlemler sonrası **Stored Procedure** ve **View** otomatik oluşturulacaktır.

### 3️⃣ Uygulama Başlatma

```bash
cd src/Presentation/Papara.WebApi
dotnet run
```

### 4️⃣ Swagger Arayüzü

[http://localhost:7171/swagger](http://localhost:7171/swagger)

## 📂 Dosya Sistemi

```text
├── Base
│   ├── Application
│   ├── Infrastructure
│   ├── Persistence
├── Papara
│   ├── Application
│   ├── Domain
├── src
│   └── Presentation
│       └── Papara.WebApi
```

## 🧪 Test Senaryoları

- Personel login olur → Masraf girer → Dosya yükler
- Admin login olur → Masrafı onaylar → Ödeme yapılır
- Raporlar kontrol edilir (Dapper SP + View üzerinden)

## 📎 Ekstra Bilgiler

- Dosyalar `UploadedFiles/` klasörüne kaydedilir (varsa .gitignore’dan çıkarılmalı)
- Enum’lar `GetDisplayName()` ile metinsel gösterime çevrilir
- Validasyon hataları 400 dönülür, global exception handler yapılandırılmıştır

## 👨‍💻 Geliştirici Bilgisi

> Geliştirici: Özlem Kalemci
> Proje: Papara Expense Management  
> Tarih: Mayıs 2025
