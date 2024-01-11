

namespace Ramune.RadiantDepths.Items
{
    public static class ItemUtils
    {
        public static Dictionary<string, Dictionary<TechType, float>> OutcropPatcher = new();


        public static void CreateAltRecipe(string name, TechType itemToClone, TechCategory pdaCategory, RecipeData recipe, CraftTree.Type craftTreeType, params string[] stepsToTab)
        {
            var prefab = PrefabUtils.CreatePrefab("Alt" + itemToClone.AsString(), Language.main.Get(TechType.CrashPowder) + name, Language.main.Get($"Tooltip_{itemToClone.AsString()}"), ImageUtils.GetSprite(itemToClone))
                .WithPDACategory(TechGroup.Resources, pdaCategory)
                .WithRecipe(recipe, craftTreeType, stepsToTab)
                .WithAutoUnlock();

            var clone = new CloneTemplate(prefab.Info, itemToClone);

            prefab.SetGameObject(clone);
            prefab.Register();
        }
    }
}