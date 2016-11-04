using Abp.AspNetCore.Mvc.Authorization;
using FCD.Authorization;
using FCD.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace FCD.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : FCDControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}