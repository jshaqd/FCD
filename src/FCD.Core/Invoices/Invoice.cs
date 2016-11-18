using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCD.Invoices
{
    public class Invoice: Entity
    {
        [Key]
        [Column("InvoiceId")]
        public override int Id { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual int? InvoiceTemplateId { get; set; }       

        public virtual List<InvoiceField> Fields { get; set; }

        public virtual InvoiceTemplate InvoiceTemplate { get; set; }
    }
}
