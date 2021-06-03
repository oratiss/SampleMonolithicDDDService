using ApplicationService.BaseApplicationServices;
using AutoMapper.QueryableExtensions;
using Domain.UserAccounting.Roles;
using Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.BasedSetMappers;
using ApplicationRoleDto = ApplicationService.UserAccounting.Dtos.ApplicationRoleDto;
using entityRole = Persistence.Models.Roles.Role;

namespace ApplicationService.UserAccounting.Roles
{
    public class ApplicationRoleService : BaseApplicationService, IApplicationRoleService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public ApplicationRoleService(IUnitOfWork unitOfWork, IAutoMapperConfiguration config) : base(config)
        {
            UnitOfWork = unitOfWork as UnitOfWork;
        }

        public ApplicationRoleDto Get(long id)
        {
            try
            {
                var role = UnitOfWork.RoleRepository.Get(id);
                return mapper.Map<ApplicationRoleDto>(role);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<ApplicationRoleDto> GetAll()
        {
            var repositoryPositions = UnitOfWork.RoleRepository.GetAll();
            var applicationRoleDtos = repositoryPositions.ProjectTo<ApplicationRoleDto>(mapper.ConfigurationProvider)
                   .AsEnumerable();
            return applicationRoleDtos;

        }
        public ApplicationRoleDto Add(ApplicationRoleDto applicationRoleDto, bool? doCommit = null)
        {
            var domainRole = new RoleBuilder()
                .With(r => r.Id, applicationRoleDto.Id)
                .With(r => r.Title, applicationRoleDto.Title)
                .With(r => r.Description, applicationRoleDto.Description)
                .With(r => r.SystemDescription, applicationRoleDto.SystemDescription)
                .Build();

            var roleEntity = mapper.Map<entityRole>(domainRole);
            var entity = UnitOfWork.RoleRepository.Add(roleEntity);
            if (doCommit == true) UnitOfWork.Save();
            return mapper.Map<ApplicationRoleDto>(entity);
        }

        public void Delete(long id, bool? doCommit = null)
        {
            UnitOfWork.RoleRepository.Delete(id);
            if (doCommit == true) UnitOfWork.Save();

        }

        public void Delete(ApplicationRoleDto applicationDto, bool? doCommit = null)
        {
            UnitOfWork.RoleRepository.Delete(applicationDto.Id);
            if (doCommit == true) UnitOfWork.Save();
        }

        public ApplicationRoleDto Update(ApplicationRoleDto applicationRoleDto, bool? doCommit = null)
        {
            var roleDomain = new RoleBuilder()
                .With(r => r.Id, applicationRoleDto.Id)
                .With(r => r.Title, applicationRoleDto.Title)
                .With(r => r.Description, applicationRoleDto.Description)
                .With(r => r.SystemDescription, applicationRoleDto.SystemDescription)
                .Build();
            var roleEntity = mapper.Map<entityRole>(roleDomain);
            roleEntity = UnitOfWork.RoleRepository.Update(roleEntity);
            if (doCommit == true) UnitOfWork.Save();
            return mapper.Map<ApplicationRoleDto>(roleEntity);
        }
    }
}
