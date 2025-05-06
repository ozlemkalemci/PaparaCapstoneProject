<a name="readme-top"></a>
<h2 align="center">
📘 Papara Masraf Yönetim Sistemi – Fullstack (Backend + Frontend)
</h2>
<h3 align="center">
Bitirme Projesi
  </h3>
<br/>

https://github.com/user-attachments/assets/87e1e194-7a44-4dec-84e2-664d44ba14b1


---
# Proje Hakkında

Bu proje, bir şirket bünyesinde sahada çalışan personelin masraflarını yönetebilmesi, yöneticilerin bu masrafları onaylayıp **banka simülasyonu** üzerinden ödeme yapabilmesi amacıyla geliştirilmiş **modüler**, **güvenli** ve **dokümente edilmiş** bir **.NET 8 Web API** + **Blazor WebAssembly** çözümüdür. Proje amacı, sahada çalışan personelin masraf taleplerini hızlıca sisteme girmesini, yöneticilerin bu talepleri değerlendirmesini ve onaylanan talepler için **banka simülasyonu aracılığıyla otomatik ödeme** yapılmasını sağlar. Amaç, manuel fiş toplama süreçlerini dijitalleştirerek hem çalışan hem yönetici verimliliğini artırmaktır.

---

## 🔧 Teknoloji Yığını

### Backend
- .NET 8 Web API
- Entity Framework Core (Code First)
- MediatR + CQRS + FluentValidation
- Dapper (raporlama için)
- Redis (JWT Blacklist için)
- MSSQL (PaparaDb, BankDb)
- Swagger / Postman
- Stored Procedure & View

### Frontend
- Blazor WebAssembly
- JWT Token + LocalStorage
- Blazored.Toast + Blazored.LocalStorage
- Role-based authorization
- Responsive, sade tasarım

---


## ⚙️ Kurulum

### 1. Redis Gereksinimi
Redis bağlantısı aktif olmalıdır.

```bash
docker run -p 6379:6379 redis
```

### 2. appsettings.json Ayarları

Kullanılan connection ayarları appsettings.json klasöründe düzenlenmelidir
```json
"ConnectionStrings": {
  "PaparaSqlConnection": "Server=YOUR_SERVER;Initial Catalog=PaparaDb;Integrated Security=true;TrustServerCertificate=True;",
  "BankSqlConnection": "Server=YOUR_SERVER;Initial Catalog=BankDb;Integrated Security=true;TrustServerCertificate=True;"
},
"RedisConnection": "localhost:6379"
```

---

## 🧱 Migration Komutları

Projede migration işlemleri aşağıdaki komutlarla yapılmıştır:
```bash
dotnet ef migrations add InitialCreate_App --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext --output-dir Migrations/Papara
dotnet ef migrations add InitialCreate_Bank --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext --output-dir Migrations/Bank
```
Projeyi klonlayan kişinin ise migrationları şu komutlar ile update etmesi gerekmektedir:
```bash
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext
```

> Stored Procedure ve View yapıları da migration içinde yer alır.

---

## 🚀 Uygulama Başlatma
### 1. WebAPI ve Blazor projelerini birlikte çalıştırmak için:
Visual Studio’da Configure Startup Projects > Multiple Startup Projects seçeneğini aktif edin.
Papara.WebApi ve Papara.Wasm projelerini Start olarak işaretleyin.

### 2. Komutla başlatmak için:
#### Backend
```bash
cd src/Presentation/Papara.WebApi
dotnet run
```

#### Frontend
```bash
cd src/Presentation/Papara.Wasm
dotnet run
```

> Giriş sonrası kullanıcıya özel içerik, sidebar ve yetkili işlemler görünür.

---

