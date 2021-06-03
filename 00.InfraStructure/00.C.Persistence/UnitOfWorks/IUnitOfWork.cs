using System;
using Persistence.Context;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;

namespace Persistence.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public MelodiveMusicDbContext DbContext { get; }
        public IGenericRepository<Role, long> RoleRepository { get; }
        public IPositionRepository PositionRepository { get; }
        void Save();
    }
}
