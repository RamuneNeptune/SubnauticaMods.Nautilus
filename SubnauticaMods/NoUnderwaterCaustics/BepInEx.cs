

namespace Ramune.NoUnderwaterCaustics
{
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class NoUnderwaterCaustics : BaseUnityPlugin
    {
        public static NoUnderwaterCaustics Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.NoUnderwaterCaustics";
        public const string Name = "No Underwater Caustics";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}