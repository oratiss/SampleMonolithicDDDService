using Persistence.Models.Positions;
using Utilities.Enums.UserAccounting.Positions;
using Utilities.ReflectionTools;
using SharedValueObject.UserAccounting;
using static Utilities.SharedTools.Constants.PositionConstants;



namespace PersistenceTest.Positions
{
    public class PersistencePositionTestBuilder : ReflectionBuilder<Position, PersistencePositionTestBuilder>
{
    private readonly PersistencePositionTestBuilder _builderInstance = null;

    public int Id = someId;
    public string Title = someTitle;
    public string Code = someCode;
    public DamageType DamageType = DamageType.Undefined;
    public ErgonomicStatus ErgonomicStatus = ErgonomicStatus.Undefined;
    public PositionActivity PositionActivity = new PositionActivity(false, false, false, false, false, null);
    public string CustomesCode = someCustomesCode;
    public string Description = someDescription;
    public bool IsActive = someIsActive;
    public int RoleId = someRoleId;

    public PersistencePositionTestBuilder()
    {
        _builderInstance = this;
    }

    public override Position Build()
    {
        return new Position(Id,Title,Code,DamageType,ErgonomicStatus,PositionActivity,CustomesCode,Description,IsActive,RoleId);
    }
}
}
