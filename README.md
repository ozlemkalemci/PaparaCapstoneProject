# PaparaCapstoneProject

dotnet ef migrations add InitialCreate --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence --output-dir Migrations

dotnet ef database update --startup-project src/Presentation/Papara.WebApi --project src/Base/Base.Persistence
