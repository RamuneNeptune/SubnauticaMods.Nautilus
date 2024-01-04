

namespace Ramune.SealRailingSettings
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealRailingSettings : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SealRailingSettings Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.RailingSettings";
        public const string Name = "Seal Railing Settings";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}