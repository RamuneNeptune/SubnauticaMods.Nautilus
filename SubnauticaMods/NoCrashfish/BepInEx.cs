

namespace Ramune.NoCrashfish
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class NoCrashfish : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static NoCrashfish Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public static string ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public const string GUID = "com.ramune.NoCrashfish";
        public const string Name = "No Crashfish";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}