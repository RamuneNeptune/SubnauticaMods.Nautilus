

namespace Ramune.AchievementUnlocker
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class AchievementUnlocker : BaseUnityPlugin
    {
        public static AchievementUnlocker Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.AchievementUnlocker";
        public const string Name = "AchievementUnlocker";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}