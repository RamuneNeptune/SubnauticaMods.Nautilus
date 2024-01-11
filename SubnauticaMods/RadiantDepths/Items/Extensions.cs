

namespace Ramune.RadiantDepths.Items
{
    public static class Extensions
    {
        /// <summary>
        /// Converts this dictionary of <c>BiomeType:float</c> to an array of <see cref="LootDistributionData.BiomeData[]"/>
        /// </summary>
        /// <param name="biomeDatas"></param>
        public static LootDistributionData.BiomeData[] AsBiomeData(this Dictionary<BiomeType, float> biomeDatas)
        {
            List<LootDistributionData.BiomeData> biomeData = new();

            foreach (var pair in biomeDatas)
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


        /// <summary>
        /// Runs all the bits to turn your <see cref="CustomPrefab"/> into an outcrop (like setting up the <see cref="CustomOutcrop"/> component) then returns the <see cref="CustomPrefab"/> ready to be registered
        /// </summary>
        /// <param name="id">The item's ID used for fetching the textures</param>
        /// <param name="outcropToCopy">The TechType of the outcrop this should clone</param>
        /// <param name="dropAmount">Amount of items this outcropw will drop when broken</param>
        /// <param name="biomeData">Biome data to determine where this outcrop will spawn</param>
        /// <param name="drops">A dictionary</param>
        public static CustomPrefab WithOutcrop(this CustomPrefab prefab, string id, TechType outcropToCopy, int dropAmount, LootDistributionData.BiomeData[] biomeData, Dictionary<TechType, float> drops)
        {
            prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.BasicMaterials);

            var clone = new CloneTemplate(prefab.Info, outcropToCopy)
            {
                ModifyPrefab = go =>
                {
                    var guid = Guid.NewGuid().ToString();
                    var outcrop = go.EnsureComponent<CustomOutcrop>();
                    outcrop.DropAmount = dropAmount;
                    outcrop.GUID = guid;

                    ItemUtils.OutcropPatcher.Add(guid, drops);

                    if(go.TryGetComponent<BreakableResource>(out var breakable))
                        breakable.breakText = "Break " + prefab.DisplayName().ToLower();

                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(prefab.Id() + "Texture"));
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(biomeData);
            return prefab;
        }


        /// <summary>
        /// Runs all the bits to turn your <see cref="CustomPrefab"/> into a resource then returns the <see cref="CustomPrefab"/> ready to be registered
        /// </summary>
        /// <param name="id">The item's ID used for fetching the textures</param>
        /// <param name="resourceToCopy">The TechType of the resource this should clone</param>
        /// <param name="biomeData">Biome data to determine where this resource will spawn (optional)</param>
        public static CustomPrefab WithResource(this CustomPrefab prefab, TechType resourceToCopy, TechCategory pdaTechCategory, LootDistributionData.BiomeData[] biomeData = null)
        {
            prefab.SetPdaGroupCategory(TechGroup.Resources, pdaTechCategory);

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(prefab.Id() + "Texture"));
                }
            };

            prefab.SetGameObject(clone);

            if(biomeData != null) 
                prefab.SetSpawns(biomeData);
            
            return prefab;
        }


        /// <summary>
        /// Runs all the bits to turn your <see cref="CustomPrefab"/> into a resource then returns the <see cref="CustomPrefab"/> ready to be registered
        /// </summary>
        /// <param name="id">The item's ID used for fetching the textures</param>
        /// <param name="resourceToCopy">The TechType of the resource this should clone</param>
        /// <param name="spawns">Spawn locations for this resource (optional)</param>
        public static CustomPrefab WithResource(this CustomPrefab prefab, TechType resourceToCopy, TechCategory pdaTechCategory, SpawnLocation[] spawns)
        {
            prefab.SetPdaGroupCategory(TechGroup.Resources, pdaTechCategory);

            var clone = new CloneTemplate(prefab.Info, resourceToCopy)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        throw new MissingComponentException($"Couldn't find renderer while setting up {prefab.Id()}");

                    renderer
                        .SetTexture(TextureType.Main, ImageUtils.GetTexture(prefab.Id() + "Texture"))
                        .SetTexture(TextureType.Specular, ImageUtils.GetTexture(prefab.Id() + "Texture"));
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetSpawns(spawns);
            return prefab;
        }


        /*
        public static void CreateAltRecipe(TechType itemToCopy, RecipeData recipe, CraftTree.Type craftTreeType, string[] stepsToTab, TechType techTypeToUnlock = TechType.None)
        {
            var prefab = PrefabUtils.CreatePrefab("Alt" + itemToCopy.AsString(), Language.main.Get(itemToCopy), Language.main.Get($"Tooltip_{itemToCopy.AsString()}"), ImageUtils.GetSprite(itemToCopy))
                .WithRecipe(recipe, craftTreeType, stepsToTab);

            if(techTypeToUnlock != TechType.None) prefab.SetUnlock(techTypeToUnlock);
            else prefab.WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, itemToCopy);

            prefab.SetGameObject(clone);
            prefab.Register();
        }


        public static void CreateAltRecipe(TechType itemToCopy, RecipeData recipe, CraftTree.Type craftTreeType, TechGroup pdaGroup, TechCategory pdaCategory, string[] stepsToTab, TechType techTypeToUnlock = TechType.None)
        {
            var prefab = PrefabUtils.CreatePrefab("Alt" + itemToCopy.AsString(), Language.main.Get(itemToCopy), Language.main.Get($"Tooltip_{itemToCopy.AsString()}"), ImageUtils.GetSprite(itemToCopy))
                .WithRecipe(recipe, craftTreeType, stepsToTab)
                .WithPDACategory(pdaGroup, pdaCategory);

            if(techTypeToUnlock != TechType.None) prefab.SetUnlock(techTypeToUnlock);
            else prefab.WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, itemToCopy);

            prefab.SetGameObject(clone);
            prefab.Register();
        }
        */
    }
}