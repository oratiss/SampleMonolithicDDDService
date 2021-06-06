using Domain.UserAccounting.Positions;
using SharedValueObject.UserAccounting;
using Utilities.Enums.UserAccounting.Positions;
using Utilities.ReflectionTools;
using static Utilities.SharedTools.Constants.PositionConstants;

namespace DomainTest.UserAccounting.Positions
{
    public class PositionTestBuilder:ReflectionBuilder<Position, PositionTestBuilder>
    {
        private readonly PositionTestBuilder _builderInstance = null;

        public int Id = someId;
        public string Title = someTitle;
        public string Code = someCode;
        public DamageType DamageType = DamageType.Undefined;
        public ErgonomicStatus ErgonomicStatus = ErgonomicStatus.Undefined;
        public PositionActivity PositionActivity = new PositionActivity(false, false, false, false, false, "someComments");
        public string CustomesCode = someCustomesCode;
        public string Description = someDescription;
        public bool IsActive=someIsActive;
        public long RoleId = someRoleId;

        public PositionTestBuilder()
        {
            _builderInstance = this;
        }

        public override Position Build()
        {
            return new Position(Id,Title,Code,DamageType,ErgonomicStatus,PositionActivity,CustomesCode,Description,IsActive,RoleId);
        }
    }
}