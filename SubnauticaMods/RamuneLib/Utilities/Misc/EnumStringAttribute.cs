

namespace RamuneLib
{
    public static partial class Utilities
    {
        public class EnumStringAttribute : Attribute
        {
            public string Value { get; }

            public EnumStringAttribute(string value)
            {
                Value = value;
            }
        }
    }

    public static class EnumStringExtensions
    {
        public static string? GetValue(this Enum _)
        {
            return _.GetType().GetField(_.ToString()).GetCustomAttribute<Utilities.EnumStringAttribute>()?.Value;
        }
    }
}