using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Utilities.SharedTools.RegularExpressions
{
   public class RegexPatterns
   {
       public static readonly string CanBeEveryThingORNullButNotWhiteSpace = @"^\S+$";
       public static readonly string CanOnlyBeDigitsOrNullButCanNotBeWhiteSpace = @"(^$)|(^\d+$)";
       public static readonly string CanOnlyBeDigits = @"^\d+$";


   }
}
