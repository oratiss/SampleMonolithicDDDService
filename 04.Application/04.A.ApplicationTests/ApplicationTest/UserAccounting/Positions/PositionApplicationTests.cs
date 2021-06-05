using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Positions;
using ApplicationTest.UserAccounting.Positions.Extensions;
using DomainTest.UserAccounting.Positions;
using DomainTest.UserAccounting.Roles;
using DomainTest.UserAccounting.Roles.Extensions;
using FluentAssertions;
using Persistence.Models.Roles;
using Persistence.Repositories.FakeGenericRepositories;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;
using Persistence.UnitOfWorks;
using Utilities.BasedSetMappers;
using Utilities.SharedTools.Assertions;
using WebApi.AutoMapper;
using Xunit;
using static Utilities.SharedTools.Constants.RoleConstants;

namespace ApplicationTest.UserAccounting.Positions
{
    public class PositionApplicationTests : BaseTestWithSetMapper
    {
        private IApplicationPositionService sut;
        public PositionApplicationTests(IUnitOfWork unitOfWork) : base(new AutoMapperConfiguration())
        {
            var firstDomainRole = new RoleTestBuilder().AddSomeRole();
            var secondDomainRole = new RoleTestBuilder().AddAnotherRole();
            var roleRepository = new GenericFakeRepository<Role, long>(mapper.Map<Role>(firstDomainRole));
            roleRepository.Add(mapper.Map<Role>(secondDomainRole));
            var repository = new FakePositionRepository(roleRepository);

            sut = new PositionApplicationService(unitOfWork, new AutoMapperConfiguration());
        }

        [Fact]
        public void GetAll_Of_ApplicationPositionService_Should_Get_All_Positions_As_PostionDtos()
        {
            //arrange
            var (somePositionDto, anotherPositionDto) = this.AddSomePositions(mapper, sut);

            //Act
            var actualPositionDtos = sut.GetAll();

            //Assert
            var firstPosition = new PositionTestBuilder()
                .With(p => p.Id, somePositionDto.Id)
                .With(p => p.Title, somePositionDto.Title)
                .With(p => p.Code, somePositionDto.Code)
                .With(p => p.DamageType, somePositionDto.DamageType)
                .With(p => p.ErgonomicStatus, somePositionDto.ErgonomicStatus)
                .With(p => p.Description, somePositionDto.Description)
                .With(p => p.CustomesCode, somePositionDto.CustomesCode)
                .With(p => p.IsActive, somePositionDto.IsActive)
                .With(p => p.RoleId, somePositionDto.RoleId)
                .With(p=>p.PositionActivity, somePositionDto.PositionActivity)
                .Build();
            var firstExpcted = mapper.Map<ApplicationPositionDto>(firstPosition);

            var secondPosition = new PositionTestBuilder()
                .With(p => p.Id, anotherPositionDto.Id)
                .With(p => p.Title, anotherPositionDto.Title)
                .With(p => p.Code, anotherPositionDto.Code)
                .With(p => p.DamageType, anotherPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, anotherPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, anotherPositionDto.CustomesCode)
                .With(p => p.Description, anotherPositionDto.Description)
                .With(p => p.IsActive, anotherPositionDto.IsActive)
                .With(p => p.RoleId, anotherPositionDto.RoleId)
                .With(p => p.PositionActivity, anotherPositionDto.PositionActivity)
                .Build();
            var secondExpcted = mapper.Map<ApplicationPositionDto>(secondPosition);

            var check = actualPositionDtos.IsContaining(firstExpcted) && actualPositionDtos.IsContaining(firstExpcted);
            check.Should().BeTrue();

        }

        [Fact]
        public void Get_Of_ApplicationPositionService_Should_Get_Added_Position_As_Expected()
        {
            //arrange
            var (somePositionDto, _) = this.AddSomePositions(mapper, sut);

            //act
            var Actual = sut.Get(somePositionDto.Id);

            //assert
            var expectedPosition = new PositionTestBuilder()
                .With(p => p.Id, somePositionDto.Id)
                .With(p => p.Title, somePositionDto.Title)
                .With(p => p.Code, somePositionDto.Code)
                .With(p => p.DamageType, somePositionDto.DamageType)
                .With(p => p.ErgonomicStatus, somePositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, somePositionDto.CustomesCode)
                .With(p => p.Description, somePositionDto.Description)
                .With(p => p.IsActive, somePositionDto.IsActive)
                .With(p => p.RoleId, somePositionDto.RoleId)
                .With(p => p.PositionActivity, somePositionDto.PositionActivity)
                .Build();
            var expected = mapper.Map<ApplicationPositionDto>(expectedPosition);

            Actual.Compare(expected).Should().BeTrue();
        }

        [Fact]
        public void Add_Of_ApplicationPositionService_Should_Add_Position()
        {
            //arrange
            var (_,someAnotherPositionDto) = this.AddSomePositions(mapper, sut);

            //act
            var actualPositions = sut.GetAll();

            //assert
            var expectedPosition = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                .With(p => p.Id, someAnotherPositionDto.Id)
                .With(p => p.Title, someAnotherPositionDto.Title)
                .With(p => p.Code, someAnotherPositionDto.Code)
                .With(p => p.DamageType, someAnotherPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, someAnotherPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, someAnotherPositionDto.CustomesCode)
                .With(p => p.Description, someAnotherPositionDto.Description)
                .With(p => p.IsActive, someAnotherPositionDto.IsActive)
                .With(p => p.RoleId, someAnotherPositionDto.RoleId)
                .With(p => p.PositionActivity, someAnotherPositionDto.PositionActivity)
                .Build());
            var firstCheck = actualPositions.IsContaining(expectedPosition);
            
