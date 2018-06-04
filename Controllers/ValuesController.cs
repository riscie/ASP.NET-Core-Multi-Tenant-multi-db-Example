using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Database;
using MultiTenant.Models;

namespace MultiTenant.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly TenantDbContext _tenantDbContext;
        private readonly Tenant _tenant;

        public ValuesController(TenantDbContext tenantDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _tenantDbContext = tenantDbContext;
            if (httpContextAccessor.HttpContext != null)
            {
                _tenant = (Tenant) httpContextAccessor.HttpContext.Items["TENANT"];
            }
        }

        // GET api/values - use X-Tenant-Guid Header (43ce6f06-a472-461f-b990-3a25c7f44b7a for TenantOne or 199b625e-6ac6-4757-a38f-9a0391866469 for TenantTwo)
        [HttpGet]
        public string Get()
        {
            _tenantDbContext.Database.EnsureCreated();
            if (!_tenantDbContext.TenantConfig.Any())
            {
                _tenantDbContext.TenantConfig.Add(new TenantConfig() {Config = $"This is the config for {_tenant.Name}. We are using the ConnectionString {_tenant.ConnectionString}"});
                _tenantDbContext.SaveChanges();
            }

            return _tenantDbContext.TenantConfig.FirstOrDefault()?.Config;
        }
    }
}