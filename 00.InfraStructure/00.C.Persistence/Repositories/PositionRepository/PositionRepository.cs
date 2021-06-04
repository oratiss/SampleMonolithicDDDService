using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Positions;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using SharedValueObject.UserAccounting;

namespace Persistence.Repositories.PositionRepository
{
    public class PositionRepository : IPositionRepository
    {
        public IGenericRepository<Role, long> RoleRepository { get; }

        public MelodiveMusicDbContext DbContext { get; set; }
        private readonly DbSet<Position> _repository;

        public PositionRepository(MelodiveMusicDbContext dbContext, IGenericRepository<Role, long> roleRepository)
        {
            DbContext = dbContext;
            _repository = DbContext.Set<Position>();
            RoleRepository = roleRepository;
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

        public Position Add(Position position, bool? doCommit = null)
        {
            var existingPosition = _repository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition == null)
            {
                var existingRole = RoleRepository.Get(position.RoleId);
                if (existingRole != null)
                {
                    _repository.Add(position);
                    if (doCommit==true) Save();
                    return Get(position.Id);
                }
                throw new InvalidOperationException("There is no found role exists in role repository.");
            }
            throw new InvalidOperationException("There is already a similar existing position in repository.");
        }

        public void Delete(int id, bool? doCommit = null)
        {
            var existingPosition = Get(id);
            existingPosition.IsDeleted = true;
            if (doCommit == true) Save();
        }

        public void Delete(Position position, bool? doCommit = null)
        {
            Delete(position.Id, doCommit);
        }

        public Position Update(Position position, bool? doCommit = null)
        {
            var existingPosition = _repository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition != null)
            {
                var existingRole = RoleRepository.Get(position.RoleId);
                if (existingRole != null)
                {
                    DbContext.Set<PositionActivity>().Update(position.PositionActivity);
                    _repository.Update(position);

                    return Get(position.Id);
                }
                throw new InvalidOperationException("There is no such role existing in role repository to be updated.");
            }
            throw new InvalidOperationException("There is no such existing position in repository to be updated.");
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}