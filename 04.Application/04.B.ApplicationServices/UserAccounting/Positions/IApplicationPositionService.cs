using ApplicationService.GenericApplicationServices;
using ApplicationService.UserAccounting.Dtos;
using PersistencePosition = Persistence.Models.Positions.Position;

namespace ApplicationService.UserAccounting.Positions
{
    public interface IApplicationPositionService:IApplicationService<ApplicationPositionDto, PersistencePosition, int>
    {
        public ApplicationRoleDto GetRole(int id);
    }
}
