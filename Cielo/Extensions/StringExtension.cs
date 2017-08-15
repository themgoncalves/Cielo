using System.Text.RegularExpressions;

namespace Cielo.Extensions
{
    public static class StringExtension
    {
        public static string ToNumbers(this string item)
        {
            return Regex.Replace(item, "[^0-9]", string.Empty);
        }

        public static string RegexReplace(this string item, string pattern, string replacementValue)
        {
            return Regex.Replace(item, pattern, replacementValue);
        }

        public static string ToMaxLength(this string item, int maxLength)
        {
            return (item.ToString().Length > maxLength ? item.ToString().Substring(0, maxLength) : item.ToString().Substring(0, item.ToString().Length));
        }
    }
}
