# Interview: Cities and restaurants

  - MS SQL Server database backup (attached): RestaurantDb.bak
  - You must set connection string by create env `ConnectionStrings:RestaurantCS` in env variables or add corresponding entry into appsettings.json
  - You can scaffold db manually by code first migration, but you still must set env `ConnectionStrings:RestaurantCS` to PMC or globally.  You need latest EF core EF tools (>=5.0.0)
  
  `dotnet ef migrations add Init --project EFCore`
  
  `dotnet ef database update --project EFCore`

  - Swagger available by http://localhost:5000/swagger
