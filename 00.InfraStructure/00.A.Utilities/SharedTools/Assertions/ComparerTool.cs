using System.Collections.Generic;
using System.Linq;

namespace Utilities.SharedTools.Assertions
{
    public static class ComparerTool
    {
        //todo: write summary
        public static bool Compare(this object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            //Compare two object's class, return false if they are difference
            if (obj.GetType() != another.GetType()) return false;

            var result = true;
            //Get all properties of obj
            //And compare each other
            foreach (var objProperty in obj.GetType().GetProperties())
            {
                foreach (var anotherProperty in another.GetType().GetProperties())
                {
                    if (objProperty.Name == anotherProperty.Name)
                    {
                        if ((objProperty.Equals(null)  && anotherProperty.Equals(null) ) 
                        || (objProperty.GetValue(obj) == null && anotherProperty.GetValue(another) == null))
                        {
                            break;
                        }

                        var xx = objProperty.GetValue(obj);
                        var yy = anotherProperty.GetValue(another);
                        if (objProperty.PropertyType != anotherProperty.PropertyType
                        || !objProperty.GetValue(obj).Equals(anotherProperty.GetValue(another)))
                        {
                            result = false;
                            return result;
                        }

                        break;
                    }
                }
            }

            return result;
        }

        public static bool IsContaining(this IEnumerable<object> objs, object another)
        {
            if (objs.Count() == 1 && ReferenceEquals(objs.Single(), another)) return true;
            if ((objs == null) || (objs.Count() == 0) || (another == null)) return false;
            //Compare two object's class, return false if they are difference
            if (objs.FirstOrDefault().GetType() != another.GetType()) return false;

            var result = true;
            //Get all properties of All obj in Objs
            //And compare each one with other
            foreach (var obj in objs)
            {
                result = Compare(obj, another);

                if (result)
                {
                    return result;
                }
            }


            return result;
        }
    }


}
