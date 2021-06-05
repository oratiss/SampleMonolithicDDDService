using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Utilities.BasedSetMappers;
using WebApi.Profiles;

namespace WebApi.AutoMapper
{
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        public void Configure(IServiceCollection services, params Assembly[] assemblies)
        {
            List<Profile> profileList = new List<Profile>()
            {
                new DomainToPersistenceEntity()
                ,new DomainToApplicationDto()
                ,new PersistenceEntityToApplicationDto()
                ,new ApplicationDtoToApiDto()
                ,new ApiDtoToApplicationDto()
            };

            services.AddAutoMapper(config =>
            {
                config.AddProfiles(profileList);
            }, assemblies);
        }
    }
}
