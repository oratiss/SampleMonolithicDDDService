using Persistence.Context;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public MelodiveMusicDbContext dbContext;
        public GenericRepository<Role, long> RoleRepository;
        public PositionRepository PositionRepository;


        public UnitOfWork(MelodiveMusicDbContext dbContext,
            IPositionRepository positionRepository,
            IGenericRepository<Role, long> roleRepository)
        {
            this.dbContext = dbContext;
            PositionRepository = positionRepository as PositionRepository;
            RoleRepository = roleRepository as GenericRepository<Role, long>;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }


    }
}
