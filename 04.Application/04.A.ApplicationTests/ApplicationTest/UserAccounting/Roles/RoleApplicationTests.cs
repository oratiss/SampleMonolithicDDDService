using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Roles;
using ApplicationTest.UserAccounting.Roles.Extensions;
using DomainTest.UserAccounting.Roles;
using DomainTest.UserAccounting.Roles.Extensions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.GenericRepositories;
using System;
using HSEWebApi.AutoMapper;
using Persistence.Repositories.FakeGenericRepositories;
using Utilities.BasedSetMappers;
using Utilities.SharedTools.Assertions;
using Xunit;
using entityRole = Persistence.Models.Roles.Role;


namespace ApplicationTest.UserAccounting.Roles
{
    public class RoleApplicationTests : BaseTestWithSetMapper
    {
        private IApplicationRoleService sut;

        public RoleApplicationTests() : base(new AutoMapperConfiguration())
        {
            _services.AddSingleton<IApplicationRoleService, ApplicationRoleService>();
            _services.AddScoped<IGenericRepository<entityRole, long>, GenericFakeRepository<entityRole, long>>();

            var serviceProvider = _services.BuildServiceProvider();
            var repository = serviceProvider.GetService<IGenericRepository<entityRole, long>>();

            sut = new ApplicationRoleService(repository, new AutoMapperConfiguration());
        }

        [Fact]
        public void Add_Method_Of_ApplicationService_Should_Add_Role()
        {
            //arrange 
            var (someDomainRole, _) = this.AddSampleRoles(mapper, sut);

            //Act
            var result = sut.GetAll();

            //Assert
            var expectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, someDomainRole.Id)
                .With(r => r.Title, someDomainRole.Title)
                .With(r => r.Description, someDomainRole.Description)
                .With(r => r.SystemDescription, someDomainRole.SystemDescription)
                .Build();

            var expected = mapper.Map<ApplicationRoleDto>(expectedDomainRole);

            result.IsContaining(expected).Should().BeTrue();
        }


        [Fact]
        public void Update_Method_Of_ApplicationService_Should_Update_Role()
        {
            //arrange
            var (someDomainRole, _) = this.AddSampleRoles(mapper, sut);

            var updatingDomainRole = new RoleTestBuilder()
                .With(r => r.Title, "updatingRoleTitle")
                .Build();

            var updatingApplicationRole = mapper.Map<ApplicationRoleDto>(updatingDomainRole);

            //Act
            sut.Update(updatingApplicationRole, true);

            //Assert
            var expectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, someDomainRole.Id)
                .With(r => r.Title, updatingApplicationRole.Title)
                .With(r => r.Description, someDomainRole.Description)
                .With(r => r.SystemDescription, someDomainRole.SystemDescription)
                .Build();

            var expected = mapper.Map<ApplicationRoleDto>(expectedDomainRole);

            var result = sut.GetAll();

            result.IsContaining(expected).Should().BeTrue();
        }


        [Fact]
        public void Delete_By_Entity_Method_Of_ApplicationService_Should_Delete_Role()
        {
            //arrange
            var (_, anotherApplicationRole) = this.AddSampleRoles(mapper, sut);

            //Act
            sut.Delete(anotherApplicationRole, true);

            //Assert
            var expectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, anotherApplicationRole.Id)
                .With(r => r.Title, anotherApplicationRole.Title)
                .With(r => r.Description, anotherApplicationRole.Description)
                .With(r => r.SystemDescription, anotherApplicationRole.SystemDescription)
                .Build();

            var expected = mapper.Map<ApplicationRoleDto>(expectedDomainRole);

            var result = sut.GetAll();

            result.IsContaining(expected).Should().BeFalse(); 
        }

        [Fact]
        public void Delete_By_Id_Method_Of_ApplicationService_Should_Delete_Role()
        {
            //arrange
            var (_, anotherApplicationRole) = this.AddSampleRoles(mapper, sut);

            //Act
            sut.Delete(anotherApplicationRole.Id, true);

            //Assert
            var expectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, anotherApplicationRole.Id)
                .With(r => r.Title, anotherApplicationRole.Title)
                .With(r => r.Description, anotherApplicationRole.Description)
                .With(r => r.SystemDescription, anotherApplicationRole.SystemDescription)
                .Build();

            var expected = mapper.Map<ApplicationRoleDto>(expectedDomainRole);

            var result = sut.GetAll();

            result.IsContaining(expected).Should().BeFalse();
        }

        [Fact]
        public void Get_Method_Of_ApplicationService_Should_Get_Role()
        {
            //arrange
            var (_, anotherApplicationRole) = this.AddSampleRoles(mapper, sut);

            //Act
            var result = sut.Get(anotherApplicationRole.Id);

            //Assert
            var expectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, anotherApplicationRole.Id)
                .With(r => r.Title, anotherApplicationRole.Title)
                .With(r => r.Description, anotherApplicationRole.Description)
                .With(r => r.SystemDescription, anotherApplicationRole.SystemDescription)
                .Build();

            var expected = mapper.Map<ApplicationRoleDto>(expectedDomainRole);

            result.Compare(expected).Should().BeTrue();
        }

        [Fact]
        public void GetAll_Method_Of_ApplicationService_Should_GetAll_Roles()
        {
            //arrange
            var (someApplicationRole, anotherApplicationRole) = this.AddSampleRoles(mapper, sut);

            //Act
            var result = sut.GetAll();

            //Assert
            var firstExpectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, someApplicationRole.Id)
                .With(r => r.Title, someApplicationRole.Title)
                .With(r => r.Description, someApplicationRole.Description)
                .With(r => r.SystemDescription, someApplicationRole.SystemDescription)
                .Build();

            var expectedSome = mapper.Map<ApplicationRoleDto>(firstExpectedDomainRole);


            var secondExpectedDomainRole = new RoleTestBuilder()
                .With(r => r.Id, anotherApplicationRole.Id)
                .With(r => r.Title, anotherApplicationRole.Title)
                .With(r => r.Description, anotherApplicationRole.Description)
                .With(r => r.SystemDescription, anotherApplicationRole.SystemDescription)
                .Build();

            var expectedAnother = mapper.Map<ApplicationRoleDto>(secondExpectedDomainRole);

            var compareResult = result.IsContaining(expectedSome) && result.IsContaining(expectedAnother);
            compareResult.Should().BeTrue();
        }

        [Fact]
        public void Add_Method_Of_ApplicationService_Should_Throw_Exeception_On_Adding_Duplicate_Roles()
        {
            //arrange
            var someRole = new RoleTestBuilder().AddSomeRole();
            var someApplicationRole = mapper.Map<ApplicationRoleDto>(someRole);
            sut.Add(someApplicationRole, true);

            //assert
            Assert.Throws<InvalidOperationException>(() =>
            sut.Add(someApplicationRole, true))
                .Message.Equals("there is already a similar existing item in repository.");

        }

        [Fact]
        public void Update_Method_Of_ApplicationService_Should_Throw_Exeception_On_Updating_Not_Existing_Role()
        {
            //arrange

            var someRole = new RoleTestBuilder().AddSomeRole();
            var someApplicationRole = mapper.Map<ApplicationRoleDto>(someRole);
            sut.Add(someApplicationRole, true);

            var anotherRole = new RoleTestBuilder().AddAnotherRole();
            var anotherApplicationRole = mapper.Map<ApplicationRoleDto>(anotherRole);

            //assert
            Assert.Throws<InvalidOperationException>(() =>
            sut.Update(anotherApplicationRole, true))
                .Message.Equals("there is no wanted entity to be updated.");

        }

    }


}
