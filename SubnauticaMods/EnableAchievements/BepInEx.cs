

namespace Ramune.EnableAchievements
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class EnableAchievements : BaseUnityPlugin
    {
        public static EnableAchievements Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.EnableAchievements";
        public const string Name = "Enable Achievements";
        public const string Version = "1.0.3";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}