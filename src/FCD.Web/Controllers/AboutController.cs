using Microsoft.AspNetCore.Mvc;

namespace FCD.Web.Controllers
{
    public class AboutController : FCDControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}