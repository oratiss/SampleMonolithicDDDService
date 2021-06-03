using ApplicationService.GenericApplicationServices;
using ApplicationService.UserAccounting.Dtos;
using Persistence.Models.Roles;

namespace ApplicationService.UserAccounting.Roles
{
    public interface IApplicationRoleService: IApplicationService<ApplicationRoleDto,Role, long> 
    {
    }
}
