

namespace Ramune.NoEpilepsyWarning
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class NoEpilepsyWarning : BaseUnityPlugin
    {
        public static NoEpilepsyWarning Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.NoEpilepsyWarning";
        public const string Name = "No Epilepsy Warning";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}

