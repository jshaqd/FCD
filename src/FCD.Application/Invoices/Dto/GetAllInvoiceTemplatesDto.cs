using Abp.Application.Services.Dto;

namespace FCD.Invoices
{
    public class GetAllInvoiceTemplatesDto : PagedAndSortedResultRequestDto
    {
        public string SearchText { get; set; }
    }
}
