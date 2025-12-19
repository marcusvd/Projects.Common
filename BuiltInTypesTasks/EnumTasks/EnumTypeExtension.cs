namespace Projects.Common.BuiltInTypesTasks.EnumTasks;

  public static class EnumTypeExtension
{
    public static TEnum TryParseEnum<TEnum>(this string value) where TEnum : struct
    {
        if (Enum.TryParse(value, true, out TEnum result))
            return result;
        return default;
    }
}