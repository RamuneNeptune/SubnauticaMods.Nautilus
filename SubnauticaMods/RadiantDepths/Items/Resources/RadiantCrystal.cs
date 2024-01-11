

namespace Ramune.RadiantDepths.Items.Resources
{
    public static class RadiantCrystal
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.Mountains_CaveWall, 0.5f },
        };

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantCrystal", "Radiant crystal", "A piece of radiant crystal.", false)
            .WithPDACategory(TechGroup.Resources, TechCategory.AdvancedMaterials)
            .WithAutoUnlock();

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Kyanite)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer, true))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {Prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(Prefab.Id() + "Texture"), true)
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(Prefab.Id() + "Spec"), true)
                        .SetTexture(TextureType.Illum, ImageUtils.GetTexture(Prefab.Id() + "Texture"), true)
                        .SetColor(ShaderPropertyID._GlowColor, new(0.67f, 0.1f, 0.85f), true)
                        .SetColor(ShaderPropertyID._Color, new(0.67f, 0.1f, 0.85f), true);
                }
            };

            Prefab.SetSpawns(BiomeSpawnData.AsBiomeData());
            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}