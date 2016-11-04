using Abp.Authorization;
using FCD.Authorization.Roles;
using FCD.MultiTenancy;
using FCD.Users;

namespace FCD.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
