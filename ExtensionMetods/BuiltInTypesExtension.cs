// using System.Text.RegularExpressions;

// namespace Projects.Common.ExtensionMetods;

// public static class StringType
// {
//     public static string NumbersOnlyZero(this string naturalState) =>
//          string.IsNullOrEmpty(naturalState) ? "0" : Regex.Replace(naturalState, @"\D", "");

//     public static string? NumbersOnlyNull(this string naturalState) =>
//          string.IsNullOrEmpty(naturalState) ? null : Regex.Replace(naturalState, @"\D", "");

//     public static string NumbersOnlyThrow(this string naturalState) =>
//         string.IsNullOrEmpty(naturalState) ? throw new ArgumentException("Value cannot be empty.", naturalState) : Regex.Replace(naturalState, @"\D", "");

// }



// public static class DateTimeType
// {
  

// }
// public static class EnumType
// {
//     public static TEnum TryParseEnum<TEnum>(this string value) where TEnum : struct
//     {
//         if (Enum.TryParse(value, true, out TEnum result))
//             return result;

//         return default;
//     }
// }