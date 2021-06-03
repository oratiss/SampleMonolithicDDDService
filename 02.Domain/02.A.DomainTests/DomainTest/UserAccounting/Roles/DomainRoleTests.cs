using System;
using ExceptionsManagement.DomainExceptions.Roles;
using Utilities.SharedTools.Constants;
using Utilities.SharedTools.ExceptionDictionaries;
using Xunit;

namespace DomainTest.UserAccounting.Roles
{
    public class DomainRoleTests
    {

        [Fact]
        public void Role_Id_In_Role_Constructor_Should_Not_Be_Empty()
        {
            //arrange
            int? invalidInt = null;
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                                new RoleTestBuilder()
                                .With(r => r.Id, invalidInt)
                                .Build()
            );
        }

        [Fact]
        public void Role_Title_In_Role_Constructor_Should_Be_Less_Than_100_characters()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Title, RoleConstants.invalidTitle_With101Characters)
                .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainRoleTitle);
        }

        [Fact]
        public void Role_Title_In_Role_Constructor_Should_Not_Be_Empty()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Title, string.Empty)
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleTitle);
        }

        [Fact]
        public void Role_Title_In_Role_Constructor_Should_Not_Be_WhiteSpace()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Title, " ")
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleTitle);
        }

        [Fact]
        public void Role_SystemDescription_In_Role_Constructor_Should_Be_Less_Than_400_characters()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.SystemDescription, RoleConstants.invalidsyetemDescription_With401Characters)
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleSystemDescription);
        }

        [Fact]
        public void Role_SystemDescription_In_Role_Constructor_Should_Not_Be_Empty()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Title, string.Empty)
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleSystemDescription);
        }

        [Fact]
        public void Role_SystemDescription_In_Role_Constructor_Should_Not_Be_WhiteSpace()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Title, " ")
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleSystemDescription);
        }

        [Fact]
        public void Role_Description_In_Role_Constructor_Should_Not_Be_WhiteSpace()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Description, " ")
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleDescription);

        }

        [Fact]
        public void Role_Description_In_Role_Constructor_Should_Be_Less_Than_500_Characters()
        {
            Assert.Throws<RoleException>(() => new RoleTestBuilder()
            .With(r => r.Description, RoleConstants.InvalidDescriptionWith501Characters)
            .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleDescription);


        }
        [Fact]
        public void Role_Description_In_Role_Constructor_Should_Not_Be_Empty()
        {
            //Assert
            Assert.Throws<RoleException>(() =>
            new RoleTestBuilder()
                .With(r => r.Description, string.Empty)
                .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainRoleDescription);

        }
    }
}
