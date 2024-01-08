

namespace Ramune.ReaperGoldSkin
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("EldritchCarMaker.DroneBuddy")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class ReaperSkin : BaseUnityPlugin
    {
        public static ReaperSkin Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.ReaperGoldSkin";
        public const string Name = "Reaper Gold Skin";
        public const string Version = "1.1.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}