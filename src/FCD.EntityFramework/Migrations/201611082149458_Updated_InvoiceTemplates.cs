namespace FCD.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_InvoiceTemplates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceFields",
                c => new
                    {
                        InvoiceFieldId = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        InvoiceId = c.Int(),
                        InvoiceTemplateFieldId = c.Int(nullable: false),
                        FieldValue = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceFieldId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.InvoiceTemplateFields", t => t.InvoiceTemplateFieldId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.InvoiceTemplateFieldId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        InvoiceTemplateId = c.Int(),
                        InvoiceTemplate_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.InvoiceTemplates", t => t.InvoiceTemplate_Id)
                .Index(t => t.InvoiceTemplate_Id);
            
            CreateTable(
                "dbo.InvoiceTemplates",
                c => new
                    {
                        InvoiceTemplateId = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        InvoiceTemplateName = c.String(nullable: false, maxLength: 255),
                        InvoiceTemplateFile = c.Binary(),
                        PageWidth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PageHeigth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_InvoiceTemplate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_InvoiceTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.InvoiceTemplateId);
            
            CreateTable(
                "dbo.InvoiceTemplateFields",
                c => new
                    {
                        InvoiceTemplateFieldId = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        InvoiceTemplateFieldName = c.String(maxLength: 255),
                        InvoiceTemplateFieldDisplayName = c.String(maxLength: 2048),
                        InvoiceTemplateFieldType = c.String(maxLength: 1024),
                        InvoiceTemplateId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_InvoiceTemplateField_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.InvoiceTemplateFieldId)
                .ForeignKey("dbo.InvoiceTemplates", t => t.InvoiceTemplateId, cascadeDelete: true)
                .Index(t => t.InvoiceTemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceFields", "InvoiceTemplateFieldId", "dbo.InvoiceTemplateFields");
            DropForeignKey("dbo.Invoices", "InvoiceTemplate_Id", "dbo.InvoiceTemplates");
            DropForeignKey("dbo.InvoiceTemplateFields", "InvoiceTemplateId", "dbo.InvoiceTemplates");
            DropForeignKey("dbo.InvoiceFields", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceTemplateFields", new[] { "InvoiceTemplateId" });
            DropIndex("dbo.Invoices", new[] { "InvoiceTemplate_Id" });
            DropIndex("dbo.InvoiceFields", new[] { "InvoiceTemplateFieldId" });
            DropIndex("dbo.InvoiceFields", new[] { "InvoiceId" });
            DropTable("dbo.InvoiceTemplateFields",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_InvoiceTemplateField_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.InvoiceTemplates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_InvoiceTemplate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_InvoiceTemplate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceFields");
        }
    }
}