            var expectedRole = mapper.Map<ApplicationRoleDto>(new RoleTestBuilder().With(r => r.Id, someAnotherPositionDto.RoleId).Build());
            var actualRole = sut.GetRole(expectedRole.Id);
            var secondCheck = actualRole.Compare(expectedRole);
    
            (firstCheck && secondCheck).Should().BeTrue();
        }

        [Fact]
        public void Update_Of_ApplicationPositionService_Should_Update_Position()
        {
            //arrange
            var (somePositionDto, _) = this.AddSomePositions(mapper, sut);

            var updatingPosition = this.AddSomeAnotherPosition(mapper, sut);
            updatingPosition.Id = somePositionDto.Id;
            var updatingPositionDto = mapper.Map<ApplicationPositionDto>(updatingPosition);

            //act
            sut.Update(updatingPositionDto, true);

            //assert
            var firstExpected = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                .With(p => p.Id, updatingPositionDto.Id)
                .With(p => p.Title, updatingPositionDto.Title)
                .With(p => p.Code, updatingPositionDto.Code)
                .With(p => p.DamageType, updatingPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, updatingPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, updatingPositionDto.CustomesCode)
                .With(p => p.Description, updatingPositionDto.Description)
                .With(p => p.IsActive, updatingPositionDto.IsActive)
                .With(p => p.RoleId, updatingPositionDto.RoleId)
                .With(p => p.PositionActivity, updatingPositionDto.PositionActivity)
                .Build());

            var secondExpected = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                .With(p => p.Id, somePositionDto.Id)
                .With(p => p.Title, somePositionDto.Title)
                .With(p => p.Code, somePositionDto.Code)
                .With(p => p.DamageType, somePositionDto.DamageType)
                .With(p => p.ErgonomicStatus, somePositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, somePositionDto.CustomesCode)
                .With(p => p.Description, somePositionDto.Description)
                .With(p => p.IsActive, somePositionDto.IsActive)
                .With(p => p.RoleId, somePositionDto.RoleId)
                .With(p => p.PositionActivity, somePositionDto.PositionActivity)
                .Build());

            var ActualPositions = sut.GetAll();
            var firstCheck= ActualPositions.IsContaining(firstExpected);
            var secondCheck = !ActualPositions.IsContaining(secondExpected);

            var firstExpectedRole = mapper.Map<ApplicationRoleDto>(new RoleTestBuilder()
                .With(r => r.Id, updatingPositionDto.RoleId)
                .With(r => r.Title, anotherTitle)
                .With(r => r.Description, anotherDescription)
                .With(r => r.SystemDescription, anotherSystemDescription)
                .Build());
            var firstRole = sut.GetRole(updatingPositionDto.RoleId);
            var thirdCheck = firstRole.Compare(firstExpectedRole);

            var secondRole = sut.GetRole(somePositionDto.RoleId);
            var fourthCheck = !firstRole.Compare(secondRole);

            (firstCheck && secondCheck && thirdCheck && fourthCheck).Should().BeTrue();
        }

        [Fact]
        public void Delete_Of_ApplicationPositionService_Should_Delete_Position()
        {
            //arrange
            var (somePositionDto, anotherPositionDto) = this.AddSomePositions(mapper, sut);

            //Act
            sut.Delete(anotherPositionDto, true);

            //Assert
            var expectedPosition = new PositionTestBuilder()
                .With(p => p.Id, anotherPositionDto.Id)
                .With(p => p.Title, anotherPositionDto.Title)
                .With(p => p.Code, anotherPositionDto.Code)
                .With(p => p.DamageType, anotherPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, anotherPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, anotherPositionDto.CustomesCode)
                .With(p => p.Description, anotherPositionDto.Description)
                .With(p => p.IsActive, anotherPositionDto.IsActive)
                .With(p => p.RoleId, anotherPositionDto.RoleId)
                .With(p => p.PositionActivity, anotherPositionDto.PositionActivity)
                .Build();
            var expected = mapper.Map<ApplicationPositionDto>(expectedPosition);

            var actual = sut.GetAll();

            actual.IsContaining(expected).Should().BeFalse();
        }

        [Fact]
        public void DeleteById_Of_ApplicationPositionService_Should_Delete_Position()
        {
            //arrange
            var (somePositionDto, anotherPositionDto) = this.AddSomePositions(mapper, sut);

            //Act
            sut.Delete(anotherPositionDto.Id, true);

            //Assert
            var expectedPosition = new PositionTestBuilder()
                .With(p => p.Id, anotherPositionDto.Id)
                .With(p => p.Title, anotherPositionDto.Title)
                .With(p => p.Code, anotherPositionDto.Code)
                .With(p => p.DamageType, anotherPositionDto.DamageType)
                .With(p => p.ErgonomicStatus, anotherPositionDto.ErgonomicStatus)
                .With(p => p.CustomesCode, anotherPositionDto.CustomesCode)
                .With(p => p.Description, anotherPositionDto.Description)
                .With(p => p.IsActive, anotherPositionDto.IsActive)
                .With(p => p.RoleId, anotherPositionDto.RoleId)
                .With(p => p.PositionActivity, anotherPositionDto.PositionActivity)

                .Build();
            var expected = mapper.Map<ApplicationPositionDto>(expectedPosition);

            var actual = sut.GetAll();

            actual.IsContaining(expected).Should().BeFalse();
        }



    }
}