## 📘 Swagger Arayüzü
[http://localhost:7171/swagger](http://localhost:7171/swagger)

## 📬 Postman
- `docs/Papara.postman_collection.json` dosyasını import edin
- `{{baseUrl}} = https://localhost:7171`

---

## 🔐 Kimlik Doğrulama
- JWT + Refresh Token + Redis Blacklist
- `Authorization: Bearer {{bearerToken}}`

---

## 🧩️ Ödeme Mantığı – IBAN Eşleme
- Masraf talebi onaylandığı anda, **ilgili personele banka simülasyonu servisi ile otomatik ödeme** yapılır.
- Bunun için personelin **IBAN bilgisi ile birebir eşleşen bir `BankAccount`** oluşturulması gerekir.
- Bu işlem frontend tarafından yapılmaz; çünkü şirketin masraf yönetimi ile banka tarafı ayrı işlerdir.
- Swagger veya Postman kullanarak `/api/bankaccounts` endpoint'i üzerinden IBAN'a sahip hesap açılmalıdır.

---

## 📉 Modüler

### 🔑 Auth
- Login, Register, Refresh

### 👤 Kullanıcı Yönetimi
- Employee, Phone, Address, Department CRUD

### 💰 Masraf Yönetimi
- Expense CRUD, Attachments, Expense Types

### ✔️ Onaylama / Red
- Expense Approvals + Red Açıklama

### 🏦 Banka Simülasyonu
- Approval sonrası otomatik ödeme işlemi
- BankDbContext + ExpensePayment
- Banka hesabı (IBAN) Swagger ya da Postman ile açılmalıdır

### 📊 Raporlama
- Admin & Personel için SP + View üzerinden 4 farklı rapor

---

## 📊 Rapor Endpointleri
- `/api/reports/personnel-history`
- `/api/reports/admin-summary`
- `/api/reports/personnel-summary`
- `/api/reports/approval-status-summary`

---

## 🧰 Test Senaryoları
- Personel giriş yapar → masraf girer → belge yükler
- Admin giriş yapar → talepleri onaylar/red eder → banka simülasyonu
- Raporlar filtrelenerek incelenir

---

## 🧑‍💼 Rollere Göre Yetki
| Modül                  | Admin | Employee |
|------------------------|--------|----------|
| Auth                   | ✅     | ✅        |
| Employee CRUD          | ✅     | Kendi     |
| Department CRUD        | ✅     | ❌        |
| Expense CRUD           | ✅     | Kendi     |
| Approvals              | ✅     | ❌        |
| Attachments            | ✅     | Kendi     |
| Reports                | ✅     | Kendi     |
| Bank Payment           | ✅     | ❌        |

---

## 👤 Seed Kullanıcılar ve Varsayılan Veriler

**Kullanıcılar:**
- `admin` / `admin123`
- `ozlem.kalemci` / `Ozlem123`
- `personel1` / `personel123`

**BankAccount:**
- Papara Şirketi (Kurumsal) → `TR...999`
- Özlem Kalemci (Bireysel) → `TR...001`
- Personel Personel (Bireysel) → `TR...002`

**Company:**
- Papara Şirketi (Vergi No: 1234567890)

**Department:**
- Yönetim, Operasyon, Finans, Yazılım Geliştirme

**ExpenseType:**
- Ulaşım, Yemek, Sağlık, Konaklama vb. 9 farklı gider tipi

**Employee:**
- Admin, Özlem Kalemci ve Personel’e ait 3 kayıt
- Adres ve telefon bilgileri dahil

---

## 📂 Proje Yapısı

![d-removebg-preview (2)](https://github.com/user-attachments/assets/142623a0-9fbc-4f88-94d3-423dc50c9de1)

Mimaride Onion Architecture uygulanmış, ayrıca Clean Architecture prensiplerine de uygun bir yapı kurulmuştur. Bu yapı sayesinde test edilebilir, sürdürülebilir ve bağımsız modüller geliştirilmiştir.

Katmanlar:

Domain: Saf iş kuralları ve entity tanımları

Application: Use-case'ler ve CQRS komutları

Infrastructure: Harici servis, dosya sistemi, Redis, Dapper vb.

Persistence: EF Core, DbContext, Migrations, Seed işlemleri

Presentation: Web API & Blazor WebAssembly arayüzü

```text
└── src
  └── Base
    ├── Base.Application
    ├── Base.Domain
    ├── Base.Infrastructure
    └── Base.Persistence
  └── Papara
    ├── Papara.Application
    └── Papara.Domain
  └── Presentation
        ├── Papara.WebApi (Backend)
        └── Papara.Wasm (Frontend)
└── docs
    └── Papara.postman_collection.json
```

---

## 📎 Ekstra
- `UploadedFiles/` klasörüne dosyalar yüklenir (gitignore'dan çıkarılmalı)
- Tüm alanlarda gerekli validasyonlar FluentValidation ile sağlanmıştır
- Enum display işlemleri `GetDisplayName()` ile yapılır

---

## 👨‍💼 Geliştirici Bilgisi
> Geliştirici: Özlem Kalemci  
> Proje: Papara Expense Management (Fullstack)  
> Tarih: Mayıs 2025
