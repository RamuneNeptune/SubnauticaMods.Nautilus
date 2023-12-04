

namespace Ramune.KeepMyDamnSeaglideLightOffWhenSwitchingBattery
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class KeepMyDamnSeaglideLightOffWhenSwitchingBattery : BaseUnityPlugin
    {
        public static KeepMyDamnSeaglideLightOffWhenSwitchingBattery Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.KeepMyDamnSeaglideLightOffWhenSwitchingBattery";
        public const string Name = "Keep My Damn Seaglide Light Off When Switching Battery";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}