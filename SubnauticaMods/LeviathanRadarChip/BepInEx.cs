

namespace Ramune.LeviathanRadarChip
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class LeviathanRadarChip : BaseUnityPlugin
    {
        public static LeviathanRadarChip Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.LeviathanRadarChip";
        public const string Name = "Leviathan Radar Chip";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}