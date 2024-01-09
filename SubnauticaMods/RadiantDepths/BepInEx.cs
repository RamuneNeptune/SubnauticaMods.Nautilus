
global using ECCLibrary;
global using ECCLibrary.Data;
global using Ramune.RadiantDepths.Creatures;
global using Ramune.RadiantDepths.Items.Outcrops;
global using Ramune.RadiantDepths.Items.Resources;
global using ItemUtils = Ramune.RadiantDepths.Items.ItemUtils;


namespace Ramune.RadiantDepths
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("com.lee23.ecclibrary")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RadiantDepths : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static RadiantDepths Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RadiantDepths";
        public const string Name = "Radiant Depths";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Brimstone.Patch();
            GeyseriteOutcrop.Patch();
            LodestoneOutcrop.Patch();
            SerpentiteOutcrop.Patch();
            SiltstoneOutcrop.Patch();
        }
    }
}