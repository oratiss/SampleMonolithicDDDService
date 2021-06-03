using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using Utilities.BaseEntities;

namespace Persistence.Repositories.GenericRepositories
{
    public class GenericSearchableRepository<TDbEntity, TKey> : GenericRepository<TDbEntity, TKey>, IGenericSearchableRepository<TDbEntity, TKey>
        where TDbEntity : BaseEntity<TKey> where TKey : struct 
    {

        public GenericSearchableRepository(MelodiveMusicDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<TDbEntity> GetItems(Expression<Func<TDbEntity, bool>> predicate, params string[] navigationProperties)
        {

            var query = Repository.AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            return query.Where(predicate).AsQueryable();

        }

    }
}
