

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

            var start = $"<-------------------> {name} ({version}) <------------------->";
            var finish = $"<{new string('-', start.Length - 2)}>";

            LoggerUtils.LogInfo(start);

            if(patchAll)
            {
                LoggerUtils.LogInfo($">> Loading harmony patches for '{name} {version}'");
                harmony.PatchAll();
                LoggerUtils.LogInfo($">> Finished loading harmony patches for '{name} {version}'..");
            }

            LoggerUtils.LogInfo(finish);
        }
    }
}