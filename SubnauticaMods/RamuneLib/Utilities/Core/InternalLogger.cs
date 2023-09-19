

namespace RamuneLib
{
    public static class InternalLogger
    {
        public static ManualLogSource logger = Utilities._InternalLogger;

        public static void Log(string text, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    logger.LogDebug(text);
                    break;

                case LogLevel.Error:
                    logger.LogError(text);
                    break;

                case LogLevel.Info:
                    logger.LogInfo(text);
                    break;

                case LogLevel.Warning:
                    logger.LogWarning(text);
                    break;

                case LogLevel.Fatal:
                    logger.LogFatal(text);
                    break;
            }
        }
    }
}