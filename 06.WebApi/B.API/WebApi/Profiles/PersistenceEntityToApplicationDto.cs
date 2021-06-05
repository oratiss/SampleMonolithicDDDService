using ApplicationService.UserAccounting.Dtos;
using AutoMapper;
using PersistencePosiotion=Persistence.Models.Positions.Position;
using PersistenceRole=Persistence.Models.Roles.Role;

namespace WebApi.Profiles
{
    public class PersistenceEntityToApplicationDto : Profile
    {
        public PersistenceEntityToApplicationDto()
        {
            CreateMap<PersistenceRole, ApplicationRoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SystemDescription, opt => opt.MapFrom(src => src.SystemDescription));



            CreateMap<PersistencePosiotion, ApplicationPositionDto>()
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
