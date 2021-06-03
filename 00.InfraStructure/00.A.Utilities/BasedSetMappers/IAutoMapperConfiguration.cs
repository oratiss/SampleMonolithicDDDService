using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.BasedSetMappers
{
    public interface IAutoMapperConfiguration
    {
        public virtual void Configure(IServiceCollection services, params Assembly[] assemblies)
        {
        }
    }
}
