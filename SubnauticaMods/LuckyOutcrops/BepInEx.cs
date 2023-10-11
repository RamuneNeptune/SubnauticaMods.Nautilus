

namespace Ramune.LuckyOutcrops
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class LuckyOutcrops : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static LuckyOutcrops Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.LuckyOutcrops";
        public const string Name = "Lucky Outcrops";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}