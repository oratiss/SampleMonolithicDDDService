using FluentAssertions;
using IntegrationTest.UserAccounting.Roles.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using TestBridge.Controllers.UserAccounting.Roles;
using Utilities.BasedSetMappers;
using Utilities.SharedTools.Assertions;
using WebApi.AutoMapper;
using Xunit;

namespace IntegrationTest.UserAccounting.Roles
{
    public class RoleIntegrationTests: BaseTestWithSetMapper
    {
        private RoleController sut;

        public RoleIntegrationTests() : base(new AutoMapperConfiguration())
        {
            services.AddHttpClient();
            var serviceProvider = services.BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            sut =new RoleController(httpClientFactory);
        }

        [Fact]
        public async void Index_Method_Of_Bridge_Role_Controller_Should_Get_All_Roles()
        {
            //Arrange
            var (someRole, anotherRole) = await this.AddSomeRoles(sut);

            var someAnother = new BridgeRoleTestBuilder().AddSomeAnotherRole();
            someAnother = await sut.Create(someAnother);

            //Act
            var actual = await sut.Index();

            //Assert
            var expected= new BridgeRoleTestBuilder()
                .With(r => r.Id, someAnother.Id)
                .With(r => r.Title, someAnother.Title)
                .With(r => r.Description, someAnother.Description)
                .With(r => r.SystemDescription, someAnother.SystemDescription)
                .Build();

            var check = actual.IsContaining(expected);
            check.Should().BeTrue();
        }

        [Fact]
        public async void Create_Method_Of_Bridge_Role_Controller_Should_Create_Role()
        {
            //Arrange
            var (someRole, anotherRole) = await this.AddSomeRoles(sut);

            var someAnother = new BridgeRoleTestBuilder().AddSomeAnotherRole();

            //Act
            var actual = await sut.Create(someAnother);

            //Assert
            var expected = new BridgeRoleTestBuilder()
                .With(r => r.Id, actual.Id)//Id is  managed by sysstem
                .With(r => r.Title, someAnother.Title)
                .With(r => r.Description, someAnother.Description)
                .With(r => r.SystemDescription, someAnother.SystemDescription)
                .Build();

            var check = actual.Compare(expected);
            check.Should().BeTrue();
        }


        [Fact]
        public async void Delete_Method_Of_Bridge_Role_Controller_Should_Delete_Given_Role()
        {
            //Arrange
            var (someRole, anotherRole) = await this.AddSomeRoles(sut);

            var someAnother = new BridgeRoleTestBuilder().AddSomeAnotherRole();
            someAnother = await sut.Create(someAnother);

            //Act
            await sut.Delete(someAnother);

            //Assert
            var expected = new BridgeRoleTestBuilder()
                .With(r => r.Id, someAnother.Id)//Id is  managed by sysstem
                .With(r => r.Title, someAnother.Title)
                .With(r => r.Description, someAnother.Description)
                .With(r => r.SystemDescription, someAnother.SystemDescription)
                .Build();

            var actual =await sut.Index();

            var check = actual.IsContaining(expected);
            check.Should().BeFalse();
        }

        [Fact]
        public async void DeleteById_Method_Of_Bridge_Role_Controller_Should_Delete_Given_Role_With_Given_Id()
        {
            //Arrange
            var (someRole, anotherRole) = await this.AddSomeRoles(sut);

            var someAnother = new BridgeRoleTestBuilder().AddSomeAnotherRole();
            someAnother = await sut.Create(someAnother);

            //Act
            await sut.DeleteById(someAnother.Id);

            //Assert
            var expected = new BridgeRoleTestBuilder()
                .With(r => r.Id, someAnother.Id)//Id is  managed by sysstem
                .With(r => r.Title, someAnother.Title)
                .With(r => r.Description, someAnother.Description)
                .With(r => r.SystemDescription, someAnother.SystemDescription)
                .Build();

            var actual = await sut.Index();

            var check = actual.IsContaining(expected);
            check.Should().BeFalse();
        }

        [Fact]
        public async void Update_Method_Of_Bridge_Role_Controller_Should_Update_Given_Role()
        {
            //Arrange
            var (someRole, anotherRole) = await this.AddSomeRoles(sut);

            var someAnotherRole = new BridgeRoleTestBuilder().AddSomeAnotherRole();
            someAnotherRole = await sut.Create(someAnotherRole);

            var updatingRole=new BridgeRoleTestBuilder()
                .With(r => r.Id, someAnotherRole.Id)
                .With(r => r.Title, someRole.Title)
                .With(r => r.Description, someRole.Description)
                .With(r => r.SystemDescription, someRole.SystemDescription)
                .Build();

            //Act
            var actual = await sut.Edit(updatingRole);

            //Assert
            var expected = new BridgeRoleTestBuilder()
                .With(r => r.Id, someAnotherRole.Id)
                .With(r => r.Title, someRole.Title)
                .With(r => r.Description, someRole.Description)
                .With(r => r.SystemDescription, someRole.SystemDescription)
                .Build();

            var check = actual.Compare(expected);
            check.Should().BeTrue();
        }


    }
}
