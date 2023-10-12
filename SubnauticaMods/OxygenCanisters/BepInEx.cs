

namespace Ramune.OxygenCanisters
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class OxygenCanisters : BaseUnityPlugin
    {
        public static OxygenCanisters Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.OxygenCanisters";
        public const string Name = "Oxygen Canisters";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            Items.OxygenCanister.Patch();
            Items.LargeOxygenCaniser.Patch();
        }
    }
}