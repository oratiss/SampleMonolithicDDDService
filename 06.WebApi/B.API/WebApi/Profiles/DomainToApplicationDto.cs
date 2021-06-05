using ApplicationService.UserAccounting.Dtos;
using AutoMapper;
using DomainPosition = Domain.UserAccounting.Positions.Position;
using DomainRole = Domain.UserAccounting.Roles.Role;


namespace WebApi.Profiles
{
    public class DomainToApplicationDto : Profile
    {
        public DomainToApplicationDto()
        {
            CreateMap<DomainRole,ApplicationRoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SystemDescription, opt => opt.MapFrom(src => src.SystemDescription));

            CreateMap<DomainPosition, ApplicationPositionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.DamageType, opt => opt.MapFrom(src => src.DamageType))
                .ForMember(dest => dest.ErgonomicStatus, opt => opt.MapFrom(src => src.ErgonomicStatus))
                .ForMember(dest => dest.CustomesCode, opt => opt.MapFrom(src => src.CustomesCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.PositionActivity, opt => opt.MapFrom(src => src.PositionActivity));




        }
    }
}
