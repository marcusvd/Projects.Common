
using System.Globalization;

namespace Projects.Common.Directories;

public class DateTimeTasksManagement
{
    public static string BasedDateTimeFileName() => DateTime.UtcNow.ToFileTime().ToString();
    public static string BasedDateTimeFileName_DD_MM_YYYY() => string.Format("{0:dd_MM_yyyy}", DateTime.UtcNow);
}

public static class DateTimeExtension
{
    public static string GetMonthNameUsEn(this DateTime date)
    {
        return date.Month switch
        {
            1 => "January",
            2 => "February",
            3 => "March",
            4 => "April",
            5 => "May",
            6 => "June",
            7 => "July",
            8 => "August",
            9 => "September",
            10 => "October",
            11 => "November",
            12 => "December",
            _ => throw new ArgumentOutOfRangeException(nameof(date),
                 "Month number must be between 1 and 12.")
        };
    }
    public static string GetMonthNamePtBr(this DateTime date)
    {

        if (date.Month < 1 || date.Month > 12)
            throw new ArgumentOutOfRangeException(nameof(date.Month));

        string monthName = new CultureInfo("pt-Br").DateTimeFormat.GetMonthName(date.Month);

        return Char.ToUpper(monthName[0]) + monthName.Substring(1);
    }

}