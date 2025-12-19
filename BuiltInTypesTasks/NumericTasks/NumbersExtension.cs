using System.Globalization;

namespace Projects.Common.BuiltInTypesTasks.NumericTasks;

public static class IntTypeExtension
{
    public static bool IsPositiveNumber(this int number) => number > 0 ? true : false;
    public static bool EqualsZero(this int number) => number == 0;
}
public static class DecimalType
{
    public static decimal? TryParseDecimalNull(this string value) =>
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out var num) ? num : null;

    public static decimal TryParseDecimalZero(this string value) =>
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out var num) ? num : 0;
    public static decimal TryParseDecimalThrow(this string value) =>
        decimal.Parse(value);
}