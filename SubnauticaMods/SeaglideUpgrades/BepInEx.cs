

namespace Ramune.SeaglideUpgrades
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("com.ramune.RamunesWorkbench")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SeaglideUpgrades : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SeaglideUpgrades Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.SeaglideUpgrades";
        public const string Name = "Seaglide Upgrades";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Items.SeaglideMK1.Patch();
            Items.SeaglideMK2.Patch();
            Items.SeaglideMK3.Patch();
            LoggerUtils.LogInfo(">> Registered custom Seaglides");
        }
    }
}