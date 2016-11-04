using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FCD.MultiTenancy.Dto;

namespace FCD.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
