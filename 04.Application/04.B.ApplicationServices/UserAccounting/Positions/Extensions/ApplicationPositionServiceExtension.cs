using ApplicationService.UserAccounting.Dtos;
using AutoMapper;
using Domain.UserAccounting.Positions;
using PersistencePosition = Persistence.Models.Positions.Position;


namespace ApplicationService.UserAccounting.Positions.Extensions
{
    public static class ApplicationPositionServiceExtension
    {
        public static PersistencePosition CheckDomainPositionServiceRulesAndMapToPersistence(
            this PositionApplicationService positionApplicationService, IMapper mapper, ApplicationPositionDto applicationPositionDto)
        {
            var domainPosition = new PositionBuilder()
                .With(p => p.Id, applicationPositionDto.Id)
                .With(p => p.Title, applicationPositionDto.Title)
                .With(p => p.Code, applicationPositionDto.Code)
                .With(p => p.DamageType, applicationPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, applicationPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, applicationPositionDto.CustomesCode)
                .With(p => p.Description, applicationPositionDto.Description)
                .With(p => p.IsActive, applicationPositionDto.IsActive)
                .With(p => p.RoleId, applicationPositionDto.RoleId)
                .With(p=>p.PositionActivity,applicationPositionDto.PositionActivity)
                .Build();

            return mapper.Map<PersistencePosition>(domainPosition);
        }
    }
}
