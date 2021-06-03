using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Utilities.ReflectionTools
{
    public abstract class ReflectionBuilder<TReflection, TBuilder>
      where TReflection : class
      where TBuilder : ReflectionBuilder<TReflection, TBuilder>
    {
        private readonly TBuilder _builderInstance = null;

        public ReflectionBuilder()
        {
            //store the concrete builder instance
            _builderInstance = (TBuilder)this;
        }

        private class PropertyWrapper
        {
            public PropertyInfo Property { get; }
            public object Value { get; set; }

            internal PropertyWrapper(PropertyInfo property, object value)
            {
                Property = property;
                Value = value;
            }
        }

        private readonly IDictionary<string, PropertyWrapper> propertiesInfo = new Dictionary<string, PropertyWrapper>();



        public TBuilder With<TValue>(Expression<Func<TReflection, TValue>> exp, TValue value)
        {
            var body = exp.Body as MemberExpression;
            if (body == null)
            {
                throw new InvalidOperationException("Improperly formatted expression");
            }

            var propertyName = body.Member.Name;

            var property = GetType().GetRuntimeField(propertyName);

            if (property != null)
            {
                property.SetValue(_builderInstance, value);
            }
            else
            {
                //if (property.GetType() == typeof(string))
                //{
                //    GetType().GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance)
                //        .SetValue(_builderInstance, "");
                //}
                GetType().GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance)
                          .SetValue(_builderInstance, value);
            }

            return _builderInstance;
        }


        public abstract TReflection Build();

    }
}
