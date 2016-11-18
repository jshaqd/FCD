using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace FCD.Invoices
{
    [AutoMapTo(typeof(InvoiceTemplate))]
    public class UpdateInvoiceTemplateDto: CreateInvoiceTemplateDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
