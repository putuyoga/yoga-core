using System;

namespace YogaCore.Extensions
{
    public static class DateExtension
    {
        public static string ToStringMonthYear(this DateTime date)
        {
            return date.ToString("MMMM yyyy");
        }
    }
}
