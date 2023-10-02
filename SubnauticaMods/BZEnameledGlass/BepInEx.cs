

namespace Ramune.BZEnameledGlass
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class BZEnameledGlass : BaseUnityPlugin
    {
        public static BZEnameledGlass Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.BZEnameledGlass";
        public const string Name = "BZ Enameled Glass";
        public const string Version = "1.0.3";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            Items.EnameledGlassClone.Patch();
        }
    }
}