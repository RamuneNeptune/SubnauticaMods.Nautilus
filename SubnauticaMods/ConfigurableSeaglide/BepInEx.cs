

namespace Ramune.ConfigurableSeaglide
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
#if SN
    [BepInProcess("Subnautica.exe")]
#else
    [BepInProcess("SubnauticaZero.exe")]
#endif
    public class ConfigurableSeaglide : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static ConfigurableSeaglide Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
#if SN
        public const string GUID = "com.ramune.ConfigurableSeaglide";
        public const string Name = "Configurable Seaglide";
#else
        public const string GUID = "com.ramune.ConfigurableSeaglideBZ";
        public const string Name = "Configurable Seaglide BZ";
#endif
        public const string Version = "1.0.0";
        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}