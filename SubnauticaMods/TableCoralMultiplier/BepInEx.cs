

namespace Ramune.TableCoralMultiplier
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class TableCoralMultiplier : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static TableCoralMultiplier Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.TableCoralMultiplier";
        public const string Name = "Table Coral Multiplier";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
        }
    }
}