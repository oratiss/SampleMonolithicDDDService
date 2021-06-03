using ApplicationService.UserAccounting.Dtos;
using AutoMapper;
using WebApi.Dtos.UserAccounting;

namespace HSEWebApi.Profiles
{
    public class ApplicationDtoToApiDto:Profile
    {
        public ApplicationDtoToApiDto()
        {
            CreateMap<ApplicationRoleDto, ApiRoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SystemDescription, opt => opt.MapFrom(src => src.SystemDescription));

        }
    }
}
