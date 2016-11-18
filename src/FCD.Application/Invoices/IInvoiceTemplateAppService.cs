using Abp.Application.Services;
using System;

namespace FCD.Invoices
{
    public interface IInvoiceTemplateAppService : ICrudAppService<InvoiceTemplateDto, Guid,
         GetAllInvoiceTemplatesDto,
         CreateInvoiceTemplateDto,
         UpdateInvoiceTemplateDto>
    {
    }
}