
using RootMotion;

namespace RadiantBlade
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class RadiantBlade : BaseUnityPlugin
    {
        public static ManualLogSource logger;
        private static readonly Harmony harmony = new Harmony(myGUID);
        private const string myGUID = "com.ramune.RadiantBlade";
        private const string pluginName = "RadiantBlade";
        private const string versionString = "1.0.0";

        public void Awake()
        {
            logger = Logger;
            Logger.LogInfo($"{pluginName} {versionString} is loading");
            harmony.PatchAll();
            Logger.LogInfo($"{pluginName} {versionString} is loaded");
        }
    }

    [HarmonyPatch(typeof(Player), nameof(Player.Awake))]
    public static class Player_Patch
    {
        public static void Postfix()
        {
            RadiantBlade.logger.LogInfo($"----------- Player.Awake -----------");
        }
    }
}

