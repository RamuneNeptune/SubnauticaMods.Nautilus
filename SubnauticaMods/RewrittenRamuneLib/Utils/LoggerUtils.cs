

namespace RamuneLib
{
    public static class LoggerUtils
    {
        public static void LogScreen(string message) => ErrorMessage.AddMessage(message);


        public static void LogInfo(string message) => Variables.logger?.LogInfo(message);


        public static void LogDebug(string message) => Variables.logger?.LogDebug(message);


        public static void LogWarning(string message) => Variables.logger?.LogWarning(message);


        public static void LogError(string message) => Variables.logger?.LogError(message);


        public static void LogFatal(string message) => Variables.logger?.LogFatal(message);


        public static void LogSubtitle(string message, float delay = -1f, float duration = 5f)
        {
            var builder = new StringBuilder();
            builder.Append(message);

            Subtitles.AddRawLong(1, builder, delay, duration);
        }
    }
}