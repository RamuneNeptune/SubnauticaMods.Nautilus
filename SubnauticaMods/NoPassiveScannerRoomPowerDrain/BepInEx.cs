

namespace Ramune.NoPassiveScannerRoomPowerDrain
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class NoPassiveScannerRoomPowerDrain : BaseUnityPlugin
    {
        public static NoPassiveScannerRoomPowerDrain Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.NoPassiveScannerRoomPowerDrain";
        public const string Name = "No Passive Scanner Room Power Drain";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}