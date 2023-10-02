

namespace Ramune.BZEnameledGlass.Items
{
    public static class EnameledGlassClone
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("EnameledGlassClone", "Enameled glass", "Glass, hardened using a natural substrate.", Utilities.GetSprite(TechType.EnameledGlass))
            .WithRecipe(new RecipeData { craftAmount = 0, Ingredients = new List<Ingredient> { new Ingredient(TechType.Glass, 1), new Ingredient(TechType.Lead, 1), new Ingredient(TechType.Diamond, 1) }, LinkedItems = new List<TechType> { TechType.EnameledGlass } }, CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorsBasicMaterials)
            .WithUnlock(TechType.EnameledGlass);

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.EnameledGlass);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}