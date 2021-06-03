using ApplicationService.BaseApplicationServices;
using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Positions.Extensions;
using Persistence.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;
using Utilities.BasedSetMappers;

namespace ApplicationService.UserAccounting.Positions
{
    public class PositionApplicationService : BaseApplicationService, IApplicationPositionService
    {
        public UnitOfWork UnitOfWork { get; set; }
        public PositionApplicationService(IUnitOfWork unitOfWork, IAutoMapperConfiguration config) : base(config)
        {
            UnitOfWork = unitOfWork as UnitOfWork;
        }


        public IEnumerable<ApplicationPositionDto> GetAll()
        {
            var persistencePositions = UnitOfWork.PositionRepository.GetAll();
            return persistencePositions.AsEnumerable().Select(mapper.Map<ApplicationPositionDto>);
        }

        public ApplicationPositionDto Get(int id)
        {
            var position = UnitOfWork.PositionRepository.Get(id);
            return mapper.Map<ApplicationPositionDto>(position);
        }

        public ApplicationPositionDto Add(ApplicationPositionDto applicationPositionDto, bool? doCommit=null)
        {
            var persistencePosition = this.CheckDomainPositionServiceRulesAndMapToPersistence(mapper, applicationPositionDto);
            persistencePosition = UnitOfWork.PositionRepository.Add(persistencePosition);
            if (doCommit==true) UnitOfWork.Save();
            return mapper.Map<ApplicationPositionDto>(persistencePosition);
        }

        public void Delete(int id, bool? doCommit=null)
        {
            UnitOfWork.PositionRepository.Delete(id);
            if (doCommit==true) UnitOfWork.Save();
        }

        public void Delete(ApplicationPositionDto applicationDto, bool? doCommit=null)
        {
            Delete(applicationDto.Id, doCommit);
        }

        public ApplicationPositionDto Update(ApplicationPositionDto applicationPositionDto, bool? doCommit=null)
        {
            var persistencePosition = this.CheckDomainPositionServiceRulesAndMapToPersistence(mapper, applicationPositionDto);
            persistencePosition = UnitOfWork.PositionRepository.Update(persistencePosition);
            if (doCommit == true) UnitOfWork.Save();
            return mapper.Map<ApplicationPositionDto>(persistencePosition);
        }

        public ApplicationRoleDto GetRole(int id)
        {
            return mapper.Map<ApplicationRoleDto>(UnitOfWork.RoleRepository.Get(id));
        }


    }
}
