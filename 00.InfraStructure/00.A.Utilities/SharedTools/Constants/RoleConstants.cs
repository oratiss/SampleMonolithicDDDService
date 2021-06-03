namespace Utilities.SharedTools.Constants
{
    public class RoleConstants
    {
        public static readonly int someId = 1;
        public static readonly string someTitle = "someTitle";
        public static readonly string someSystemDescription = "someSystemDescription";
        public static readonly string someDescription = "someDescription";

        public static readonly int anotherId = 2;
        public static readonly string anotherTitle = "anotherTitle";
        public static readonly string anotherSystemDescription = "anotherSystemDescription";
        public static readonly string anotherDescription = "anotherDescription";
        
        public static readonly int someAnotherId = 3;
        public static readonly string someAnotherTitle = "someAnotherTitle";
        public static readonly string someAnotherSystemDescription = "someAnotherSystemDescription";
        public static readonly string someAnotherDescription = "someAnotherDescription";



        public static readonly string invalidTitle_With101Characters
            = $@"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901";

        public static readonly string invalidsyetemDescription_With401Characters
           = $@"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1
            ";

        public static string InvalidDescriptionWith501Characters
            = $@"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                1
            ";

    }
}
