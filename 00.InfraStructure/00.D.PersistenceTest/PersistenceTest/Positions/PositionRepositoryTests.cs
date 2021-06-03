﻿using FluentAssertions;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.Repositories.PositionRepository;
using Persistence.UnitOfWorks;
using PersistenceTest.Positions.Extensions;
using PersistenceTest.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Utilities.SharedTools.Assertions;
using Xunit;

namespace PersistenceTest.Positions
{
    public class PositionRepositoryTests : BaseRepositoryTests
    {
        private readonly IPositionRepository _sut;
        public IGenericRepository<Role, long> roleRepository { get; set; }

        public PositionRepositoryTests(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _sut = unitOfWork.PositionRepository;
            roleRepository = unitOfWork.RoleRepository;
        }
              
       

        [Fact]
        public void Get_Method_Of_Position_Repository_Should_Get_Position_By_Its_Id()
        {
            //arrange
            var (_, anotherPosition) = this.AddSomePositions(_sut);

            //act and assert
            var actualpPosition = _sut.Get(anotherPosition.Id);
            var actualRole = actualpPosition.Role;
            var expectedRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherPosition.Role.Id)
                .With(r => r.Title, anotherPosition.Role.Title)
                .With(r => r.Description, anotherPosition.Role.Description)
                .With(r => r.SystemDescription, anotherPosition.Role.SystemDescription)
                .Build();

            actualRole.Positions = null;
            actualpPosition.Role = null;

            var expectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, anotherPosition.Id)
                .With(p => p.Title, anotherPosition.Title)
                .With(p => p.Code, anotherPosition.Code)
                .With(p => p.DamageType, anotherPosition.DamageType)
                .With(p => p.ErgonomicStatus, anotherPosition.ErgonomicStatus)
                .With(p => p.PositionActivity, anotherPosition.PositionActivity)
                .With(p => p.CustomesCode, anotherPosition.CustomesCode)
                .With(p => p.Description, anotherPosition.Description)
                .With(p => p.IsActive, anotherPosition.IsActive)
                .With(p => p.RoleId, anotherPosition.RoleId)
                .Build();

