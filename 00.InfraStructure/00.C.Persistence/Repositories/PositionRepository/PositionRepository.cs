using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Positions;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories.PositionRepository
{
    public class PositionRepository : IPositionRepository
    {
        public IGenericRepository<Role, long> RoleRepository { get; set; }
        private readonly MelodiveMusicDbContext _dbContext;
        private readonly DbSet<Position> _repository;

        public PositionRepository(IMelodiveMusicDbContext dbContext)
        {
            _dbContext = dbContext as MelodiveMusicDbContext;
            _repository = _dbContext.Set<Position>();
        }

        //todo:
        public IQueryable<Position> GetItems(Expression<Func<Position, bool>> predicate, params string[] navigationProperties)
        {

            var query = _repository.AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            return query.Where(predicate).AsQueryable();
        }

        public IQueryable<Position> GetAll()
        {
            return _repository.Include(p => p.Role).AsQueryable();
        }

        public Position Get(int id)
        {
            return _repository.Include(p => p.Role).SingleOrDefault(t => t.Id.Equals(id));
        }

        public Position Add(Position position)
        {
            var existingPosition = _repository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition == null)
            {
                var existingRole = RoleRepository.Get(position.RoleId);
                if (existingRole != null)
                {
                    _repository.Add(position);
                    return Get(position.Id);
                }
                throw new InvalidOperationException("There is no found role exists in role repository.");
            }
            throw new InvalidOperationException("There is already a similar existing position in repository.");
        }

        public void Delete(int id)
        {
            var existingPosition = Get(id);
            Delete(existingPosition);
        }

        public void Delete(Position position)
        {
            position.IsDeleted = true;
            Update(position);
        }

        public Position Update(Position position)
        {
            var existingPosition = _repository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition != null)
            {
                var existingRole = RoleRepository.Get(position.RoleId);
                if (existingRole != null)
                {
                    _repository.Update(position);
                    _dbContext.Entry(existingPosition.PositionActivity).State = EntityState.Detached;
                    existingPosition.PositionActivity.PositionId = position.Id;

                    return Get(position.Id);
                }
                throw new InvalidOperationException("There is no such role existing in role repository to be updated.");
            }
            throw new InvalidOperationException("There is no such existing position in repository to be updated.");
        }
    }
}