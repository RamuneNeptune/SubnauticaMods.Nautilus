

namespace Ramune.ConfigurableSeaglide
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class ConfigurableSeaglide : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static ConfigurableSeaglide Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.ConfigurableSeaglide";
        public const string Name = "Configurable Seaglide";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}