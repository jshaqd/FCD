using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCD.Invoices
{
    public class InvoiceField :Entity
    {
        [Key]
        [Column("InvoiceFieldId")]
        public override int Id { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual int? InvoiceId { get; set; }

        public virtual int InvoiceTemplateFieldId { get; set; }

        public virtual string FieldValue { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual InvoiceTemplateField TemplateField { get; set; }
    }
}
