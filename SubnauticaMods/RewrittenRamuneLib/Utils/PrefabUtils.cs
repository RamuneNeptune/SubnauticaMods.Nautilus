

namespace RamuneLib
{
    public static class PrefabUtils
    {
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