# PaparaCapstoneProject

dotnet ef migrations add InitialCreate_App --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext --output-dir Migrations/Papara
dotnet ef migrations add InitialCreate_Bank --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext --output-dir Migrations/Bank


dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context AppDbContext
dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --context BankDbContext
