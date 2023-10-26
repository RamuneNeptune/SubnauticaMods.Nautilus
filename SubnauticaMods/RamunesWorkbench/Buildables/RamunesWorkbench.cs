

namespace Ramune.RamunesWorkbench.Buildables
{
    public static class RamunesWorkbench
    {
        public static Texture2D MainTex = ImageUtils.GetTexture("RamunesWorkbench.Texture");
        public static Texture2D Illum = ImageUtils.GetTexture("RamunesWorkbench.Illum");
        public static List<(string id, string displayName, object spriteOrTechType, string[] pathToTab)> queuedTabNodes = new();
        public static List<(TechType itemToCraft, string[] pathToTab)> queuedCraftNodes = new();
        public static CraftTree.Type craftTreeType;

        public static CustomPrefab Prefab = CustomPrefabExtensions.CreatePrefab("RamunesWorkbench", "Ramune's workbench", "Used to create items from RamuneNeptune's mods", ImageUtils.GetSprite(TechType.Workbench)) //"RamunesWorkbench.Sprite"
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator)
            .WithJsonRecipe("RamunesWorkbench")
            .WithFabricator(out craftTreeType);

        public static void Patch()
        {
            var model = new FabricatorTemplate(Prefab.Info, craftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Workbench,
                ModifyPrefab = go =>
                {
                    CraftTreeHandler.AddTabNode(craftTreeType, "One", "One", ImageUtils.GetSprite(TechType.Silver));
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Seaglide, "One");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.RepulsionCannon, "One");

                    CraftTreeHandler.AddTabNode(craftTreeType, "Two", "Two", ImageUtils.GetSprite(TechType.Gold));
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Seaglide, "Two");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.RepulsionCannon, "Two");

                    CraftTreeHandler.AddTabNode(craftTreeType, "Three", "Three", ImageUtils.GetSprite(TechType.Diamond));
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Seaglide, "Three");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.RepulsionCannon, "Three");

                    CraftTreeHandler.AddTabNode(craftTreeType, "Four", "Four", ImageUtils.GetSprite(TechType.AluminumOxide));
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Seaglide, "Four");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.RepulsionCannon, "Four");

                    var renderer = go.GetComponentInChildren<Renderer>();
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._SpecTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._Illum, Illum);
                    renderer.material.EnableKeyword("MARMO_EMISSION");

                    var workbench = go.GetComponent<Workbench>();
                    var ramunesWorkbench = go.AddComponent<Monos.RamunesWorkbench>().CopyComponent(workbench);
                    GameObject.DestroyImmediate(workbench);

                    ramunesWorkbench.renderer = renderer;
                }
            };

            /*
            var popupSprite = Utilities.GetSprite("e");
            var popupSprite = SpriteManager.Get(TechType.Beacon);
            var sprite = Sprite.Create(popupSprite.texture, new Rect(0.0f, 0.0f, popupSprite.texture.width, popupSprite.texture.height), new Vector2(0.5f, 0.5f));

            Prefab.SetUnlock(TechType.HighCapacityTank)
                .WithAnalysisTech(sprite, null, PDAHandler.UnlockImportant, "NotificationBlueprintUnlocked");
            */

            Prefab.SetGameObject(model);
            Prefab.Register();
        }
    }
}