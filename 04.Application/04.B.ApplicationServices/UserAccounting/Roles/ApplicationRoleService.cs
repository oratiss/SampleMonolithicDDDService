using ApplicationService.BaseApplicationServices;
using AutoMapper.QueryableExtensions;
using Domain.UserAccounting.Roles;
using Persistence.Repositories.GenericRepositories;
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
        private readonly IGenericRepository<entityRole, long> _roleRepository;
        public ApplicationRoleService(IGenericRepository<entityRole, long> roleRepository, IAutoMapperConfiguration config) : base(config)
        {
            _roleRepository = roleRepository;
        }

        public ApplicationRoleDto Get(long id)
        {
            try
            {
                var role = _roleRepository.Get(id);
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
            var repositoryPositions = _roleRepository.GetAll();
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
            if (domainRole.Id != 0)
            {
                var existingRole = _roleRepository.Get(domainRole.Id);
                if (existingRole != null)
                    throw new InvalidOperationException("there is already a similar existing item in repository."); 
            }
            var entity = _roleRepository.Add(roleEntity, true);
            if (doCommit == true) _roleRepository.Save();
            return mapper.Map<ApplicationRoleDto>(entity);
        }

        public void Delete(long id, bool? doCommit = null)
        {
            _roleRepository.Delete(id, true);
            if (doCommit == true) _roleRepository.Save();
        }


        public void Delete(ApplicationRoleDto applicationDto, bool? doCommit = null)
        {
            _roleRepository.Delete(applicationDto.Id, true);
            if (doCommit == true) _roleRepository.Save();
        }


        public ApplicationRoleDto Update(ApplicationRoleDto applicationRoleDto, bool? doCommit = null)
        {
            var domainRole = new RoleBuilder()
                .With(r => r.Id, applicationRoleDto.Id)
                .With(r => r.Title, applicationRoleDto.Title)
                .With(r => r.Description, applicationRoleDto.Description)
                .With(r => r.SystemDescription, applicationRoleDto.SystemDescription)
                .Build();
            var roleEntity = mapper.Map<entityRole>(domainRole);
            if (domainRole.Id != 0)
            {
                var existingRole = _roleRepository.Get(domainRole.Id);
                if (existingRole == null)
                    throw new InvalidOperationException("there is no wanted entity to be updated.");
            }
            roleEntity = _roleRepository.Update(roleEntity, true);
            if (doCommit == true) _roleRepository.Save();
            return mapper.Map<ApplicationRoleDto>(roleEntity);
        }
    }
}
