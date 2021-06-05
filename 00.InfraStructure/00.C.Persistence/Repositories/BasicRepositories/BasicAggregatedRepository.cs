using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Context;

namespace Persistence.Repositories.BasicRepositories
{
    public class BasicAggregatedRepository
    {
        protected readonly MelodiveMusicDbContext dbContext;
        public BasicAggregatedRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MelodiveMusicDbContext>();
            optionsBuilder.UseSqlServer("Server = localhost\\MSSQLSERVER2019; Database = MelodiveMusicDDD2021; User = sa; Password = 112233445566; MultipleActiveResultSets = true; ");
            dbContext = new MelodiveMusicDbContext(optionsBuilder.Options);
        }
    }
}
