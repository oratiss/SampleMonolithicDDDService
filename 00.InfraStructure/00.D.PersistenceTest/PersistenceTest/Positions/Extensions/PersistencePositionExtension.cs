using Persistence.Repositories.PositionRepository;
using SharedValueObject.UserAccounting;
using static Utilities.SharedTools.Constants.PositionConstants;
using PersistencePosition = Persistence.Models.Positions.Position;

namespace PersistenceTest.Positions.Extensions
{
    public static class PersistencePositionExtension
    {
        public static PositionActivity somePositionActivity = new PositionActivity(false, false, false, false, false, "someText");
        public static PositionActivity anotherPositionActivity = new PositionActivity(false, false, false, false, false, "anotherText");
        public static PositionActivity someAnotherPositionActivity = new PositionActivity(false, false, false, false, false, "someAnotherText");
        public static PersistencePosition AddSomePosition(
            this PersistencePositionTestBuilder persistencePositionTestBuilder)
        {
            return new PersistencePositionTestBuilder()
                .With(p => p.Id, 0)
                .With(p => p.Title, someTitle)
                .With(p => p.Code, someCode)
                .With(p => p.DamageType, someDamageType)
                .With(p => p.ErgonomicStatus, someErgonomicStatus)
                .With(p => p.PositionActivity, somePositionActivity)
                .With(p => p.CustomesCode, someCustomesCode)
                .With(p => p.Description, someDescription)
                .With(p => p.IsActive, someIsActive)
                .With(p => p.RoleId, someRoleId)
                .Build();
        }

        public static PersistencePosition AddAnotherPosition(
            this PersistencePositionTestBuilder persistencePositionTestBuilder)
        {
            return new PersistencePositionTestBuilder()
                .With(p => p.Id, 0)
                .With(p => p.Title, anotherTitle)
                .With(p => p.Code, anotherCode)
                .With(p => p.DamageType, anotherDamageType)
                .With(p => p.ErgonomicStatus, anotherErgonomicStatus)
                .With(p => p.PositionActivity, anotherPositionActivity)
                .With(p => p.CustomesCode, anotherCustomesCode)
                .With(p => p.Description, anotherDescription)
                .With(p => p.IsActive, anotherIsActive)
                .With(p => p.RoleId, anotherRoleId)
                .Build();
        }

        public static PersistencePosition AddSomeAnotherPosition(
            this PersistencePositionTestBuilder persistencePositionTestBuilder)
        {
            return new PersistencePositionTestBuilder()
                .With(p => p.Id, 0)
                .With(p => p.Title, someAnotherTitle)
                .With(p => p.Code, someAnotherCode)
                .With(p => p.DamageType, someAnotherDamageType)
                .With(p => p.ErgonomicStatus, someAnotherErgonomicStatus)
                .With(p => p.PositionActivity, someAnotherPositionActivity)
                .With(p => p.CustomesCode, someAnotherCustomesCode)
                .With(p => p.Description, someAnotherDescription)
                .With(p => p.IsActive, someAnotherIsActive)
                .With(p => p.RoleId, someAnotherRoleId)
                .Build();
        }

        public static (PersistencePosition, PersistencePosition) AddSomePositions(this PositionRepositoryTests positionRepositoryTests, IPositionRepository sut)
        {
            var somePosition = AddSomePosition(new PersistencePositionTestBuilder());
            var anotherPosition = AddAnotherPosition(new PersistencePositionTestBuilder());
            var firstResult = sut.Add(somePosition, true);
            var secondResult = sut.Add(anotherPosition, true);
            return (firstResult, secondResult);
        }
    }
}
