using SharedValueObject.UserAccounting;

using Utilities.Enums.UserAccounting.Positions;

namespace ApplicationService.UserAccounting.Dtos
{
    public class ApplicationPositionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DamageType DamageType { get; set; } = DamageType.Undefined;
        public ErgonomicStatus ErgonomicStatus { get; set; } = ErgonomicStatus.Undefined;
        public PositionActivity PositionActivity { get;set; }
        public string CustomesCode { get;set; }
        public string Description { get;set; }
        public bool IsActive { get; set; } = true;
        public int RoleId { get; set; }

    }
}
