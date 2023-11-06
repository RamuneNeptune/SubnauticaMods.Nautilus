

namespace RamuneLib
{
    public class EnumStringAttribute : Attribute
    {
        public string Value { get; }

        public EnumStringAttribute(string value)
        {
            Value = value;
        }
    }


    public static class EnumStringExtensions
    {
        public static string GetEnumStringValue(this Enum _enum)
        {
            return _enum.GetType().GetField(_enum.ToString()).GetCustomAttribute<EnumStringAttribute>()?.Value;
        }
    }
}