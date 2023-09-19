

namespace RamuneLib
{
    public static partial class Utilities
    {
        public static RecipeData CreateRecipe(int craftAmount, params Ingredient[] ingredients)
        {
            RecipeData recipe = new()
            {
                craftAmount = craftAmount,
                Ingredients = new List<Ingredient>(ingredients)
            };

            return recipe;
        }
    }
}
