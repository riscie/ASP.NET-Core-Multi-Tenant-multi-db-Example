using Microsoft.EntityFrameworkCore;
using MultiTenant.Models;

namespace MultiTenant.Database
{
    public class GlobalDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options)
        {
        }
    }
}