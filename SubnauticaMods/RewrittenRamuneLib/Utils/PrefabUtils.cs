

namespace RamuneLib
{
    public static class PrefabUtils
    {
        /// <summary>
        /// Creates a custom prefab with the specified ID, name, description, and <see cref="Atlas.Sprite"/>.
        /// </summary>
        /// <param name="id">The unique identifier for the prefab.</param>
        /// <param name="name">The name of the prefab.</param>
        /// <param name="description">The description of the prefab.</param>
        /// <param name="sprite">The <see cref="Atlas.Sprite"/> to associate with the prefab.</param>
        /// <returns>The created custom prefab.</returns>
        public static CustomPrefab CreatePrefab(string id, string name, string description, Atlas.Sprite sprite)
        {
            return new CustomPrefab(id, name, description, sprite);
        }


        /// <summary>
        /// Creates a custom prefab with the specified ID, name, description, and <see cref="UnityEngine.Sprite"/>.
        /// </summary>
        /// <param name="id">The unique identifier for the prefab.</param>
        /// <param name="name">The name of the prefab.</param>
        /// <param name="description">The description of the prefab.</param>
        /// <param name="sprite">The <see cref="UnityEngine.Sprite"/> to associate with the prefab.</param>
        /// <returns>The created custom prefab.</returns>
        public static CustomPrefab CreatePrefab(string id, string name, string description, UnityEngine.Sprite sprite)
        {
            return new CustomPrefab(id, name, description, sprite);
        }


        /// <summary>
        /// Creates a <see cref="RecipeData="/> with the specified crafting amount and ingredients.
        /// </summary>
        /// <param name="craftAmount">The amount of your item that the recipe will provide.</param>
        /// <param name="ingredients">The array of ingredients required for crafting.</param>
        /// <returns>The created <see cref="RecipeData="/>.</returns>
        public static RecipeData CreateRecipe(int craftAmount, params Ingredient[] ingredients)
        {
            return new RecipeData()
            {
                craftAmount = craftAmount,
                Ingredients = new List<Ingredient>(ingredients)
            };
        }


        /// <summary>
        /// Creates a <see cref="RecipeData="/> with the specified crafting amount, ingredients, and linked items.
        /// </summary>
        /// <param name="craftAmount">The amount of your item that the recipe will provide.</param>
        /// <param name="recipeItems">An array of recipe items, list your ingredients first, then list TechTypes for the linked items.</param>
        /// <returns>The created <see cref="RecipeData="/>.</returns>
        public static RecipeData CreateRecipe(int craftAmount, params object[] recipeItems)
        {
            var ingredients = recipeItems.OfType<Ingredient>().ToArray();
            var linkedItems = recipeItems.OfType<TechType>().ToArray();

            return new RecipeData()
            {
                craftAmount = craftAmount,
                Ingredients = new List<Ingredient>(ingredients),
                LinkedItems = new List<TechType>(linkedItems)
            };
        }
    }
}