using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq;
using Persistence.UnitOfWorks;
using Utilities.BaseEntities;


namespace Persistence.Repositories.GenericRepositories
{
    public class GenericRepository<TDbEntity, TKey> : IGenericRepository<TDbEntity, TKey>
        where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        public UnitOfWork UnitOfWork { get; set; }
        private readonly DbSet<TDbEntity> _repository;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork as UnitOfWork;
            _repository = UnitOfWork.dbContext.Set<TDbEntity>();
        }

        public TDbEntity Get(TKey id)
        {
            return _repository.SingleOrDefault(t => t.Id.Equals(id));
        }

        public IQueryable<TDbEntity> GetAll()
        {
            return _repository.AsQueryable();
        }
        public TDbEntity Add(TDbEntity entity)
        {
            _repository.Add(entity);
            return entity;
        }

        public void Delete(TKey id)
        {
            TDbEntity entity = Get(id);
            Delete(entity);
        }

        public void Delete(TDbEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public TDbEntity Update(TDbEntity entity)
        {
            _repository.Update(entity);
            return entity;
        }

    }
}
