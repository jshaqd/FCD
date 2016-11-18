using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace FCD.Invoices
{
    [AutoMap(typeof(InvoiceTemplate))]
    public class InvoiceTemplateDto : EntityDto<Guid>
    {
        public string InvoiceTemplateName { get; set; }

        public byte[] InvoiceTemplateFile { get; set; }

        public decimal PageWidth { get; set; }

        public decimal PageHeigth { get; set; }

        public int? TenantId { get; set; }
    }
}
