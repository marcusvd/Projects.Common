namespace Projects.Common.Validations;

using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

public class BusinessRuleTransit
{
    public static bool IsEquals(object object1, object object2) => object1.Equals(object2);
    public static bool IsEquals(string text1, string text2) => text1.Equals(text2);
    public static bool IsWithinLength(string stringValue, int maximum) => stringValue.Trim().Length <= maximum;

    public static bool IsValidStringForLengthCheck(string stringValue, int min, int max) => !IsNullOrWhiteSpace(stringValue) && IsWithinLength(stringValue, min, max);
    public static bool IsWithinLength(string stringValue, int minimum, int maximum) => (stringValue.Trim().Length >= minimum) && (stringValue.Trim().Length <= maximum);
    public static bool IsRegexMatch(string pattern, string stringValue) => new Regex(pattern).IsMatch(stringValue);

    public static bool IsNullOrWhiteSpace(string stringValue) => string.IsNullOrWhiteSpace(stringValue) ? true : false;
    public static bool IsObjNull(object object1) => object1 == null;

    public static bool IsValidFileCollection(IFormFileCollection files) => (files is not null) && (files.Count > 0) && files.All(x => !string.IsNullOrEmpty(x.FileName));
    public static bool IsValidArray(string[] array) => (array is not null) && (array.Length > 0) && array.All(x => !string.IsNullOrEmpty(x));

    public static bool IsWithinRange(double value, double minimum, double maximum) => value >= minimum && value <= maximum;
    public static bool IsWithinRange(float value, float minimum, float maximum) => value >= minimum && value <= maximum;
    public static bool IsWithinRange(int value, int minimum, int maximum) => value >= minimum && value <= maximum;

    public static bool IsWithinRange(long value, long minimum, long maximum) => value >= minimum && value <= maximum;
    protected BusinessRuleTransit() { }

    protected bool SelfIsEquals(object object1, object object2)
            => BusinessRuleTransit.IsEquals(object1, object2);

    protected bool SelfIsWithinLength(string stringValue, int maximum)
        => BusinessRuleTransit.IsWithinLength(stringValue, maximum);

    protected bool SelfIsValidStringForLengthCheck(string stringValue, int min, int max)
        => BusinessRuleTransit.IsValidStringForLengthCheck(stringValue, min, max);

    protected bool SelfIsWithinLength(string stringValue, int minimum, int maximum)
        => BusinessRuleTransit.IsWithinLength(stringValue, minimum, maximum);

    protected bool SelfIsRegexMatch(string pattern, string stringValue)
        => BusinessRuleTransit.IsRegexMatch(pattern, stringValue);

    protected bool SelfIsNullOrWhiteSpace(string stringValue)
        => BusinessRuleTransit.IsNullOrWhiteSpace(stringValue);

    protected bool SelfIsObjNull(object object1)
        => BusinessRuleTransit.IsObjNull(object1);

    protected bool SelfIsValidFileCollection(IFormFileCollection files)
        => BusinessRuleTransit.IsValidFileCollection(files);

    protected bool SelfIsValidArray(string[] array)
        => BusinessRuleTransit.IsValidArray(array);

    protected bool SelfIsWithinRange(double value, double minimum, double maximum)
        => BusinessRuleTransit.IsWithinRange(value, minimum, maximum);

    protected bool SelfIsWithinRange(float value, float minimum, float maximum)
        => BusinessRuleTransit.IsWithinRange(value, minimum, maximum);

    protected bool SelfIsWithinRange(int value, int minimum, int maximum)
        => BusinessRuleTransit.IsWithinRange(value, minimum, maximum);

    protected bool SelfIsWithinRange(long value, long minimum, long maximum)
        => BusinessRuleTransit.IsWithinRange(value, minimum, maximum);
}



