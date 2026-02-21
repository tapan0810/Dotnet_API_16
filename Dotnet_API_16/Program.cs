using Dotnet_API_16.Data;
using Dotnet_API_16.Helper.JwtHelper;
using Dotnet_API_16.Services.AuthService;
using Dotnet_API_16.Services.CompanyService;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IJwtHelper, JwtHelper>();

builder.Services.AddDbContext<CompanyDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
