

namespace RamuneLib
{
    public static class Initializer
    {
        public static void Initialize(Harmony harmony, ManualLogSource logger, string name, string version, bool patchAll = true)
        {
            Variables.harmony = harmony;
            Variables.logger = logger;

            if(Piracy.Exists()) 
                return;

            LoggerUtils.LogInfo($">> Loading harmony patches for '{name} {version}'..");

            if(patchAll) 
                harmony.PatchAll();

            LoggerUtils.LogInfo($">> Loaded harmony patches for '{name} {version}'..");
        }
    }
}