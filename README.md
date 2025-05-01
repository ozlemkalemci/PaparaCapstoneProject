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
- Giriş (/api/auth/login) sonrası accessToken, bearerToken değişkenine otomatik olarak aktarılır
- Tüm yetkili isteklerde şu header kullanılmalıdır:

```http
Authorization: Bearer {{bearerToken}}
```

- Token süresi dolduğunda /api/auth/refresh-token ile yenilenir.

## ⚙️ Kurulum Bilgisi

Redis bağlantısı açık olmalıdır. `appsettings.json` dosyasına aşağıdaki ayarları eklemeyi ve ConnectionStringlerinizi düzenlemeyi unutmayın:

```json
"ConnectionStrings": {
  "PaparaSqlConnection": "Server=YOUR_SERVER;Initial Catalog=PaparaDb;Integrated Security=true;TrustServerCertificate=True;",
  "BankSqlConnection": "Server=YOUR_SERVER;Initial Catalog=BankDb;Integrated Security=true;TrustServerCertificate=True;"
},

"RedisConnection": "localhost:6379"

```

> Redis ayağa kaldırmak için:
```bash
docker run -p 6379:6379 redis
```

## 🧱 Migration Komutları

Yeni migration eklemek için:

```bash
dotnet ef migrations add InitialCreate_App --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext --output-dir Migrations/Papara
dotnet ef migrations add InitialCreate_Bank --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext --output-dir Migrations/Bank
```

Veritabanına migrationları uygulamak için:

```bash
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext
```

> 📌 Bu işlemler sonrası **Stored Procedure** ve **View** otomatik oluşturulacaktır.

## 🚀 Uygulama Başlatma

```bash
cd src/Presentation/Papara.WebApi
dotnet run
```

## 📘 Swagger Arayüzü

[http://localhost:7171/swagger](http://localhost:7171/swagger)

## 📬 Postman Kullanımı

- `docs/Papara.postman_collection.json` dosyasını Postman’e import edin
- Ortam değişkeni olarak `{{baseUrl}} = https://localhost:7171` tanımlayın
- `Auth > Login` ile giriş yapın
- Token otomatik olarak `bearerToken` değişkenine yazılır

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

- `GET /api/reports/personnel-history?employeeId=3` → Personelin kendi geçmiş harcamaları
- `GET /api/reports/admin-summary?period=monthly` → Günlük / Haftalık / Aylık harcama toplamı
- `GET /api/reports/personnel-summary?period=weekly` → Personel bazlı harcama özeti
- `GET /api/reports/approval-status-summary?period=daily` → Onay/red bazlı özet

#### Teknik Yapılar:
- `vw_PersonnelExpenseHistory` – View
- `sp_GetAdminExpenseSummaryReport` – SP
- `sp_GetPersonnelSpendingSummary` – SP
- `sp_GetExpenseApprovalStatusSummary` – SP

## 🧪 Test Senaryoları

- Personel login olur → Masraf girer → Dosya yükler
- Admin login olur → Masrafı onaylar → Ödeme yapılır
- Raporlar kontrol edilir (Dapper SP + View üzerinden)

## 👤 Seed Kullanıcılar

### 👨‍💼 Admin
- Kullanıcı Adı: `admin`
- Şifre: `admin123`

### 👷‍♂️ Personel
- Kullanıcı Adı: `personel1`
- Şifre: `personel123`

## 🗂️ Dosya Sistemi

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
├── docs
│   └── Papara.postman_collection.json
```

## 👥 Rollere Göre Yetkilendirme

| Modül                    | Admin     | Employee  |
|--------------------------|-----------|-----------|
| Auth (Login/Register)    | ✅        | ✅        |
| Department CRUD          | ✅        | ❌        |
| Employee CRUD            | ✅        | Kendi     |
| Expenses CRUD            | ✅        | Kendi     |
| Attachments              | ✅        | Kendi     |
| Approvals                | ✅        | ❌        |
| Bank Payment             | ✅        | ❌        |
| Reports                  | ✅        | Kendi     |

## 📎 Ekstra Bilgiler

- Dosyalar `UploadedFiles/` klasörüne kaydedilir (varsa .gitignore’dan çıkarılmalı)
- Enum’lar `GetDisplayName()` ile metinsel gösterime çevrilir
- Validasyon hataları 400 dönülür, global exception handler yapılandırılmıştır

## 👨‍💻 Geliştirici Bilgisi

> Geliştirici: Özlem Kalemci  
> Proje: Papara Expense Management  
> Tarih: Mayıs 2025
