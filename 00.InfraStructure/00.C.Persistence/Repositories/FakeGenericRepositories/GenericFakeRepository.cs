using System.Collections.Generic;
using System.Linq;
using Persistence.Context;
using Persistence.Repositories.GenericRepositories;
using Utilities.BaseEntities;

namespace Persistence.Repositories.FakeGenericRepositories
{
    public class GenericFakeRepository<TDbEntity, TKey> : IGenericRepository<TDbEntity, TKey> where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        public List<TDbEntity> Repository { get; set; }
        
        public GenericFakeRepository()
        {
            Repository = new List<TDbEntity>();
        }

        public GenericFakeRepository(TDbEntity entity)
        {
            Repository = new List<TDbEntity>();
            Repository.Add(entity);
        }

        public TDbEntity Get(TKey id)
        {
            return Repository.SingleOrDefault(t => t.Id.Equals(id));
        }

        public MelodiveMusicDbContext DbContext { get; set; }

        public IQueryable<TDbEntity> GetAll()
        {
            return Repository.AsQueryable();
        }
        public TDbEntity Add(TDbEntity entity, bool? doCommit = null)
        {
            Repository.Add(entity);
            return entity;
        }

        public void Delete(TKey id, bool? doCommit = null)
        {
            TDbEntity entity = Get(id);
            Repository.Remove(entity);
        }

        public void Delete(TDbEntity entity, bool? doCommit = null)
        {
            Delete(entity.Id, doCommit);
        }

        public TDbEntity Update(TDbEntity entity, bool? doCommit = null)
        {
            var removingEntity = Get(entity.Id);
            Repository.Remove(removingEntity);
            Repository.Add(entity);
            return entity;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
