using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.UnitOfWorks;
using PersistenceTest.Roles.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Utilities.SharedTools.Assertions;

namespace PersistenceTest.Roles
{
    public class RoleRepositoryTests : IDisposable
    {
        private readonly IGenericRepository<Role, int> sut;
        private readonly IUnitOfWork _unitOfWork;
        public RoleRepositoryTests()
        {
            _unitOfWork ??= new UnitOfWork();
            sut = new GenericRepository<Role, int>(_unitOfWork);
        }

        public void Dispose()
        {
            _unitOfWork.Context.Dispose();
            sut.Dispose();
        }

        [Fact]
        public void GetAll_Method_Of_Role_RepositoryService_Should_Get_All_RoleEntities()
        {
            //arrange
            var (someRole, anotherRole) = this.AddSomeRoles(sut);

            //act
            var roles = sut.GetAll();

            //assert
            var firstExpected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, someRole.Id)//Id is handled in Db
                .With(r => r.Title, someRole.Title)
                .With(r => r.Description, someRole.Description)
                .With(r => r.SystemDescription, someRole.SystemDescription)
                .Build();

            var seccondExpected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherRole.Id)//Id is handled in Db
                .With(r => r.Title, anotherRole.Title)
                .With(r => r.Description, anotherRole.Description)
                .With(r => r.SystemDescription, anotherRole.SystemDescription)
                .Build();

            var check = roles.IsContaining(firstExpected) && roles.IsContaining(seccondExpected);
            check.Should().BeTrue();
        }

        [Fact]
        public void Get_Method_Of_Role_RepositoryService_Should_Get_RoleEntity()
        {
            //arrange
            var (_, anotherRole) = this.AddSomeRoles(sut);


            //act
            var result = sut.Get(anotherRole.Id);

            //assert
            var expected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherRole.Id)//Id is handled in Db
                .With(r => r.Title, anotherRole.Title)
                .With(r => r.Description, anotherRole.Description)
                .With(r => r.SystemDescription, anotherRole.SystemDescription)
                .Build();

            var check = result.Compare(expected).Should().BeTrue();
        }

        [Fact]
        public void Add_Method_Of_Role_RepositoryService_Should_Add_RoleEntity()
        {
            //arrange
            this.AddSomeRoles(sut);
            var someAnotherRole = new PersistenceRoleTestBuilder().AddSomeAnotherRole();

            //act
            var result = sut.Add(someAnotherRole, true);

            //assert
            var expected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, result.Id)//Id is handled in Db
                .With(r => r.Title, someAnotherRole.Title)
                .With(r => r.Description, someAnotherRole.Description)
                .With(r => r.SystemDescription, someAnotherRole.SystemDescription)
                .Build();
          var result1 = sut.GetAll();
            sut.GetAll().IsContaining(expected).Should().BeTrue();
        }

        [Fact]
        public void DeleteById_Method_Of_Role_RepositoryService_Should_Delete_RoleEntity()
        {
            //arrange
            var (someRole, anotherRole) = this.AddSomeRoles(sut);

            //act
            sut.Delete(anotherRole.Id, true);

            //assert
            var expected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherRole.Id)//Id is handled in Db
                .With(r => r.Title, anotherRole.Title)
                .With(r => r.Description, anotherRole.Description)
                .With(r => r.SystemDescription, anotherRole.SystemDescription)
                .Build();

            sut.GetAll().IsContaining(expected).Should().BeFalse();
        }

        [Fact]
        public void Delete_Method_Of_Role_RepositoryService_Should_Delete_RoleEntity()
        {
            //arrange
            var (someRole, anotherRole) = this.AddSomeRoles(sut);

            //act
            sut.Delete(anotherRole, true);

            //assert
            var expected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherRole.Id)//Id is handled in Db
                .With(r => r.Title, anotherRole.Title)
                .With(r => r.Description, anotherRole.Description)
                .With(r => r.SystemDescription, anotherRole.SystemDescription)
                .Build();

            sut.GetAll().IsContaining(expected).Should().BeFalse();
        }

        [Fact]
        public void Update_Method_Of_Role_RepositoryService_Should_Update_RoleEntity()
        {
            //arrange
            var (someRole, _) = this.AddSomeRoles(sut);
            var someAnotherRole = new PersistenceRoleTestBuilder().AddSomeAnotherRole();

            var updatingRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, someRole.Id)
                .With(r => r.Title, someAnotherRole.Title)
                .With(r => r.Description, someAnotherRole.Description)
                .With(r => r.SystemDescription, someAnotherRole.SystemDescription)
                .Build();

            someRole.Title = updatingRole.Title;
            someRole.Description = updatingRole.Description;
            someRole.SystemDescription = updatingRole.SystemDescription;

            //act
            var result = sut.Update(someRole, true);

            //assert
            var expected = new PersistenceRoleTestBuilder()
                .With(r => r.Id, result.Id)//Id is handled in Db
                .With(r => r.Title, updatingRole.Title)
                .With(r => r.Description, updatingRole.Description)
                .With(r => r.SystemDescription, updatingRole.SystemDescription)
                .Build();

            sut.GetAll().IsContaining(expected).Should().BeTrue();
        }



    }
}
