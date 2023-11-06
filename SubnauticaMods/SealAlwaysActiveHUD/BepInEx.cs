

namespace Ramune.Seal.AlwaysActiveHUD
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealAlwaysActiveHUD : BaseUnityPlugin
    {
        public static SealAlwaysActiveHUD Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.AlwaysActiveHUD";
        public const string Name = "Seal Always Active HUD";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}