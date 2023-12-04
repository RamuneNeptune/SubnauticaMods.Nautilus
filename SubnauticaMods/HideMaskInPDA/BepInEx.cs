

namespace Ramune.HideMaskInPDA
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class HideMaskInPDA : BaseUnityPlugin
    {
        public static HideMaskInPDA Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.HideMaskInPDA";
        public const string Name = "Hide Mask In PDA";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}