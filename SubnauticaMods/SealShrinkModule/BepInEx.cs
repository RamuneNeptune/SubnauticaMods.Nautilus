

namespace Ramune.Seal.ShrinkModule
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealShrinkModule : BaseUnityPlugin
    {
        public static SealShrinkModule Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.ShrinkModule";
        public const string Name = "Seal Shrink Module";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}