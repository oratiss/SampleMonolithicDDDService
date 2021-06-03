using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.UnitOfWorks;
using System;
using System.Linq;
using System.Linq.Expressions;
using Utilities.BaseEntities;

namespace Persistence.Repositories.GenericRepositories
{
    public class GenericSearchableRepository<TDbEntity, TKey> : GenericRepository<TDbEntity, TKey>, IGenericSearchableRepository<TDbEntity, TKey>
        where TDbEntity : BaseEntity<TKey> where TKey : struct 
    {
        public GenericSearchableRepository(IUnitOfWork unitOfWork, IServiceCollection services) : base(unitOfWork)
        {
        }

        public IQueryable<TDbEntity> GetItems(Expression<Func<TDbEntity, bool>> predicate, params string[] navigationProperties)
        {

            var query = UnitOfWork.dbContext.Set<TDbEntity>().AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            return query.Where(predicate).AsQueryable();

        }

    }
}
