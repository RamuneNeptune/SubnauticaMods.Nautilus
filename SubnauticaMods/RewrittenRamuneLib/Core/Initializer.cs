

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

            CoroutineHost.StartCoroutine(PatchingUtils.WaitForChainloader());

            // if you use this could you please change it up a bit cause i use this to easily spot which mods are mine in logfile

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

            // if you use this could you please change it up a bit cause i use this to easily spot which mods are mine in logfile
        }
    }
}