using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.BasicRepositories;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;

namespace Persistence.UnitOfWorks
{
    public static class UnitOfWorkProvider
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<BasicAggregatedRepository>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IGenericSearchableRepository<,>), typeof(GenericSearchableRepository<,>));
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

