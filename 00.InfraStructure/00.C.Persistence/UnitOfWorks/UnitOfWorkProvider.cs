using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;

namespace Persistence.UnitOfWorks
{
    public static class UnitOfWorkProvider
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericSearchableRepository<,>), typeof(GenericSearchableRepository<,>));
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IPositionRepository, PositionRepository>();

            return services;
        }
    }
}

