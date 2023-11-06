

namespace Ramune.Seal.TurboModule
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("SealSub")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealTurboModule : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SealTurboModule Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.TurboModule";
        public const string Name = "Seal Turbo Module";
        public const string Version = "1.0.1";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);

            Items.SealTurboModule.Register();

            Plugin.RegisterUpgradeModuleFunctionalities(Assembly.GetExecutingAssembly());
        }
    }
}