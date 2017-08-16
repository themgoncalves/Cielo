using System;
using System.ComponentModel;
using System.Reflection;

namespace Cielo.Extensions
{
    public static class EnumExtension
    {
        public static TEnum ToEnum<TEnum>(this string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, true);
        }

        public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue) where TEnum : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            TEnum result;
            return Enum.TryParse<TEnum>(value, true, out result) ? result : defaultValue;
        }

        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),

                                              false);

                if (attrs != null && attrs.Length > 0)

                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return en.ToString();
        }
    }
}
