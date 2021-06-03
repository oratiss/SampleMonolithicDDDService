using System;
using System.Linq;
using System.Linq.Expressions;
using Utilities.BaseEntities;

namespace Persistence.Repositories.GenericRepositories
{
    public interface IGenericSearchableRepository<TDbEntity, TKey> : IGenericRepository<TDbEntity, TKey>
        where TDbEntity : BaseEntity<TKey> where TKey : struct 
    {
        IQueryable<TDbEntity> GetItems(Expression<Func<TDbEntity, bool>> predicate, params string[] navigationProperties);
    }
}
