using System.Threading.Tasks;
using Abp.Application.Services;
using FCD.Roles.Dto;

namespace FCD.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
