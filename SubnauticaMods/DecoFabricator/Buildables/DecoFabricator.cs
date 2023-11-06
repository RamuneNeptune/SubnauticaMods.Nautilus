

namespace Ramune.DecoFabricator.Buildables
{
    public static class DecoFabricator
    {
        public static CraftTree.Type craftTreeType;
        public static Texture2D TextureMain = ImageUtils.GetTexture("DecoFabricatorTexture");

        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("DecoFabricator", "Decorations fabricator", "Used to fabricate posters, toys, caps, and more", ImageUtils.GetSprite("DecoFabricator"))
            .WithPDACategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator)
            .WithJsonRecipe("DecoFabricator")
            .WithFabricator(out craftTreeType);


        public static void Patch()
        {
            var model = new FabricatorTemplate(Prefab.Info, craftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.Fabricator,
                ModifyPrefab = go => go.GetComponentInChildren<SkinnedMeshRenderer>().material.SetTexture(ShaderPropertyID._MainTex, TextureMain)
            };

            Prefab.SetGameObject(model);
            Prefab.Register();


            Dictionary<TechType[], string> TechMap = new()
            {
                { new TechType[] { TechType.PosterKitty, TechType.Poster, TechType.PosterExoSuit1, TechType.PosterExoSuit2, TechType.PosterAurora }, "Posters" },
                { new TechType[] { TechType.LabEquipment3, TechType.LabEquipment2, TechType.LabEquipment1, TechType.LabContainer, TechType.LabContainer2, TechType.LabContainer3 }, "Science" },
                { new TechType[] { TechType.ArcadeGorgetoy, TechType.ToyCar, TechType.StarshipSouvenir, TechType.Cap2, TechType.Cap1 }, "Misc" },
            };


            CraftTreeHandler.AddTabNode(craftTreeType, TechMap.Values.ElementAt(0), TechMap.Values.ElementAt(0), SpriteManager.Get(TechType.PosterKitty));
            CraftTreeHandler.AddTabNode(craftTreeType, TechMap.Values.ElementAt(1), TechMap.Values.ElementAt(1), SpriteManager.Get(TechType.LabEquipment3));
            CraftTreeHandler.AddTabNode(craftTreeType, TechMap.Values.ElementAt(2), TechMap.Values.ElementAt(2), SpriteManager.Get(TechType.ArcadeGorgetoy));


            var recipe = PrefabUtils.CreateRecipe(1, new Ingredient(TechType.Titanium, 1));


            foreach(var techCategory in TechMap)
            {
                var categoryName = techCategory.Value;
                var categoryTech = techCategory.Key;

                foreach(TechType techType in categoryTech)
                {
                    KnownTechHandler.UnlockOnStart(techType);
                    CraftDataHandler.SetRecipeData(techType, recipe);
                    CraftTreeHandler.AddCraftingNode(craftTreeType, techType, categoryName);
                }
            }
        }
    }
}