

namespace Ramune.RadiantDepths
{
    [BepInDependency("com.snmodding.nautilus")]
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
        public const string Version = "1.0.0.1";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);

            #region Patching
            RadiantCrystal.Patch();    // req: 
            RadiantFabricator.Patch(); // req: radiant crystal
            RadiantCube.Patch();       // req: radiant crystal + fabricator
            RadiantBlade.Patch();      // req: radiant crystal + fabricator + cube
            BrimstoneOre.Patch();      // req: 
            GeyseriteOutcrop.Patch();  // req: brimstone ore
            LodestoneOutcrop.Patch();  // req: 
            SerpentiteOutcrop.Patch(); // req: 
            SiltstoneOutcrop.Patch();  // req: 
            #endregion


            #region Other
            ItemUtils.CreateAltRecipe(" (x2)", TechType.CrashPowder, TechCategory.BasicMaterials, PrefabUtils.CreateRecipe(0, new Ingredient(BrimstoneOre.Prefab.Info.TechType, 1), TechType.CrashPowder, TechType.CrashPowder), CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorsBasicMaterials);
            #endregion
        }
    }
}