using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MultiTenant.Database;

namespace MultiTenant.Middleware
{
    public class TenantIdentifier
    {
        private readonly RequestDelegate _next;

        public TenantIdentifier(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, GlobalDbContext dbContext)
        {
            var tenantGuid = httpContext.Request.Headers["X-Tenant-Guid"].FirstOrDefault();
            if (!string.IsNullOrEmpty(tenantGuid))
            {
                var tenant = dbContext.Tenants.FirstOrDefault(t => t.Guid.ToString() == tenantGuid);
                httpContext.Items["TENANT"] = tenant;
            }

            await _next.Invoke(httpContext);
        }
    }


    public static class TenantIdentifierExtension
    {
        public static IApplicationBuilder UseTenantIdentifier(this IApplicationBuilder app)
        {
            app.UseMiddleware<TenantIdentifier>();
            return app;
        }
    }
}