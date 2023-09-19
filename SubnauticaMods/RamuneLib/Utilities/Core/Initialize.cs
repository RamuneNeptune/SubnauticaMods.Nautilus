

namespace RamuneLib
{
    public static partial class Utilities
    {
        public static ManualLogSource _InternalLogger;

        public static void Initialize(Harmony harmony, ManualLogSource logger, string name, string version)
        {
            _InternalLogger = logger;

            if(Piracy.Exists()) return;

            InternalLogger.Log($">> Loading harmony patches for '{name} {version}'..", LogLevel.Info);

            harmony.PatchAll();

            InternalLogger.Log($">> Loaded harmony patches for '{name} {version}'..", LogLevel.Info);
        }
    }
}