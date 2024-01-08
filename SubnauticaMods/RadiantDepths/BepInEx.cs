

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
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Items.Resources.RamuneOutcrop.Patch();
            F();
        }

        public void F()
        {
            var prefab = PrefabUtils.CreatePrefab("RamuneTest", "Ramune test", "Ramune test official, this is real.", ImageUtils.GetSprite(TechType.TitaniumIngot))
                .WithRecipe(PrefabUtils.CreateRecipe(1, new Ingredient(TechType.Titanium)), CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorsAdvancedMaterials)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, TechType.TitaniumIngot)
            {
                ModifyPrefab = go =>
                {
                    if(go.TryGetComponentInChildren<Renderer>(out var renderer, true)) renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture("Test"));
                    else LoggerUtils.LogFatal("Couldn't find renderer for Titanium Ingot clone");
                }
            };

            prefab.SetGameObject(clone);
            prefab.Register();
        }
    }
}