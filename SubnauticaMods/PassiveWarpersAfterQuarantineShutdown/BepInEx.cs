

namespace Ramune.PassiveWarpersAfterQuarantineShutdown
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class PassiveWarpersAfterQuarantineShutdown : BaseUnityPlugin
    {
        public static PassiveWarpersAfterQuarantineShutdown Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.PassiveWarpersAfterQuarantineShutdown";
        public const string Name = "Passive Warpers After Quarantine Shutdown";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}