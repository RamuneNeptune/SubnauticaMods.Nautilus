

namespace RamuneLib
{
    public static class LoggerUtils
    {
        public static class Screen
        {
            public enum LogLevel
            {
                [EnumString("<color=#54c8f2><b>Info:</b></color>")] Info,

                [EnumString("<color=#b30000><b>Error:</b></color>")] Error,

                [EnumString("<color=#b1b1b1><b>Debug:</b></color>")] Debug,

                [EnumString("<color=#ffac00><b>Warning:</b></color>")] Warning,

                [EnumString("<color=#00b300><b>Success:</b></color>")] Success,

                [EnumString("<color=#b30000><b>Fail:</b></color>")] Fail
            }

            public static void LogInfo(string message) => ErrorMessage.AddError(LogLevel.Info.GetEnumStringValue() + " " + message);


            public static void LogError(string message) => ErrorMessage.AddError(LogLevel.Error.GetEnumStringValue() + " " + message);


            public static void LogDebug(string message) => ErrorMessage.AddError(LogLevel.Debug.GetEnumStringValue() + " " + message);


            public static void LogWarning(string message) => ErrorMessage.AddError(LogLevel.Warning.GetEnumStringValue() + " " + message);


            public static void LogSuccess(string message) => ErrorMessage.AddError(LogLevel.Success.GetEnumStringValue() + " " + message);


            public static void LogFail(string message) => ErrorMessage.AddError(LogLevel.Fail.GetEnumStringValue() + " " + message);
        }


        /// <summary>
        /// Logs a message to the screen using ErrorMessage.AddError
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogScreen("This is an example message to display on the screen.");
        /// </code>
        /// </example>
        public static void LogScreen(string message) => ErrorMessage.AddError(message);


        /// <summary>
        /// Logs a message to the screen using ErrorMessage.AddError
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="logLevel">This is just a prefix to the message, e.g. LoggerUtils.LogLevel.Info == "Info: {message}"</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogScreen("This is an example message to display on the screen.", LoggerUtils.ScreenLevel.Info);
        /// </code>
        /// </example>
        public static void LogScreen(string message, LogLevel logLevel) => ErrorMessage.AddError(logLevel.GetEnumStringValue() + " " + message);


        /// <summary>
        /// Logs an informational message using the logger if available.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogInfo("This is an example informational message.");
        /// </code>
        /// </example>
        public static void LogInfo(string message) => Variables.logger?.LogInfo(message);


        /// <summary>
        /// Logs a debug message using the logger if available.
        /// </summary>
        /// <param name="message">The debug message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogDebug("This is an example debug message.");
        /// </code>
        /// </example>
        public static void LogDebug(string message) => Variables.logger?.LogDebug(message);


        /// <summary>
        /// Logs a warning message using the logger if available.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogWarning("This is an example warning message.");
        /// </code>
        /// </example>
        public static void LogWarning(string message) => Variables.logger?.LogWarning(message);


        /// <summary>
        /// Logs an error message using the logger if available.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogError("This is an example error message.");
        /// </code>
        /// </example>
        public static void LogError(string message) => Variables.logger?.LogError(message);


        /// <summary>
        /// Logs a fatal message using the logger if available.
        /// </summary>
        /// <param name="message">The fatal message to log.</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogFatal("This is an example fatal message.");
        /// </code>
        /// </example>
        public static void LogFatal(string message) => Variables.logger?.LogFatal(message);


        /// <summary>
        /// Logs a subtitle message with optional duration and delay.
        /// </summary>
        /// <param name="message">The subtitle message to log.</param>
        /// <param name="duration">The duration to display the subtitle (default is 5 seconds).</param>
        /// <param name="delay">The delay before displaying the subtitle (default is -1 seconds).</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogSubtitle("This is an example subtitle message.", duration: 10f, delay: 2f);
        /// </code>
        /// </example>
        public static void LogSubtitle(string message, float duration = 5f, float delay = -1f)
        {
            var builder = new StringBuilder();
            builder.Append(message);

            Subtitles.AddRawLong(1, builder, delay, duration);
        }
    }
}