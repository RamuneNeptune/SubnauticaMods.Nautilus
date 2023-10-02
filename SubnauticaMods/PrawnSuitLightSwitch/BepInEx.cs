

namespace Ramune.PrawnSuitLightSwitch
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class PrawnSuitLightSwitch : BaseUnityPlugin
    {
        public static PrawnSuitLightSwitch Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.PrawnSuitLightSwitch";
        public const string Name = "Prawn Suit Light Switch";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}