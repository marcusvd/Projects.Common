using System.Text.RegularExpressions;

namespace Projects.Common.BuiltInTypesTasks.StringTasks;

public static class StringTypeExtension
{
    public static string NumbersOnlyZero(this string naturalState) =>
         string.IsNullOrEmpty(naturalState) ? "0" : Regex.Replace(naturalState, @"\D", "");

    public static string? NumbersOnlyNull(this string naturalState) =>
         string.IsNullOrEmpty(naturalState) ? null : Regex.Replace(naturalState, @"\D", "");

    public static string NumbersOnlyThrow(this string naturalState) =>
        string.IsNullOrEmpty(naturalState) ? throw new ArgumentException("Value cannot be empty.", naturalState) : Regex.Replace(naturalState, @"\D", "");

}
