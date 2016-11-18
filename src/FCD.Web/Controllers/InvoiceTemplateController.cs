using Microsoft.AspNetCore.Mvc;
using FCD.Invoices;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FCD.Web.Controllers
{
    //[AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class InvoiceTemplateController : FCDControllerBase
    {
        private readonly IInvoiceTemplateAppService _invoiceTemplateAppService;

        public InvoiceTemplateController(IInvoiceTemplateAppService invoiceTemplateAppService)
        {
            _invoiceTemplateAppService = invoiceTemplateAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
