

namespace Ramune.RadiantBlade
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RadiantBlade : BaseUnityPlugin
    {
        public static RadiantBlade Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RadiantBlade";
        public const string Name = "Radiant Blade";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            Items.RadiantBlade.Patch();
        }
    }
}