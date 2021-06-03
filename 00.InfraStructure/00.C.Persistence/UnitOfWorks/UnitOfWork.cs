using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public MelodiveMusicDbContext DbContext { get; }
        public IGenericRepository<Role, long> RoleRepository { get; } 
        public IPositionRepository PositionRepository { get; }

        public UnitOfWork(MelodiveMusicDbContext dbContext, IGenericRepository<Role, long> roleRepository, IPositionRepository positionRepository)
        {
            DbContext = dbContext;
            RoleRepository = roleRepository;
            PositionRepository = positionRepository;
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
        public void Save()
        {
            DbContext.SaveChanges();
        }


    }
}
