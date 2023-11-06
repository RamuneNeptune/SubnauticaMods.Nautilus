

namespace Ramune.Seal.CustomizableLights
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealCustomizableLights : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SealCustomizableLights Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.CustomizableLights";
        public const string Name = "Seal Customizable Lights";
        public const string Version = "1.0.2";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}