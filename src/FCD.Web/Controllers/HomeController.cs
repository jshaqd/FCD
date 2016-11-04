using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCD.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FCDControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}