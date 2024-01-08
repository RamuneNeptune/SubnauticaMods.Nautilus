

namespace Ramune.RadiantDepths.Items
{
    public class ItemUtils
    {
        public static CustomPrefab CreateOutcrop(string id, string name, string description, TechType outcropToCopy, int dropAmount, LootDistributionData.BiomeData[] biomeData, Dictionary<TechType, float> drops)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, TechCategory.BasicMaterials)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, outcropToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(go.TryGetComponent<BreakableResource>(out var breakable))
                        breakable.breakText = "Break " + name.ToLower();

                    if(go.TryGetComponentInChildren<Renderer>(out var renderer))
                        renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"));

                    var outcrop = go.EnsureComponent<Monos.CustomOutcrop>();
                    outcrop.DropAmount = dropAmount;
                    outcrop.AddDrops(drops);

                    // PREVIOUS ATTEMPTS:
                    // ------------------------------------------------------------------------
                    // outcrop.Drops = new()
                    // {
                    //     { TechType.Salt, 1f }
                    // };
                    // ------------------------------------------------------------------------
                    // outcrop.Drops.AddRange(drops);
                    // ------------------------------------------------------------------------
                    // outcrop.Drops = drops;
                    // ------------------------------------------------------------------------
                    // drops.ForEach(pair => outcrop.Drops.Add(pair.Key, pair.Value));
                    // ------------------------------------------------------------------------
                    // outcrop.Drops = new();
                    // --> followed by addrange, or the foreach, doesn't matter doesn't work..
                    // ------------------------------------------------------------------------
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        public static CustomPrefab CreateOutcrop(string id, string name, string description, TechType outcropToCopy, int dropAmount, Action<GameObject> additionalModifyPrefab, LootDistributionData.BiomeData[] biomeData, Dictionary<TechType, float> drops)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, TechCategory.BasicMaterials)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, outcropToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(go.TryGetComponent<BreakableResource>(out var breakable))
                        breakable.breakText = "Break " + name.ToLower();

                    if(go.TryGetComponentInChildren<Renderer>(out var renderer))
                        renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"));

                    var outcrop = go.EnsureComponent<Monos.CustomOutcrop>();
                    outcrop.DropAmount = dropAmount;
                    outcrop.AddDrops(drops);

                    additionalModifyPrefab.Invoke(go);
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        public static LootDistributionData.BiomeData[] ConvertToBiomeData(Dictionary<BiomeType, float> biomeDatas)
        {
            List<LootDistributionData.BiomeData> biomeData = new();

            foreach(var pair in biomeDatas)
            {
                biomeData.Add(new LootDistributionData.BiomeData
                {
                    biome = pair.Key,
                    count = 1,
                    probability = pair.Value,
                });
            }

            return biomeData.ToArray();
        }
    }
}