using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCD.Invoices
{
    public class InvoiceTemplate: FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxInvoiceTemplateNameLength = 255;

        [Key]
        [Column("InvoiceTemplateId")]
        public override Guid Id { get; set; }

        public virtual int TenantId { get; set; }

        [Required]
        [MaxLength(MaxInvoiceTemplateNameLength)]
        public virtual string InvoiceTemplateName { get; set; }

        public virtual byte[] InvoiceTemplateFile { get; set; }

        public virtual decimal PageWidth { get; set; }

        public virtual decimal PageHeigth { get; set; }

        [ForeignKey("InvoiceTemplateId")]
        public virtual ICollection<InvoiceTemplateField> Fields { get; set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        //protected InvoiceTemplate()
        //{

        //}

        //public static InvoiceTemplate Create(int tenantId, string name, byte[] file, decimal pageWidth, decimal pageHeigth)
        //{
        //    var invoiceTemplate = new InvoiceTemplate
        //    {
        //        Id = Guid.NewGuid(),
        //        TenantId = tenantId,
        //        InvoiceTemplateName = name,
        //        InvoiceTemplateFile = file,
        //        PageWidth = pageWidth,
        //        PageHeigth = pageHeigth
        //    };

        //   invoiceTemplate.Fields = new Collection<InvoiceTemplateField>();

        //    return invoiceTemplate;
        //}
    }
}
