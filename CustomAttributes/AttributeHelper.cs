using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public static class AttributeHelper
    {
        public static IEnumerable<SelectListItem> ToEnumList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var list = new List<SelectListItem>() { new SelectListItem("-- Select --", "") };
            foreach (Enum value in Enum.GetValues(type))
            {
                list.Add(new SelectListItem
                {
                    Text = GetLocalizedDisplayName(value),
                    Value = value.ToString()
                });
            }

            return list;
        }
        public static string GetLocalizedDisplayName(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var displayName = value.ToString();
            MemberInfo[] memInfo = value.GetType().GetMember(value.ToString());
            #region framework ext method
            var attribute = CustomAttributeExtensions.GetCustomAttribute<LocalizedDisplayAttribute>(memInfo[0]);
            return attribute?.DisplayName ?? displayName;
            #endregion
            //(LocalizedDisplayAttribute)value.GetType().GetField(displayName)?.GetCustomAttribute(typeof(LocalizedDisplayAttribute),false);
            //(LocalizedDisplayAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(LocalizedDisplayAttribute));

            #region woking alternate
            var Attribute = memInfo[0]?.CustomAttributes?.
                    Where(t => t.AttributeType == typeof(LocalizedDisplayAttribute))
                    .Select(t => t.NamedArguments)?.FirstOrDefault()?
                    .Where(t => t.MemberName == nameof(LocalizedDisplayAttribute.DisplayName))
                    .Select(t => t.TypedValue).FirstOrDefault();
            return Attribute?.Value?.ToString() ?? displayName; 
            #endregion
        }
    }
}
