using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace FCD.Invoices
{
    public class InvoiceTemplateField : CreationAuditedEntity, IMustHaveTenant
    {
        public const int MaxInvoiceTemplateFieldNameLength = 255;

        public const int MaxInvoiceTemplateFieldDisplayNameLength = 2048;

        public const int MaxInvoiceTemplateFieldTypeLength = 1024;

        [Key]
        [Column("InvoiceTemplateFieldId")]
        public override int Id { get; set; }

        public int TenantId { get; set; }

        [MaxLength(MaxInvoiceTemplateFieldNameLength)]
        public virtual string InvoiceTemplateFieldName { get; set; }

        [MaxLength(MaxInvoiceTemplateFieldDisplayNameLength)]
        public virtual string InvoiceTemplateFieldDisplayName { get; set; }

        [MaxLength(MaxInvoiceTemplateFieldTypeLength)]
        public virtual string InvoiceTemplateFieldType { get; set; }

        [ForeignKey("InvoiceTemplateId")]
        public virtual InvoiceTemplate InvoiceTemplate { get; protected set; }
        public virtual Guid InvoiceTemplateId { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create InvoiceTemplateField using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        //protected InvoiceTemplateField()
        //{

        //}

        //public static InvoiceTemplateField Create(InvoiceTemplate invoiceTemplate, string fieldName, string displayName, string fieldType)
        //{
        //    return new InvoiceTemplateField
        //    {
        //        TenantId = invoiceTemplate.TenantId,
        //        InvoiceTemplateId = invoiceTemplate.Id,
        //        InvoiceTemplate = invoiceTemplate,
        //        InvoiceTemplateFieldName = fieldName,
        //        InvoiceTemplateFieldDisplayName = displayName,
        //        InvoiceTemplateFieldType = fieldType
        //    };
        //}
    }
}
