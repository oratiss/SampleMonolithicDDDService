using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Repositories.GenericRepositories;
using Utilities.BaseEntities;

namespace Persistence.Repositories.FakeGenericRepositories
{
    public class GenericFakeRepository<TDbEntity, TKey> : IGenericRepository<TDbEntity, TKey>
        where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly IList<TDbEntity> _entities;

        public GenericFakeRepository()
        {
            _entities = new List<TDbEntity>();
        }

        public GenericFakeRepository(TDbEntity entity)
        {
            _entities = new List<TDbEntity>();
            _entities.Add(entity);
        }

        public TDbEntity Get(TKey id)
        {
            return _entities.SingleOrDefault(t => t.Id.Equals(id));
        }

        public IQueryable<TDbEntity> GetAll()
        {
            return _entities.AsQueryable();
        }
        public TDbEntity Add(TDbEntity entity)
        {
            var existingEntity = _entities.SingleOrDefault(e => e.Id.Equals(entity.Id));
            if (existingEntity==null)
            {
                 _entities.Add(entity);
                 return Get(entity.Id);
            }

            throw new InvalidOperationException("there is already a similar existing item in repository.");
        }

        public void Delete(TKey id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public void Delete(TDbEntity entity)
        {
            _entities.Remove(entity);
        }


        public TDbEntity Update(TDbEntity entity)
        {
            var existingEntity = _entities.AsQueryable().SingleOrDefault(e => e.Id.Equals(entity.Id));
            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                _entities.Add(entity);
                return Get(entity.Id);
            }

            throw new InvalidOperationException("there is no wanted entity to be updated.");
        }

     }
}
