using ExceptionsManagement.DomainExceptions.Positions;
using FluentAssertions;
using SharedValueObject.UserAccounting;
using System;
using Utilities.Enums.UserAccounting.Positions;
using Utilities.SharedTools.Assertions;
using Utilities.SharedTools.ExceptionDictionaries;
using Xunit;
using static Utilities.SharedTools.Constants.PositionConstants;

namespace DomainTest.UserAccounting.Positions
{
    public class DomainPositionTests
    {

        [Fact]
        public void PositionId_In_Constructor_Should_Not_Be_Null()
        {
            //arrange
            int? invalidInt = null;

            //act & assert
            Assert.Throws<InvalidOperationException>(() =>
                new PositionTestBuilder()
                    .With(p => p.Id, invalidInt)
                    .Build());
        }

        [Fact]
        public void Position_Title_In_Position_Constructor_Should_Be_Less_Than_100_characters()
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Title, invalidTitle_With101Characters)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionTitle);
        }

        [Fact]
        public void Position_Title_In_Position_Constructor_Should_Not_Be_Empty()
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Title, string.Empty)
                        .Build())
                        .Equals((long)ExceptionCodes.UserAccountingDomainPositionTitle);
        }

        [Fact]
        public void Position_Title_In_Position_Constructor_Should_Not_Be_WhiteSpace()
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Title, " ")
                        .Build())
                        .Equals((long)ExceptionCodes.UserAccountingDomainPositionTitle);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("a")]
        [InlineData("?")]
        [InlineData("Aa")]
        [InlineData("A?")]
        [InlineData("a*")]
        [InlineData("a5")]
        [InlineData("A5")]
        [InlineData("?5")]
        [InlineData("")]
        [InlineData(" ")]
        public void Position_Code_In_Position_Constructor_Should_Contain_Only_Digits_And_Should_Not_Be_Empty_Or_With_White_Space(string invalidCode)
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Code, invalidCode)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionCode);
        }

        [Theory]
        [InlineData("1321321321")]
        [InlineData("5772357355735472373275")]
        public void Position_Code_In_Position_Constructor_Should_Be_Set_With_Valid_Code_Parameter(string validCode)
        {
            //Arrange
            var somePosition = new PositionTestBuilder()
                .With(p => p.Code, validCode)
                .Build();

            //Assert
            var expected = somePosition;
            expected.Code.Compare(validCode).Should().BeTrue();
        }

        [Fact]
        public void Position_Code_In_Position_Constructor_Should_Be_Less_Than_50_characters()
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Code, invalidCode_With51Characters)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionCode);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("a")]
        [InlineData("?")]
        [InlineData("Aa")]
        [InlineData("A?")]
        [InlineData("a*")]
        [InlineData("a5")]
        [InlineData("A5")]
        [InlineData("?5")]
        [InlineData(" ")]
        public void Position_CustomesCode_In_Position_Constructor_Should_Contain_Only_Digits(string invalidCode)
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.CustomesCode, invalidCode)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionCustomsCode);
        }

        [Fact]
        public void Position_CustomesCode_In_Position_Constructor_Can_Be_Empty()
        {
            //Arrange
            var invalidCode = "";

            //Act
            var somePosition = new PositionTestBuilder()
                .With(p => p.CustomesCode, invalidCode)
                .Build();

            //Assert
            var expected = somePosition;
            string.IsNullOrEmpty(expected.CustomesCode).Should().BeTrue();

        }

        [Fact]
        public void Position_Description_In_Position_Constructor_Should_Not_Be_WhiteSpace()
        {
            //Arrange
            var invalidCode = " ";

            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Description, invalidCode)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionDescription);
        }

        [Fact]
        public void Position_Description_In_Position_Constructor_Should_Not_Be_More_Than_200_Chars()
        {
            //Assert
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.Description, InvalidDescriptionWith201Characters)
                        .Build())
                .Message
                .Equals((long)ExceptionCodes.UserAccountingDomainPositionDescription);
        }

        [Theory]
        [InlineData("aaaaaa")]
        [InlineData("AABBB")]
        [InlineData("535573574")]
        [InlineData("a1")]
        [InlineData("1a")]
        [InlineData("A1")]
        public void Position_Description_In_Position_Constructor_Can_Be_Empty(string validDescription)
        {
            //Act
            var somePosition = new PositionTestBuilder()
                .With(p => p.Description, validDescription)
                .Build();

            //Assert
            var expected = somePosition;
            string.IsNullOrEmpty(expected.Description).Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Position_IsActive_In_Position_Constructor_Should_Be_Set_To_isActive_Parameter(bool isActive)
        {
            //Arrange
            var somePosition = new PositionTestBuilder()
                .With(p => p.IsActive, isActive)
                .Build();

            //Assert
            var expected = somePosition;
            expected.IsActive.Compare(isActive).Should().BeTrue();
        }

        [Theory]
        [InlineData(DamageType.DifficultAndDamaging)]
        [InlineData(DamageType.NotDifficultAndDamaging)]
        [InlineData(DamageType.Undefined)]
        public void Position_DamageType_In_Position_Constructor_Should_Be_Of_DamageEnumType_And_Should_Be_Set_To_Valid_Parameter(DamageType damageType)
        {
            //Arrange
            var somePosition = new PositionTestBuilder()
                .With(p => p.DamageType, damageType)
                .Build();

            //Assert
            var expected = somePosition;
            expected.DamageType.Equals(damageType).Should().BeTrue();
        }

        [Theory]
        [InlineData(100)]
        public void Position_DamageType_In_Position_Constructor_Should_Not_Be_Set_To_Invalid_Parameter(int invalidDamageType)
        {
            //Arrange
            Assert.Throws<PositionException>(() =>
                new PositionTestBuilder()
                .With(p => p.DamageType, (DamageType)invalidDamageType)
                .Build())
                .Equals((long) ExceptionCodes.UserAccountingDomainPositionDamageType);
        }               


        [Theory]
        [InlineData(ErgonomicStatus.Dynamic)]
        [InlineData(ErgonomicStatus.Static)]
        [InlineData(ErgonomicStatus.StaticAndDynamic)]
        public void Position_ErgonomicStatus_In_Position_Constructor_Should_Be_Of_ErgonomicStatusType_And_Should_Be_Set_To_Valid_Parameter(ErgonomicStatus ergonomicStatus)
        {
            //Arrange
            var somePosition = new PositionTestBuilder()
                .With(p => p.ErgonomicStatus, ergonomicStatus)
                .Build();

            //Assert
            var expected = somePosition;
            expected.ErgonomicStatus.Equals(ergonomicStatus).Should().BeTrue();
        }

        [Theory]
        [InlineData(100)]
        public void Position_ergonomicStatus_In_Position_Constructor_Should_Not_Be_Set_To_Invalid_Parameter(int InvalidErgonomicStatus)
        {
            //Arrarnge
            Assert.Throws<PositionException>(() =>
                    new PositionTestBuilder()
                        .With(p => p.ErgonomicStatus, (ErgonomicStatus)InvalidErgonomicStatus)
                        .Build())
                .Message.Equals((long)ExceptionCodes.UserAccountingDomainPositionErgonomicType);
        }

        [Theory]
        [InlineData(true, true, true, true, true, "DefaultOtherBlaBla")]
        [InlineData(true, true, true, false, true, "DefaultOtherBlaBla")]
        [InlineData(false, false, false, false, false, "DefaultOtherBlaBla")]
        public void Position_PositionActivity_In_Position_Constructor_Should_Be_Set_To_Parameter(bool viewing, bool hearing, bool thinking, bool tasting, bool smelling, string other)
        {
            //Arrange
            var somePosition = new PositionTestBuilder()
                .With(p => p.PositionActivity, new PositionActivity(viewing, hearing, thinking, tasting, smelling, other))
                .Build();

            //Assert
            var expected = somePosition;
            expected.PositionActivity
                .Compare(new PositionActivity(viewing, hearing, thinking, tasting, smelling, other)).Should().BeTrue();
        }







    }
}
