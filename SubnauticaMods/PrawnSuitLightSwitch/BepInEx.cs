

namespace Ramune.PrawnSuitLightSwitch
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class PrawnSuitLightSwitch : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static PrawnSuitLightSwitch Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.PrawnSuitLightSwitch";
        public const string Name = "Prawn Suit Light Switch";
        public const string Version = "2.1.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            LanguageHandler.SetLanguageLine("PrawnLightsOn", "Turn lights <color=#AEF8F8>on</color> ({0})");
            LanguageHandler.SetLanguageLine("PrawnLightsOff", "Turn lights <color=#AEF8F8>off</color> ({0})");
        }
    }
}