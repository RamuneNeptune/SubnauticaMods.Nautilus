

namespace RamuneLib
{
    public static class LoggerUtils
    {
        public static void LogScreen(string message) => ErrorMessage.AddMessage(message);


        public static void LogSubtitle(string message) => Subtitles.Add(message);


        public static void LogInfo(string message) => Variables.logger?.LogInfo(message);


        public static void LogDebug(string message) => Variables.logger?.LogDebug(message);


        public static void LogWarning(string message) => Variables.logger?.LogWarning(message);


        public static void LogError(string message) => Variables.logger?.LogError(message);


        public static void LogFatal(string message) => Variables.logger?.LogFatal(message);
    }
}