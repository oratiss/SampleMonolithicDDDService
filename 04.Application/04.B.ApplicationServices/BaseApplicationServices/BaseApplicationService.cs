using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Utilities.BasedSetMappers;

namespace ApplicationService.BaseApplicationServices
{
    public class BaseApplicationService
    {
        protected IServiceCollection services;
        protected IMapper mapper;
        protected IAutoMapperConfiguration config;

        public BaseApplicationService( IAutoMapperConfiguration config)
        {
            services = new ServiceCollection();
            this.config = config;
            this.config.Configure(services);

            var serviceProvider = services.BuildServiceProvider();
            mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
