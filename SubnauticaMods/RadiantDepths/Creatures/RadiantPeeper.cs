

namespace Ramune.RadiantDepths.Creatures
{
    public static class RadiantPeeper
    {
        public static Dictionary<BiomeType, float> BiomeSpawnData = new()
        {
            { BiomeType.SafeShallows_Grass, 0.5f },
            { BiomeType.SafeShallows_SandFlat, 0.5f },
            { BiomeType.SafeShallows_Wall, 0.5f },
            { BiomeType.SafeShallows_UniqueCreature, 0.5f },
            { BiomeType.SafeShallows_EscapePod, 0.5f },
            { BiomeType.SafeShallows_CaveWall, 0.5f },
        };

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("RadiantPeeper", "Radiant peeper", "A damn radiant peeper.", ImageUtils.GetSprite("RadiantPeeperTexture2"));

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.Peeper)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentsInChildren<Renderer>(out var renderers, true))
                        return;

                    renderers.Where(ren => ren != null).ToList().ForEach(r => r
                        .SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture("RadiantPeeperTexture2"), true)
                        .SetTexture(TextureType.Illum, ImageUtils.GetTexture("RadiantPeeperTexture2"))
                        .SetGlowStrength(1.5f)
                        .ToggleEmission());
                }
            };

            Prefab.SetSpawns(ItemUtils.ConvertToBiomeData(BiomeSpawnData));
            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}