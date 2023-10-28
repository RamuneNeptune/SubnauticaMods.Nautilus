

namespace RamuneLib
{
    public static class CustomPrefabExtensions
    {
        // Setting prefab recipe ------------------------------------------------------------------------------------------------------------------------------------------

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


        public static CustomPrefab WithRecipe(this CustomPrefab customPrefab, RecipeData recipe, CraftTree.Type craftTreeType, params string[] stepsToFabricator)
        {
            customPrefab.SetRecipe(recipe)
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, CraftTree.Type craftTreeType, float craftingTime, params string[] stepsToFabricator)
        {
            customPrefab.SetRecipeFromJson(JsonUtils.GetJsonRecipe(filename))
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator)
                .WithCraftingTime(craftingTime);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, CraftTree.Type craftTreeType, params string[] stepsToFabricator)
        {
            customPrefab.SetRecipeFromJson(JsonUtils.GetJsonRecipe(filename))
                .WithFabricatorType(craftTreeType)
                .WithStepsToFabricatorTab(stepsToFabricator);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename, float craftingTime)
        {
            customPrefab.SetRecipeFromJson(JsonUtils.GetJsonRecipe(filename))
                .WithCraftingTime(craftingTime);

            return customPrefab;
        }


        public static CustomPrefab WithJsonRecipe(this CustomPrefab customPrefab, string filename)
        {
            customPrefab.SetRecipeFromJson(JsonUtils.GetJsonRecipe(filename));
            return customPrefab;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        // Setting prefab EquipmentType -----------------------------------------------------------------------------------------------------------------------------------

        public static CustomPrefab WithEquipment(this CustomPrefab customPrefab, EquipmentType equipmentType)
        {
            customPrefab.SetEquipment(equipmentType);
            return customPrefab;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        // Setting prefab unlock TechType ---------------------------------------------------------------------------------------------------------------------------------

        public static CustomPrefab WithUnlock(this CustomPrefab customPrefab, TechType techType)
        {
            customPrefab.SetUnlock(techType);
            return customPrefab;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        // Setting prefab size in inventory -------------------------------------------------------------------------------------------------------------------------------

        public static CustomPrefab WithSize(this CustomPrefab customPrefab, int x, int y)
        {
            customPrefab.Info.WithSizeInInventory(new Vector2int(x, y));
            return customPrefab;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        // Setting prefab PDA category ------------------------------------------------------------------------------------------------------------------------------------

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

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        // Turning prefab into a crafter (e.g. fabricator, workbench, etc..) ----------------------------------------------------------------------------------------------

        public static CustomPrefab WithFabricator(this CustomPrefab customPrefab, out CraftTree.Type craftTreeType)
        {
            customPrefab.CreateFabricator(out CraftTree.Type _craftTreeType);
            craftTreeType = _craftTreeType;
            return customPrefab;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}