using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using FCD.Authorization.Roles;
using FCD.Configuration;
using FCD.MultiTenancy;
using FCD.Users;
using FCD.Web;
using FCD.Invoices;

namespace FCD.EntityFramework
{
    [DbConfigurationType(typeof(FCDDbConfiguration))]
    public class FCDDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public IDbSet<InvoiceTemplate> InvoiceTemplates { get; set; }
        public IDbSet<InvoiceTemplateField> InvoiceTemplateFields { get; set; }
        public IDbSet<Invoice> Invoices { get; set; }
        public IDbSet<InvoiceField> InvoiceFields { get; set; }

        /* Default constructor is needed for EF command line tool. */
        public FCDDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                FCDConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of FCDDbContext since ABP automatically handles it.
         */
        public FCDDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public FCDDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }

    public class FCDDbConfiguration : DbConfiguration
    {
        public FCDDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
