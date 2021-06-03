using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Positions;
using AutoMapper;
using DomainTest.UserAccounting.Positions;
using SharedValueObject.UserAccounting;
using static Utilities.SharedTools.Constants.PositionConstants;

namespace ApplicationTest.UserAccounting.Positions.Extensions
{
    public static class ApplicationPositionExtension
    {

        public static PositionActivity somePositionActivity = new PositionActivity(false, false, false, false, false, "someOtherText");
        public static PositionActivity anotherPositionActivity = new PositionActivity(false, false, false, false, false, "anotherOtherText");
        public static PositionActivity someAnotherPositionActivity = new PositionActivity(false, false, false, false, false, "someAnotherOtherText");
        public static (ApplicationPositionDto, ApplicationPositionDto) AddSomePositions(this PositionApplicationTests positionApplicationTests, IMapper mapper, IApplicationPositionService sut)
        {
            var someApplicationPositionDto = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                .With(p => p.Id, someId)
                .With(p => p.Title, someTitle)
                .With(p => p.Code, someCode)
                .With(p => p.DamageType, someDamageType)
                .With(p => p.ErgonomicStatus, someErgonomicStatus)
                .With(p=>p.PositionActivity,somePositionActivity)
                .With(p => p.CustomesCode, someCustomesCode)
                .With(p => p.Description, someDescription)
                .With(p => p.IsActive, someIsActive)
                .With(p => p.RoleId, someRoleId)
                .Build());

            someApplicationPositionDto = sut.Add(someApplicationPositionDto, true);

            var anotherApplicationPositionDto = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                    .With(p => p.Id, anotherId)
                    .With(p => p.Title, anotherTitle)
                    .With(p => p.Code, anotherCode)
                    .With(p => p.DamageType, anotherDamageType)
                    .With(p => p.ErgonomicStatus, anotherErgonomicStatus)
                    .With(p => p.CustomesCode, anotherCustomesCode)
                    .With(p => p.Description, anotherDescription)
                    .With(p => p.IsActive, anotherIsActive)
                    .With(p => p.RoleId, anotherRoleId)
                    .With(p => p.PositionActivity, anotherPositionActivity)
                    .Build());
            anotherApplicationPositionDto = sut.Add(anotherApplicationPositionDto, true);

            return (someApplicationPositionDto, anotherApplicationPositionDto);
        }

        public static ApplicationPositionDto AddSomeAnotherPosition(this PositionApplicationTests positionApplicationTests, IMapper mapper, IApplicationPositionService sut)
        {

            var anotherApplicationPositionDto = mapper.Map<ApplicationPositionDto>(new PositionTestBuilder()
                .With(p => p.Id, someAnotherId)
                .With(p => p.Title, someAnotherTitle)
                .With(p => p.Code, someAnotherCode)
                .With(p => p.DamageType, someAnotherDamageType)
                .With(p => p.ErgonomicStatus, someAnotherErgonomicStatus)
                .With(p => p.CustomesCode, someAnotherCustomesCode)
                .With(p => p.Description, someAnotherDescription)
                .With(p => p.IsActive, someAnotherIsActive)
                .With(p => p.RoleId, someAnotherRoleId)
                .With(p=>p.PositionActivity,someAnotherPositionActivity)
                .Build());

            return sut.Add(anotherApplicationPositionDto, true);

        }

    }

}
