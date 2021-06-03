using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Positions;
using Persistence.Models.Roles;
using Persistence.Repositories.FakeGenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Persistence.Repositories.PositionRepository
{
    public class FakePositionRepository 
    {
        public GenericFakeRepository<Role, long> RoleRepository { get; set; }
        private readonly IList<Position> _positionRepository;

        public FakePositionRepository(GenericFakeRepository<Role, long> roleRepository)
        {
            _positionRepository = new List<Position>();
            this.RoleRepository = roleRepository;
        }


        public IQueryable<Position> GetItems(Expression<Func<Position, bool>> predicate, params string[] navigationProperties)
        {
            var query = _positionRepository.AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            return query.Where(predicate).AsQueryable();
        }


        public MelodiveMusicDbContext DbContext { get; set; }

        public IQueryable<Position> GetAll()
        {
            return _positionRepository.AsQueryable();
        }

        public Position Get(int id)
        {
            return _positionRepository.SingleOrDefault(p => p.Id == id);
        }

        public Position Add(Position position, bool? doCommit=null)
        {
           var existingPosition = _positionRepository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition == null)
            {
                var existingRole = RoleRepository.Get(position.RoleId);
                if (existingRole != null)
                {
                    _positionRepository.Add(position);
                    return position;
                }
                throw new InvalidOperationException("There is no found role exists in role repository.");
            }
            throw new InvalidOperationException("There is already a similar existing position in repository.");
        }

        public void Delete(int id, bool? doCommit = null)
        {
           var existingPosition = _positionRepository.SingleOrDefault(e => e.Id.Equals(id));
            if (existingPosition == null)
                throw new InvalidOperationException("There is no position in repository with given id to be deleted.");
            Delete(existingPosition);
        }

        public void Delete(Position position, bool? doCommit = null)
        {
            var existingPosition = _positionRepository.SingleOrDefault(e => e.Equals(position));
            if (existingPosition == null)
                throw new InvalidOperationException("There is no similar position in repository to be deleted.");
            _positionRepository.Remove(existingPosition);
        }

        public Position Update(Position position, bool? doCommit)
        {
            var existingPosition = _positionRepository.SingleOrDefault(e => e.Id.Equals(position.Id));
            if (existingPosition == null)
                throw new InvalidOperationException("There is no similar position in repository to be updated.");
            var existingRole = RoleRepository.Get(position.RoleId);
            if (existingRole != null)
            {
                _positionRepository.Remove(existingPosition);
                _positionRepository.Add(position);
                return position;
            }
            throw new InvalidOperationException("There is no similar role in role repository.");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}