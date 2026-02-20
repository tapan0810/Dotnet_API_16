using Dotnet_API_16.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_16.Data
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
        public DbSet<Company> Companies =>Set<Company>();
    }
}
