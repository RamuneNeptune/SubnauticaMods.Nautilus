

namespace Ramune.RamunesWorkbench.Buildables
{
    public static class RamunesWorkbench
    {
        public static Texture2D MainTex = ImageUtils.GetTexture("RamunesWorkbench.Texture");
        public static Texture2D Illum = ImageUtils.GetTexture("RamunesWorkbench.Illum");
        public static List<(string id, string displayName, object spriteOrTechType, string[] pathToTab)> queuedTabNodes = new();
        public static List<(TechType itemToCraft, string[] pathToTab)> queuedCraftNodes = new();
        public static CraftTree.Type craftTreeType;

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RamunesWorkbench", "Ramune's workbench", "Used to create items from RamuneNeptune's mods", ImageUtils.GetSprite("RamunesWorkbench"))
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Workbench)
            .WithJsonRecipe("RamunesWorkbench")
            .WithFabricator(out craftTreeType);


        public static void Patch()
        {
            var model = new FabricatorTemplate(Prefab.Info, craftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Workbench,
                ModifyPrefab = go =>
                {
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

            Prefab.SetGameObject(model);
            Prefab.Register();
        }
    }
}