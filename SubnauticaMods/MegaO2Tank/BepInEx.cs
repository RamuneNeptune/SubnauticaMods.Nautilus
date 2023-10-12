

namespace Ramune.MegaO2Tank
{
    [BepInDependency("com.snmodding.nautilus")]
    //[BepInDependency("com.ramune.OrganizedWorkbench")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class MegaO2Tank : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static MegaO2Tank Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.MegaO2Tank";
        public const string Name = "Mega O2 Tank";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            Items.MegaO2Tank.Patch();
        }
    }
}