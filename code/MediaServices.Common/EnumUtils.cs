using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaServices.Common
{
    public static class EnumUtils
    {
        public static string GetDescription<T>(T enumValue)
        {
            return GetDescription(typeof(T), enumValue);
        }

        public static IList<string> GetDescriptions<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            return array.Select(GetDescription).ToList();
        }

        public static string GetDescription(Type type, object enumValue)
        {
            MemberInfo field = type.GetMember(enumValue.ToString()).FirstOrDefault();
            if (field != null)
            {
                DescriptionAttribute attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

                if (attribute != null)
                    return attribute.Description;
            }

            return enumValue.ToString();
        }
    }
}
