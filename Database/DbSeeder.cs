using System;
using System.Collections.Generic;
using System.Linq;
using MultiTenant.Models;

namespace MultiTenant.Database
{
    public class DbSeeder
    {
        private readonly GlobalDbContext _context;

        public DbSeeder(GlobalDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            var tenants = new List<Tenant>()
            {
                new Tenant()
                {
                    Guid = new Guid("43ce6f06-a472-461f-b990-3a25c7f44b7a"),
                    Name = "TenantOne",
                    ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=MT_TenantOne;Trusted_Connection=true;MultipleActiveResultSets=true"
                },
                new Tenant()
                {
                    Guid = new Guid("199b625e-6ac6-4757-a38f-9a0391866469"),
                    Name = "TenantTwo",
                    ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=MT_TenantTwo;Trusted_Connection=true;MultipleActiveResultSets=true"
                }
            };
            if (!_context.Tenants.Any())
            {
                _context.Tenants.AddRange(tenants);
                _context.SaveChanges();
            }
        }
    }
}