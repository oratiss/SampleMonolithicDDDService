﻿using ApplicationService.UserAccounting.Dtos;
using AutoMapper;
using WebApi.Dtos.UserAccounting;

namespace WebApi.Profiles
{
    public class ApiDtoToApplicationDto:Profile
    {
        public ApiDtoToApplicationDto()
        {
            CreateMap<ApiRoleDto, ApplicationRoleDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.SystemDescription, opt => opt.MapFrom(src => src.SystemDescription));
        }
    }
}
