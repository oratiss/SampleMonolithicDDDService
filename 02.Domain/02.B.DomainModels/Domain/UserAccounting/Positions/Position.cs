using System;
using System.Text.RegularExpressions;
using DomainServiceContract.Positions;
using DomainShared.BaseAggregates;
using ExceptionsManagement.DomainExceptions.Positions;
using SharedValueObject.UserAccounting;
using Utilities.BaseDomain;
using Utilities.Enums.UserAccounting.Positions;
using Utilities.SharedTools.ExceptionDictionaries;
using static Utilities.SharedTools.RegularExpressions.RegexPatterns;

namespace Domain.UserAccounting.Positions
{
    public class Position : BaseDomainEntity<int>,IAggregateRoot
    {
        public string Title { get; private set; }
        public string Code { get; private set; }
        public DamageType DamageType { get; private set; } = DamageType.Undefined;
        public ErgonomicStatus ErgonomicStatus { get; private set; } = ErgonomicStatus.Undefined;
        public PositionActivity PositionActivity { get; private set; }
        public string CustomesCode { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; } = true;
        public long RoleId { get; private set; }

        private IDomainPositionExceptionHelper _roleExceptionHelper = new PositionExceptionHelper();

        public Position(int id, string title, string code, DamageType damageType, ErgonomicStatus ergonomicStatus
            , PositionActivity positionActivity, string customesCode, string description, bool isActive, long roleId) : base(id)
        {

            if (title.Length > 100 || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionTitle);
            }

            var rx = new Regex(CanOnlyBeDigits);
            if (code.Length > 50 || string.IsNullOrWhiteSpace(code) || string.IsNullOrEmpty(code) || !rx.IsMatch(code))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionCode);
            }

            rx = new Regex(CanOnlyBeDigitsOrNullButCanNotBeWhiteSpace);
            if (!string.IsNullOrEmpty(customesCode) && (!rx.IsMatch(customesCode) || customesCode.Length > 50))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionCustomsCode);
            }

            rx = new Regex(CanBeEveryThingORNullButNotWhiteSpace);
            if (!string.IsNullOrEmpty(description) && (!rx.IsMatch(description) || description.Length > 200))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionDescription);
            }

            if (!Enum.IsDefined(typeof(DamageType),damageType))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionDamageType);
            }

            if (!Enum.IsDefined(typeof(ErgonomicStatus),ergonomicStatus))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainPositionErgonomicType);
            }


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



    }
}
