

namespace RamuneLib.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Inserts a space directly before a specified target in a string
        /// </summary>
        /// <param name="target">The string to target</param>
        /// <returns></returns>
        public static string InsertSpaceBefore(this string inputString, string target) => inputString.Replace(target, " " + target);
    }
}