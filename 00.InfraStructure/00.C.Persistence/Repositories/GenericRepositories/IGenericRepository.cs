using System;
using System.Linq;
using Persistence.Context;
using Utilities.BaseEntities;

namespace Persistence.Repositories.GenericRepositories
{
    public interface IGenericRepository<TDbEntity, TKey> where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        public MelodiveMusicDbContext DbContext { get; set; }
        public IQueryable<TDbEntity> GetAll();
        public TDbEntity Get(TKey id);
        public TDbEntity Add(TDbEntity entity, bool? doCommit);
        public void Delete(TKey id, bool? doCommit);
        public void Delete(TDbEntity entity, bool? doCommit);
        public TDbEntity Update(TDbEntity entity, bool? doCommit);
        public void Save();
    }
}
