using Persistence.Context;

namespace PersistenceTest.Positions
{
    public class BaseRepositoryTests
    {
        protected MelodiveMusicDbContext DbContext { get; set; }

        public BaseRepositoryTests(MelodiveMusicDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
