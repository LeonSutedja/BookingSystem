using System.Threading.Tasks;
using Abp.Application.Services;
using BookingSystem.Roles.Dto;

namespace BookingSystem.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
