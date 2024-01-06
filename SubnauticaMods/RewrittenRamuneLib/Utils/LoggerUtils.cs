

namespace RamuneLib.Utils
{
    public static class LoggerUtils
    {
        public static bool Debug = false;


        /// <summary>
        /// Logs an informational message using the logger if available.
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogInfo("This is an example informational message.");
        /// </code>
        /// </example>
        public static void LogInfo(string message) => Variables.logger?.LogInfo(message);


        /// <summary>
        /// Logs a debug message using the logger if available.
        /// </summary>
        /// <param name="message">The debug message to log</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogDebug("This is an example debug message.");
        /// </code>
        /// </example>
        public static void LogDebug(string message) => Variables.logger?.LogDebug(message);


        /// <summary>
        /// Logs a warning message using the logger if available.
        /// </summary>
        /// <param name="message">The warning message to log</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogWarning("This is an example warning message.");
        /// </code>
        /// </example>
        public static void LogWarning(string message) => Variables.logger?.LogWarning(message);


        /// <summary>
        /// Logs an error message using the logger if available.
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogError("This is an example error message.");
        /// </code>
        /// </example>
        public static void LogError(string message) => Variables.logger?.LogError(message);


        /// <summary>
        /// Logs a fatal message using the logger if available.
        /// </summary>
        /// <param name="message">The fatal message to log</param>
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
        /// <param name="clearSubtitles">Whether it should or should not clear the current subtitles.</param>
        /// <param name="duration">The duration to display the subtitle (default is 5 seconds).</param>
        /// <param name="delay">The delay before displaying the subtitle (default is -1 seconds).</param>
        /// <example>
        /// <code>
        /// LoggerUtils.LogSubtitle("This is an example subtitle message.", duration: 10f, delay: 2f);
        /// </code>
        /// </example>
        public static void LogSubtitle(string message, float duration = 5f, float delay = 0f)
        {
            var builder = new StringBuilder().Append(message);
            Subtitles.AddRawLong(1, builder, delay, duration);
        }


        public static class Screen
        {
            public static List<string> LogLevel = new()
            {
                /*
                "<b>[<color=#54c8f2>Info:</color>]</b>",
                "<b>[<color=#b30000>Error:</color>]</b>",
                "<b>[<color=#b1b1b1>Debug:</color>]</b>",
                "<b>[<color=#ffac00>Warning:</color>]</b>",
                "<b>[<color=#00b300>Success:</color>]</b>",
                "<b>[<color=#b30000>Fail:</color>]</b>"
                */

                /*
                "<b>[<color=#54c8f2>Info</color>]:</b>",
                "<b>[<color=#b30000>Error</color>]:</b>",
                "<b>[<color=#b1b1b1>Debug</color>]:</b>",
                "<b>[<color=#ffac00>Warning</color>]:</b>",
                "<b>[<color=#00b300>Success</color>]:</b>",
                "<b>[<color=#b30000>Fail</color>]:</b>"
                */

                "<b><color=#54c8f2>[Info]</color> </b>",
                "<b><color=#b30000>[Error]</color> </b>",
                "<b><color=#b1b1b1>[Debug]</color> </b>",
                "<b><color=#ffac00>[Warning]</color> </b>",
                "<b><color=#00b300>[Success]</color> </b>",
                "<b><color=#b30000>[Fail]</color> </b>"
            };


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogMessage("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogMessage(string message) => ErrorMessage.AddError(message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Info:' in a blue color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogInfo("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogInfo(string message) => ErrorMessage.AddError(LogLevel[0] + message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Error:' in a red color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogError("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogError(string message) => ErrorMessage.AddError(LogLevel[1] + message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Debug:' in a grey color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogDebug("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogDebug(string message) => ErrorMessage.AddError(LogLevel[2] + message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Debug:' in a red color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogWarning("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogWarning(string message) => ErrorMessage.AddError(LogLevel[3] + message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Debug:' in a green color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogSuccess("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogSuccess(string message) => ErrorMessage.AddError(LogLevel[4] + message);


            /// <summary>
            /// Logs a message to the screen using ErrorMessage.AddError, prefixed with 'Debug:' in a red color
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <example>
            /// <code>
            /// LoggerUtils.Screen.LogFail("This is an example message to display on the screen.");
            /// </code>
            /// </example>
            public static void LogFail(string message) => ErrorMessage.AddError(LogLevel[5] + message);
        }
    }
}