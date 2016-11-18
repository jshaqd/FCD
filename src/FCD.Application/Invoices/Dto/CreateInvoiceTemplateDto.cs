using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FCD.Invoices
{
    [AutoMapTo(typeof(InvoiceTemplate))]
    public class CreateInvoiceTemplateDto
    {
        [Required]
        [MaxLength(InvoiceTemplate.MaxInvoiceTemplateNameLength)]
        public string InvoiceTemplateName { get; set; }

        //[Required]
        public byte[] InvoiceTemplateFile { get; set; }

        public decimal PageWidth { get; set; }

        public decimal PageHeigth { get; set; }

        public int? TenantId { get; set; }
    }   
}
