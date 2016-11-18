using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FCD.Invoices
{
    //[AbpAuthorize(PermissionNames.Pages_Resources_Certificates)]
    public class InvoiceTemplateAppService : CrudAppService<InvoiceTemplate, InvoiceTemplateDto, Guid,
       GetAllInvoiceTemplatesDto,
       CreateInvoiceTemplateDto,
       UpdateInvoiceTemplateDto>, IInvoiceTemplateAppService
    {

        public InvoiceTemplateAppService(IRepository<InvoiceTemplate, Guid> repository)
            : base(repository)
        {
        }

        [HttpGet, HttpPost]
        public override PagedResultDto<InvoiceTemplateDto> GetAll(GetAllInvoiceTemplatesDto input)
        {
            return base.GetAll(input);
        }

        protected override IQueryable<InvoiceTemplate> CreateFilteredQuery(GetAllInvoiceTemplatesDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(AbpSession.TenantId.HasValue, x => x.TenantId == AbpSession.TenantId)
                .WhereIf(!string.IsNullOrEmpty(input.SearchText), x =>
                    x.InvoiceTemplateName.Contains(input.SearchText));
        }

        //[AbpAuthorize(PermissionNames.Pages_Resources_Certificates_Create)]
        public override InvoiceTemplateDto Create(CreateInvoiceTemplateDto input)
        {
            input.TenantId = AbpSession.TenantId;
            return base.Create(input);
        }

        //[AbpAuthorize(PermissionNames.Pages_Resources_Certificates_Create)]
        public override InvoiceTemplateDto Update(UpdateInvoiceTemplateDto input)
        {
            input.TenantId = AbpSession.TenantId;
            return base.Update(input);
        }

        //[AbpAuthorize(PermissionNames.Pages_Resources_Certificates_Delete)]
        public override void Delete(EntityDto<Guid> input)
        {
            base.Delete(input);
        }
    }
}
