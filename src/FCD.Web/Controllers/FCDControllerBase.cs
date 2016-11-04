using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace FCD.Web.Controllers
{
    public abstract class FCDControllerBase: AbpController
    {
        protected FCDControllerBase()
        {
            LocalizationSourceName = FCDConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}