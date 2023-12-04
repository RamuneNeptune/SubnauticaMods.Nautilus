

namespace Ramune.LithiumBatteries
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("com.ramune.RamunesWorkbench")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class LithiumBatteries : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static LithiumBatteries Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.LithiumBatteries";
        public const string Name = "Lithium Batteries";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Items.LithiumBattery.Patch();
            Items.LithiumPowerCell.Patch();
            Items.IonBatteryAlt.Patch();
            Items.IonPowerCellAlt.Patch();
        }
    }
}