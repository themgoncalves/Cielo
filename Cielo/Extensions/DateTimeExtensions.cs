using System;

namespace Cielo.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCieloFormatDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss");
        }
        public static string ToCieloShortFormatDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string ToCieloFormatDate(this DateTime? date)
        {
            return date?.ToString("yyyy-MM-ddTHH:mm:ss");
        }
        public static string ToCieloShortFormatDate(this DateTime? date)
        {
            return date?.ToString("yyyy-MM-dd");
        }
    }
}
