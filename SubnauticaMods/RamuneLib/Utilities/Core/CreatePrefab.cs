

namespace RamuneLib
{
    public static partial class Utilities
    {
        public static CustomPrefab CreatePrefab(string id, string name, string description, Atlas.Sprite sprite)
        {
            return new CustomPrefab(id, name, description, sprite);
        }


        public static CustomPrefab WithRecipe(this CustomPrefab customPrefab, RecipeData recipe, CraftTree.Type craftTreeType, params string[] stepsToFabricator)
        {
            customPrefab.SetRecipe(recipe)
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator);

            return customPrefab;
        }


        public static CustomPrefab WithRecipe(this CustomPrefab customPrefab, RecipeData recipe, CraftTree.Type craftTreeType)
        {
            customPrefab.SetRecipe(recipe)
                .WithFabricatorType(craftTreeType);

            return customPrefab;
        }


        public static CustomPrefab WithRecipe(this CustomPrefab customPrefab, RecipeData recipe, CraftTree.Type craftTreeType, float craftingTime)
        {
            customPrefab.SetRecipe(recipe)
                .WithFabricatorType(craftTreeType)
                .WithCraftingTime(craftingTime);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, CraftTree.Type craftTreeType, params string[] stepsToFabricator)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recipes", filename + ".json");
            customPrefab.SetRecipeFromJson(path)
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, CraftTree.Type craftTreeType, float craftingTime, params string[] stepsToFabricator)
        {
            customPrefab.SetRecipeFromJson(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recipes", filename + ".json"))
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator)
                .WithCraftingTime(craftingTime);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, float craftingTime)
        {
            customPrefab.SetRecipeFromJson(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recipes", filename + ".json"))
                .WithCraftingTime(craftingTime);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename)
        {
            customPrefab.SetRecipeFromJson(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Recipes", filename + ".json"));
            return customPrefab;
        }


        public static CustomPrefab WithEquipment(this CustomPrefab customPrefab, EquipmentType equipmentType)
        {
            customPrefab.SetEquipment(equipmentType);
            return customPrefab;
        }


        public static CustomPrefab WithUnlock(this CustomPrefab customPrefab, TechType techType)
        {
            customPrefab.SetUnlock(techType);
            return customPrefab;
        }


        public static CustomPrefab WithSize(this CustomPrefab customPrefab, int x, int y)
        {
            customPrefab.Info.WithSizeInInventory(new Vector2int(x, y));
            return customPrefab;
        }


        public static CustomPrefab WithPDACategory(this CustomPrefab customPrefab, TechGroup techGroup, TechCategory techCategory)
        {
            customPrefab.SetPdaGroupCategory(techGroup, techCategory);
            return customPrefab;
        }


        public static CustomPrefab WithPDACategoryAfter(this CustomPrefab customPrefab, TechGroup techGroup, TechCategory techCategory, TechType target)
        {
            customPrefab.SetPdaGroupCategoryAfter(techGroup, techCategory, target);
            return customPrefab;
        }


        public static CustomPrefab WithPDACategoryBefore(this CustomPrefab customPrefab, TechGroup techGroup, TechCategory techCategory, TechType target)
        {
            customPrefab.SetPdaGroupCategoryBefore(techGroup, techCategory, target);
            return customPrefab;
        }


        public static CustomPrefab WithFabricator(this CustomPrefab customPrefab, out CraftTree.Type craftTreeType)
        {
            customPrefab.CreateFabricator(out CraftTree.Type _craftTreeType);
            craftTreeType = _craftTreeType;
            return customPrefab;
        }
    }
}