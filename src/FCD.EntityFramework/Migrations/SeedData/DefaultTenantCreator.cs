using System.Linq;
using FCD.EntityFramework;
using FCD.MultiTenancy;

namespace FCD.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly FCDDbContext _context;

        public DefaultTenantCreator(FCDDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
