using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.BasedSetMappers
{
    public class BaseTestWithSetMapper
    {
        protected IServiceCollection services;
        protected IMapper mapper;
        protected IAutoMapperConfiguration config;

        public BaseTestWithSetMapper(IAutoMapperConfiguration config)
        {
            services = new ServiceCollection();
            this.config = config;
            this.config.Configure(services);

            var serviceProvider = services.BuildServiceProvider();
            mapper = serviceProvider.GetService<IMapper>();
        }

    }
}
