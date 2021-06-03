using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Utilities.BasedSetMappers;

namespace ApplicationService.BaseApplicationServices
{
    public class BaseApplicationService
    {
        protected IServiceCollection _services;
        protected IMapper mapper;
        protected IAutoMapperConfiguration _config;

        public BaseApplicationService( IAutoMapperConfiguration config)
        {
            _services = new ServiceCollection();
            _config = config;
            _config.Configure(_services);

            var serviceProvider = _services.BuildServiceProvider();
            mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
