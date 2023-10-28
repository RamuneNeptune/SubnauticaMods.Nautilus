

namespace RamuneLib
{
    public static class PrefabUtils
    {
        public static CustomPrefab CreatePrefab(string id, string name, string description, Atlas.Sprite sprite)
        {
            return new CustomPrefab(id, name, description, sprite);
        }


        public static CustomPrefab CreatePrefab(string id, string name, string description, UnityEngine.Sprite sprite)
        {
            return new CustomPrefab(id, name, description, sprite);
        }


        public static RecipeData CreateRecipe(int craftAmount, params Ingredient[] ingredients)
        {
            return new RecipeData()
            {
                craftAmount = craftAmount,
                Ingredients = new(ingredients)
            };
        }
    }
}