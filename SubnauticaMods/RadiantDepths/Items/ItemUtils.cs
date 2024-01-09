

namespace Ramune.RadiantDepths.Items
{
    public class ItemUtils
    {
        public static Dictionary<string, Dictionary<TechType, float>> OutcropPatcher = new();


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
                        renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);

                    var guid = Guid.NewGuid().ToString();
                    var outcrop = go.EnsureComponent<Monos.CustomOutcrop>();
                    outcrop.DropAmount = dropAmount;
                    outcrop.GUID = guid;

                    OutcropPatcher.Add(guid, drops);
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
                        renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);

                    var guid = Guid.NewGuid().ToString();
                    var outcrop = go.EnsureComponent<Monos.CustomOutcrop>();
                    outcrop.DropAmount = dropAmount;
                    outcrop.GUID = guid;

                    OutcropPatcher.Add(guid, drops);
                    additionalModifyPrefab.Invoke(go);
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        public static CustomPrefab CreateResource(string id, string name, string description, TechType resourceToCopy, TechCategory pdaCategory, LootDistributionData.BiomeData[] biomeData, Action<GameObject> additionalModifyPrefab)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, pdaCategory)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new Exception($"Couldn't find renderer while setting up {id}");

                    renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);
                    additionalModifyPrefab.Invoke(go);
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        public static CustomPrefab CreateResource(string id, string name, string description, TechType resourceToCopy, TechCategory pdaCategory, LootDistributionData.BiomeData[] biomeData)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, pdaCategory)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if (!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new Exception($"Couldn't find renderer while setting up {id}");

                    renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        public static CustomPrefab CreateResource(string id, string name, string description, TechType resourceToCopy, TechCategory pdaCategory, Action<GameObject> additionalModifyPrefab)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, pdaCategory)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new Exception($"Couldn't find renderer while setting up {id}");

                    renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);
                    additionalModifyPrefab.Invoke(go);
                }
            };

            prefab.SetGameObject(clone);
            return prefab;
        }


        public static CustomPrefab CreateResource(string id, string name, string description, TechType resourceToCopy, TechCategory pdaCategory)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(id + "Sprite"))
                .WithPDACategory(TechGroup.Resources, pdaCategory)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if (!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new Exception($"Couldn't find renderer while setting up {id}");

                    renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(id + "Texture"), true);
                }
            };

            prefab.SetGameObject(clone);
            return prefab;
        }


        public static void CreateAltRecipe(string id, string name, string description, TechType itemToCraft, TechGroup pdaGroup, TechCategory pdaCategory, RecipeData recipe, CraftTree.Type craftTreeType)
        {
            var prefab = PrefabUtils.CreatePrefab(id, name, description, ImageUtils.GetSprite(itemToCraft))
                .WithPDACategory(pdaGroup, pdaCategory)
                .WithRecipe(recipe, craftTreeType)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, itemToCraft);

            prefab.SetGameObject(clone);
            prefab.Register();
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