

namespace Ramune.RamunesWorkbench.Buildables
{
    public static class RamunesWorkbench
    {
        public static Texture2D MainTex = Utilities.GetTexture("RamunesWorkbench.Texture");
        public static Texture2D Illum = Utilities.GetTexture("RamunesWorkbench.Illum");
        public static CraftTree.Type craftTreeType;

        public static CustomPrefab Prefab = Utilities.CreatePrefab("RamunesWorkbench", "Ramune's workbench", "Used to create items from RamuneNeptune's mods", Utilities.GetSprite(TechType.Workbench)) //"RamunesWorkbench.Sprite"
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator)
            .WithJsonRecipe("RamunesWorkbench.Recipe")
            .WithFabricator(out craftTreeType);


        public static void Patch()
        {
            var model = new FabricatorTemplate(Prefab.Info, craftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Workbench,
                ModifyPrefab = go =>
                {
                    CraftTreeHandler.AddTabNode(craftTreeType, "One", "One", Utilities.GetSprite(TechType.Silver));
                    CraftTreeHandler.AddTabNode(craftTreeType, "Two", "Two", Utilities.GetSprite(TechType.Gold));
                    CraftTreeHandler.AddTabNode(craftTreeType, "Three", "Three", Utilities.GetSprite(TechType.Diamond));
                    CraftTreeHandler.AddTabNode(craftTreeType, "Four", "Four", Utilities.GetSprite(TechType.AluminumOxide));

                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Knife, "One");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Knife, "Two");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Knife, "Three");
                    CraftTreeHandler.AddCraftingNode(craftTreeType, TechType.Knife, "Four");


                    var renderer = go.GetComponentInChildren<Renderer>();
                    renderer.material.SetTexture(ShaderPropertyID._MainTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._SpecTex, MainTex);
                    renderer.material.SetTexture(ShaderPropertyID._Illum, Illum);
                    renderer.material.EnableKeyword("MARMO_EMISSION");


                    var workbench = go.GetComponent<Workbench>();
                    go.AddComponent<Monos.RamunesWorkbench>().CopyComponent(workbench);

                    GameObject.DestroyImmediate(workbench);
                }
            };

            Prefab.SetGameObject(model);
            Prefab.Register();
        }


        public static void QueueCraftingNode(TechType itemToCraft, params string[] pathToTab)
        {

        }


        public static void QueueTabNode(float be, params string[] pathToTab)
        {

        }
    }
}