using System;
using System.Linq;
using Utilities.BaseEntities;

namespace Persistence.Repositories.GenericRepositories
{
    public interface IGenericRepository<TDbEntity, TKey> where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        public IQueryable<TDbEntity> GetAll();
        public TDbEntity Get(TKey id);
        public TDbEntity Add(TDbEntity entity);
        public void Delete(TKey id);
        public void Delete(TDbEntity entity);
        public TDbEntity Update(TDbEntity entity);

    }
}
