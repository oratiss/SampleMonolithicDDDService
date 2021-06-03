using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.BasedSetMappers
{
    public class BaseTestWithSetMapper
    {
        protected IServiceCollection _services;
        protected IMapper mapper;
        protected IAutoMapperConfiguration _config;

        public BaseTestWithSetMapper(IAutoMapperConfiguration config)
        {
            _services = new ServiceCollection();
            _config = config;
            _config.Configure(_services);

            var serviceProvider = _services.BuildServiceProvider();
            mapper = serviceProvider.GetService<IMapper>();
        }

    }
}
