using Persistence.Models.Positions;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;

namespace Persistence.Repositories.PositionRepository
{
    public interface IPositionRepository:IGenericSearchableRepository<Position,int>
    {
        public IGenericRepository<Role, long> RoleRepository { get; }
    }
}
