using System;
using System.Collections.Generic;
using System.Text;
using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Roles;
using AutoMapper;
using DomainTest.UserAccounting.Roles;
using DomainTest.UserAccounting.Roles.Extensions;

namespace ApplicationTest.UserAccounting.Roles.Extensions
{
    public static class ApplicationRoleExtension
    {
        public static (ApplicationRoleDto,ApplicationRoleDto) AddSampleRoles(this RoleApplicationTests applicationTests,IMapper mapper,IApplicationRoleService sut)
        {
            var someDomainRole = new RoleTestBuilder().AddSomeRole();
            var anotherDomainRole = new RoleTestBuilder().AddAnotherRole();

            var someApplicationRole = mapper.Map<ApplicationRoleDto>(someDomainRole);
            var anotherApplicationRole = mapper.Map<ApplicationRoleDto>(anotherDomainRole);

            sut.Add(someApplicationRole, true);
            sut.Add(anotherApplicationRole, true);

            return (someApplicationRole,anotherApplicationRole);
        }
    }
}
