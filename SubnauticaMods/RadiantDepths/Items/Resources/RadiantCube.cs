

namespace Ramune.RadiantDepths.Items.Resources
{
    public static class RadiantCube
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantCube", "Radiant cube", "High capacity energy source.", false)
            .WithJsonRecipe("RadiantCube", RadiantFabricator.CraftTreeType, RadiantFabricator.Tabs.Electronics)
            .WithPDACategory(TechGroup.Resources, TechCategory.AdvancedMaterials)
            .WithAutoUnlock();

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PrecursorIonCrystal)
            {
                ModifyPrefab = go =>
                {
                    go.FindChild("Point light").GetComponent<Light>().color = new Color(0.72f, 0f, 0.85f);
                    go.EnsureComponent<Battery>()._capacity = 300000;
                    //Utility.PrefabUtils.AddVFXFabricating(go, "", 1.5f, 1.5f);

                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer, true))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {Prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(Prefab.Id() + "Texture"), true)
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(Prefab.Id() + "Texture"), true)
                        .SetColor(ShaderPropertyID._GlowColor, new(0.67f, 0.1f, 0.85f, 0.4f), true)
                        .SetColor(ShaderPropertyID._Color, new(0.5f, 0f, 0.5f), true);
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}