using Persistence.Models.Roles;
using SharedValueObject.UserAccounting;
using Utilities.BaseEntities;
using Utilities.Enums.UserAccounting.Positions;

namespace Persistence.Models.Positions
{
    public class Position:BaseEntity<int>
    {
        public Position(int id) : base(id)
        {
        }
        public string Title { get;  set; }
        public string Code { get;  set; }
        public DamageType DamageType { get;  set; } = DamageType.Undefined;
        public ErgonomicStatus ErgonomicStatus { get;  set; } = ErgonomicStatus.Undefined;
        public PositionActivity PositionActivity { get;  set; }
        public string CustomesCode { get;  set; }
        public string Description { get;  set; }
        public bool IsActive { get;  set; } = true;

        public Position(int id, string title, string code,DamageType damageType, ErgonomicStatus ergonomicStatus
            ,PositionActivity positionActivity, string customesCode, string description,bool isActive ,int roleId) : base(id)
        {
            Title = title;
            Code = code;
            DamageType = damageType;
            ErgonomicStatus = ergonomicStatus;
            PositionActivity = positionActivity;
            CustomesCode = customesCode;
            Description = description;
            IsActive = isActive;
            RoleId = roleId;
        }

        //Navigation Properties
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
