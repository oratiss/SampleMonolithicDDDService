using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq;
using Utilities.BaseEntities;


namespace Persistence.Repositories.GenericRepositories
{
    public class GenericRepository<TDbEntity, TKey> : IGenericRepository<TDbEntity, TKey> where TDbEntity : BaseEntity<TKey> where TKey : struct
    {
        public MelodiveMusicDbContext DbContext { get; set; }
        protected DbSet<TDbEntity> Repository;

        public GenericRepository(MelodiveMusicDbContext dbContext)
        {
            if (dbContext != null) Repository = dbContext.Set<TDbEntity>();
        }

        public TDbEntity Get(TKey id)
        {
            return Repository.SingleOrDefault(t => t.Id.Equals(id));
        }


        public IQueryable<TDbEntity> GetAll()
        {
            return Repository.AsQueryable();
        }
        public TDbEntity Add(TDbEntity entity, bool? doCommit=null)
        {
            Repository.Add(entity);
            if (doCommit==true) Save();
            return entity;
        }

        public void Delete(TKey id, bool? doCommit=null)
        {
            TDbEntity entity = Get(id);
            Delete(entity, doCommit);
        }

        public void Delete(TDbEntity entity, bool? doCommit=null)
        {
            entity.IsDeleted = true;
            if (doCommit == true) Save();
            Update(entity);
        }

        public TDbEntity Update(TDbEntity entity, bool? doCommit=null)
        {
            Repository.Update(entity);
            if (doCommit == true) Save();
            return entity;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

    }
}
