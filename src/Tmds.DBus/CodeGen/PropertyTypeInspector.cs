// Copyright 2016 Tom Deseyn <tom.deseyn@gmail.com>
// This software is made available under the MIT License
// See COPYING for details

using System;
using System.Reflection;

namespace Tmds.DBus.CodeGen
{
    internal class PropertyTypeInspector
    {
        public static void Inspect(FieldInfo field, out string propertyName, out Type propertyType)
        {
            PropertyAttribute attribute = field.GetCustomAttribute<PropertyAttribute>();

            if (attribute?.Name != null)
            {
                propertyName = attribute.Name;
            }
            else
            {
                propertyName = field.Name;
                if (propertyName.StartsWith("_", StringComparison.Ordinal))
                {
                    propertyName = propertyName.Substring(1);
                }
            }

            propertyType = field.FieldType;
            var typeInfo = propertyType.GetTypeInfo();
            bool isNullableType = typeInfo.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (isNullableType)
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }
        }

        public static void Inspect(PropertyInfo propInfo, out string propertyName, out Type propertyType)
        {
            var attribute = propInfo.GetCustomAttribute<PropertyAttribute>();
            
            propertyName = attribute?.Name ?? propInfo.Name;
            propertyType = propInfo.PropertyType;
            var typeInfo = propertyType.GetTypeInfo();
            var isNullableType = typeInfo.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (isNullableType)
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }
        }
    }
}
