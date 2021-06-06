using Utilities.Enums.UserAccounting.Positions;

namespace Utilities.SharedTools.Constants
{
    public class PositionConstants
    {
        public static readonly int someId = 1;
        public static readonly string someTitle = "someTitle";
        public static readonly string someCode = "0123456789";
        public static DamageType someDamageType = DamageType.Undefined;
        public static ErgonomicStatus someErgonomicStatus = ErgonomicStatus.Undefined;
        public static readonly string someCustomesCode = "987654321";
        public static readonly string someDescription = "someDescription";
        public static readonly bool someIsActive= true;
        public static readonly long someRoleId = 1;
        
        public static readonly int anotherId = 2;
        public static readonly string anotherTitle = "anotherTitle";
        public static readonly string anotherCode = "123456";
        public static DamageType anotherDamageType = DamageType.Undefined;
        public static ErgonomicStatus anotherErgonomicStatus = ErgonomicStatus.Undefined;
        public static readonly string anotherCustomesCode = "564321";
        public static readonly string anotherDescription = "anotherDescription";
        public static readonly bool anotherIsActive= true;
        public static readonly long anotherRoleId = 1;

        public static readonly int someAnotherId = 3;
        public static readonly string someAnotherTitle = "someAnotherTitle";
        public static readonly string someAnotherCode = "654321";
        public static DamageType someAnotherDamageType = DamageType.Undefined;
        public static ErgonomicStatus someAnotherErgonomicStatus = ErgonomicStatus.Undefined;
        public static readonly string someAnotherCustomesCode = "987654";
        public static readonly string someAnotherDescription = "someAnotherDescription";
        public static readonly bool someAnotherIsActive= true;
        public static readonly long someAnotherRoleId = 2;

        public static readonly string positionActivityOther = "positionActivityOther";
        public static readonly string invalidTitle_With101Characters
            = $@"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901";

        public static readonly string invalidCode_With51Characters
            = $@"0123456789012345678901234567890123456789012345678901";


        public static string InvalidDescriptionWith201Characters
            = $@"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1
            ";

    }
}
