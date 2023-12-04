

namespace Ramune.Seal.ConfigurableDepth
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealConfigurableDepth : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SealConfigurableDepth Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.ConfigurableDepth";
        public const string Name = "Seal Configurable Depth";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}