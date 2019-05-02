using Bukimedia.PrestaSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Helpers
{
    public static class CompareHelper
    {
        public static IEnumerable<string> DifferentValueFields(product LeftProduct, product RightProduct)
        {
            var properties = new List<string>();
            foreach (var propertyInfo in LeftProduct.GetType().GetProperties())
            {
                if (propertyInfo.Name.StartsWith("id") || propertyInfo.Name.StartsWith("associations"))
                {
                    continue;
                }
                var type = propertyInfo.PropertyType;
                if (type.Name.StartsWith("Nullable"))
                {
                    type = type.GenericTypeArguments[0];
                }
                object leftNullableValue = propertyInfo.GetValue(LeftProduct);
                object rightNullableValue = propertyInfo.GetValue(RightProduct);
                var leftValue = leftNullableValue == null ? null : Convert.ChangeType(leftNullableValue, type);
                var rightValue = rightNullableValue == null ? null : Convert.ChangeType(rightNullableValue, type);
                if (type == typeof(List<Bukimedia.PrestaSharp.Entities.AuxEntities.language>))
                {
                    leftValue = LanguageHelper.GetString(leftValue as IEnumerable<Bukimedia.PrestaSharp.Entities.AuxEntities.language>);
                    rightValue = LanguageHelper.GetString(rightValue as IEnumerable<Bukimedia.PrestaSharp.Entities.AuxEntities.language>);
                }
                if (!Equals(leftValue, rightValue))
                {
                    properties.Add(propertyInfo.Name);
                }
            }
            return properties;
        }
    }
}
