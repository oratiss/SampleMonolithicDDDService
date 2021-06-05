using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Context;

namespace PersistenceTest.Positions
{
    public class BaseRepositoryTests
    {
        protected MelodiveMusicDbContext DbContext;
        public BaseRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MelodiveMusicDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER2019; Database=MelodiveMusicDDD2021; User=sa; Password=112233445566;  MultipleActiveResultSets=true;");

            DbContext = new MelodiveMusicDbContext(optionsBuilder.Options);
        }
    }
}
