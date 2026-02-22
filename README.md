🚀 Dotnet_API_16

A cleanly structured ASP.NET Core Web API project implementing:

JWT Authentication

Role-based Authorization

Entity Framework Core with SQL Server

Service-based architecture

Swagger/OpenAPI documentation

Scalar API reference

📌 Project Overview

This project is a modular and scalable Web API built using .NET 8 / .NET 6+ style minimal hosting model.

It follows a layered architecture:

Controllers → Services → Data → Database
           ↘ JwtHelper
🏗️ Project Structure
Dotnet_API_16
│
├── Controllers          # API Controllers (Auth, Company, etc.)
├── Data                 # DbContext configuration
├── Entities             # Database models
├── Helper/JwtHelper     # JWT token generation logic
├── Services
│   ├── AuthService      # Authentication logic
│   └── CompanyService   # Business logic
├── Migrations           # EF Core migrations
├── Program.cs           # Application entry point
├── appsettings.json     # Configuration settings
└── Dotnet_API_16.csproj
🔐 Features
✅ JWT Authentication

Secure login endpoint

Token generation using symmetric security key

Claims-based identity

✅ Service-Based Architecture

Clean separation of concerns

Business logic abstracted via interfaces

✅ Entity Framework Core

SQL Server integration

Code-first migrations

Scoped DbContext

✅ OpenAPI & Scalar

Swagger/OpenAPI documentation

Scalar API Reference integration

🛠️ Technologies Used

ASP.NET Core Web API

Entity Framework Core

SQL Server

JWT (System.IdentityModel.Tokens.Jwt)

Scalar.AspNetCore

OpenAPI

⚙️ Setup Instructions
1️⃣ Clone Repository
git clone <your-repository-url>
cd Dotnet_API_16
2️⃣ Configure Database

Update appsettings.json:

{
  "ConnectionStrings": {
    "DeafultConnection": "Server=YOUR_SERVER;Database=CompanyDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "AppSettings": {
    "Token": "your_super_secret_key_here"
  }
}

⚠️ Ensure your JWT secret key is at least 16–32 characters long.

3️⃣ Run Migrations
dotnet ef database update

If migrations don’t exist:

dotnet ef migrations add InitialCreate
dotnet ef database update
4️⃣ Run Application
dotnet run

Application will start at:

https://localhost:xxxx
🔑 Authentication Flow

User registers/logs in

AuthService validates credentials

JwtHelper generates token

Token is returned to client

Client sends token in header:

Authorization: Bearer {your_token}
🧠 Dependency Injection

Services registered in Program.cs:

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

DbContext:

builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection")));
🚀 Future Improvements

Refresh token implementation

Role-based authorization policies

Global exception middleware

Logging with Serilog

Docker containerization

CI/CD pipeline integration

📄 API Documentation

Available in Development mode:

OpenAPI JSON endpoint

Scalar API Reference UI

🧪 Testing

You can test endpoints using:

Swagger UI

Scalar API UI

Postman

Thunder Client

📌 Author

Tapan Ray
Software Engineer
