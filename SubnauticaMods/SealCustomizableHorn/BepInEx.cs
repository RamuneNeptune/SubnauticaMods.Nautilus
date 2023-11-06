

namespace Ramune.Seal.CustomizableHorn
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealCustomizableHorn : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SealCustomizableHorn Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.CustomizableHorn";
        public const string Name = "Seal Customizable Horn";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}