

namespace Ramune.SeamothSprint.Items
{
    public static class SeamothSprintModule
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SeamothSprintModule", "Seamoth sprint module", "Allows for increased acceleration at the cost of energy while in use. Does not stack.", ImageUtils.GetSprite("SeamothSprintModule"))
            .WithJsonRecipe("")
            .WithPDACategory(TechGroup.Workbench, TechCategory.Workbench)
            .WithUnlock(TechType.Accumulator);

        public static void Patch()
        {

        }
    }
}