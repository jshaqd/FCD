using FCD.EntityFramework;
using EntityFramework.DynamicFilters;

namespace FCD.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FCDDbContext _context;

        public InitialHostDbBuilder(FCDDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
