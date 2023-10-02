

namespace Ramune.TableCoralMultiplier
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class TableCoralMultiplier : BaseUnityPlugin
    {
        public static TableCoralMultiplier Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.TableCoralMultiplier";
        public const string Name = "Table Coral Multiplier";
        public const string Version = "1.0.2";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}