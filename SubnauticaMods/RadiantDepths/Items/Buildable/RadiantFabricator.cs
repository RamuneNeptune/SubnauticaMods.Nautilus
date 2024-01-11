

namespace Ramune.RadiantDepths.Items.Buildable
{
    public static class RadiantFabricator
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantFabricator", "Radiant fabricator", "A radiant fabricator.", SpriteManager.Get(TechType.Fabricator))
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator)
            .WithJsonRecipe("RadiantFabricator")
            .WithFabricator(out CraftTreeType)
            .WithAutoUnlock();

        public static CraftTree.Type CraftTreeType;

        public static void Patch()
        {
            var fabricator = new FabricatorTemplate(Prefab.Info, CraftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Fabricator,
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponent<Fabricator>(out var fab))
                        throw new MissingComponentException($"Couldn't find fabricator while setting up {Prefab.Id()}");

                    fab.handOverText = $"Use radiant fabricator";
                    fab.pickupOutOfRange = true;

                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer, true))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {Prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(Prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(Prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Illum, ImageUtils.GetTexture(Prefab.Id() + "Illum"));
                }
            };

            CraftTreeHandler.AddTabNode(CraftTreeType, "Tools", "Tools", ImageUtils.GetSprite(Prefab.Id() + "ToolsTabSprite"));
            CraftTreeHandler.AddTabNode(CraftTreeType, "Equipment", "Equipment", ImageUtils.GetSprite(Prefab.Id() + "EquipmentTabSprite"));
            CraftTreeHandler.AddTabNode(CraftTreeType, "Electronics", "Electronics", ImageUtils.GetSprite(Prefab.Id() + "ElectronicsTabSprite"));

            Prefab.SetGameObject(fabricator);
            Prefab.Register();
        }


        public static class Tabs
        {
            public static string Tools => "Tools";
            public static string Equipment => "Equipment";
            public static string Electronics => "Electronics";
        }
    }
}