            (actualpPosition.Compare(expectedPosition) && actualRole.Compare(expectedRole)).Should().BeTrue();
        }

        [Fact]
        public void GetAll_Method_Of_Position_Repository_Should_Get_All_Positions()
        {
            //arrange

            var (somePositioon, anotherPosition) = this.AddSomePositions(_sut);

            //act
            var actualPositions = _sut.GetAll();
            var actualRoles = new List<Role>();
            foreach (var item in actualPositions)
            {
                actualRoles.Add(item.Role);
            }

            //assert
            var firstExpectedRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, somePositioon.Role.Id)
                .With(r => r.Title, somePositioon.Role.Title)
                .With(r => r.Description, somePositioon.Role.Description)
                .With(r => r.SystemDescription, somePositioon.Role.SystemDescription)
                .Build();
            var secondExpectedRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherPosition.Role.Id)
                .With(r => r.Title, anotherPosition.Role.Title)
                .With(r => r.Description, anotherPosition.Role.Description)
                .With(r => r.SystemDescription, anotherPosition.Role.SystemDescription)
                .Build();

            foreach (var position in actualPositions)
            {
                position.Role.Positions = null;
                position.Role = null;
            }

            var firstExpectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, somePositioon.Id)
                .With(p => p.Title, somePositioon.Title)
                .With(p => p.Code, somePositioon.Code)
                .With(p => p.DamageType, somePositioon.DamageType)
                .With(p => p.ErgonomicStatus, somePositioon.ErgonomicStatus)
                .With(p => p.PositionActivity, somePositioon.PositionActivity)
                .With(p => p.CustomesCode, somePositioon.CustomesCode)
                .With(p => p.Description, somePositioon.Description)
                .With(p => p.IsActive, somePositioon.IsActive)
                .With(p => p.RoleId, somePositioon.RoleId)
                .Build();
            var secondExpectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, anotherPosition.Id)
                .With(p => p.Title, anotherPosition.Title)
                .With(p => p.Code, anotherPosition.Code)
                .With(p => p.DamageType, anotherPosition.DamageType)
                .With(p => p.ErgonomicStatus, anotherPosition.ErgonomicStatus)
                .With(p => p.PositionActivity, anotherPosition.PositionActivity)
                .With(p => p.CustomesCode, anotherPosition.CustomesCode)
                .With(p => p.Description, anotherPosition.Description)
                .With(p => p.IsActive, anotherPosition.IsActive)
                .With(p => p.RoleId, anotherPosition.RoleId)
                .Build();

            var firstCheck = actualRoles.IsContaining(firstExpectedRole) && actualRoles.IsContaining(secondExpectedRole);
            var seconfCheck = actualPositions.IsContaining(firstExpectedPosition) && actualPositions.IsContaining(secondExpectedPosition);
            (firstCheck && seconfCheck).Should().BeTrue();
        }

        [Fact]
        public void Add_Method_Of_Position_Repository_Should_Add_Given_Position()
        {
            //arrange
            var (somePosition, anotherPosition) = this.AddSomePositions(_sut);
            var someAnotherPosition = new PersistencePositionTestBuilder().AddSomeAnotherPosition();

            //act 
            var actualpPosition = _sut.Add(someAnotherPosition, true);
            var actualRole = actualpPosition.Role;

            //assert
            var expectedRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, someAnotherPosition.Role.Id)
                .With(r => r.Title, someAnotherPosition.Role.Title)
                .With(r => r.Description, someAnotherPosition.Role.Description)
                .With(r => r.SystemDescription, someAnotherPosition.Role.SystemDescription)
                .Build();

            actualRole.Positions = null;
            actualpPosition.Role = null;

            var expectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, someAnotherPosition.Id)
                .With(p => p.Title, someAnotherPosition.Title)
                .With(p => p.Code, someAnotherPosition.Code)
                .With(p => p.DamageType, someAnotherPosition.DamageType)
                .With(p => p.ErgonomicStatus, someAnotherPosition.ErgonomicStatus)
                .With(p => p.PositionActivity, someAnotherPosition.PositionActivity)
                .With(p => p.CustomesCode, someAnotherPosition.CustomesCode)
                .With(p => p.Description, someAnotherPosition.Description)
                .With(p => p.IsActive, someAnotherPosition.IsActive)
                .With(p => p.RoleId, someAnotherPosition.RoleId)
                .Build();

            (actualpPosition.Compare(expectedPosition) && actualRole.Compare(expectedRole)).Should().BeTrue();
        }
        [Fact]
        public void Update_Method_Of_Position_Repository_Should_Update_Given_Position()
        {
            //arrange
            var Positions = _sut.GetAll().ToList();
            foreach (var item in Positions)
            {
                _sut.Delete(item, true);
            }
            var (somePositioon, anotherPosition) = this.AddSomePositions(_sut);
            var someAnotherPosition = new PersistencePositionTestBuilder().AddSomeAnotherPosition();
            someAnotherPosition = _sut.Add(someAnotherPosition, true);

            //act
            someAnotherPosition.Title = anotherPosition.Title;
            someAnotherPosition.Code = anotherPosition.Code;
            someAnotherPosition.DamageType = anotherPosition.DamageType;
            someAnotherPosition.ErgonomicStatus = anotherPosition.ErgonomicStatus;
            someAnotherPosition.CustomesCode = anotherPosition.CustomesCode;
            someAnotherPosition.Description = anotherPosition.Description;
            someAnotherPosition.IsActive = anotherPosition.IsActive;
            someAnotherPosition.Role = anotherPosition.Role;
            someAnotherPosition.RoleId = anotherPosition.RoleId;
            someAnotherPosition.PositionActivity = anotherPosition.PositionActivity;

            var actualPosition = _sut.Update(someAnotherPosition, true);
            var actualRole = actualPosition.Role;

            //assert
            var expectedRole = new PersistenceRoleTestBuilder()
                .With(r => r.Id, anotherPosition.Role.Id)
                .With(r => r.Title, anotherPosition.Role.Title)
                .With(r => r.Description, anotherPosition.Role.Description)
                .With(r => r.SystemDescription, anotherPosition.Role.SystemDescription)
                .Build();
            actualRole.Positions = null;
            actualPosition.Role = null;

            var expectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, someAnotherPosition.Id)
                .With(p => p.Title, anotherPosition.Title)
                .With(p => p.Code, anotherPosition.Code)
                .With(p => p.DamageType, anotherPosition.DamageType)
                .With(p => p.ErgonomicStatus, anotherPosition.ErgonomicStatus)
                .With(p => p.PositionActivity, anotherPosition.PositionActivity)
                .With(p => p.CustomesCode, anotherPosition.CustomesCode)
                .With(p => p.Description, anotherPosition.Description)
                .With(p => p.IsActive, anotherPosition.IsActive)
                .With(p => p.RoleId, anotherPosition.RoleId)
                .Build();

            (actualRole.Compare(expectedRole) && actualPosition.Compare(expectedPosition)).Should().BeTrue();
        }
        [Fact]
        public void Delete_Method_Of_Position_Repository()
        {
            //Arrange
            var (somePosition, anotherPosition) = this.AddSomePositions(_sut);


            //Act
            _sut.Delete(anotherPosition,true);
            //Assert
            
            anotherPosition.Role.Positions = null;
            anotherPosition.Role = null;
            
            var expectedPosition = new PersistencePositionTestBuilder()
                .With(p => p.Id, anotherPosition.Id)
                .With(p => p.Title, anotherPosition.Title)
                .With(p => p.Code, anotherPosition.Code)
                .With(p => p.DamageType, anotherPosition.DamageType)
                .With(p => p.ErgonomicStatus, anotherPosition.ErgonomicStatus)
                .With(p => p.PositionActivity, anotherPosition.PositionActivity)
                .With(p => p.CustomesCode, anotherPosition.CustomesCode)
                .With(p => p.Description, anotherPosition.Description)
                .With(p => p.IsActive, anotherPosition.IsActive)
                .With(p => p.RoleId, anotherPosition.RoleId)
                .Build();

            var actual = _sut.GetAll();
            actual.IsContaining(expectedPosition).Should().BeFalse();
        }


    }
}
