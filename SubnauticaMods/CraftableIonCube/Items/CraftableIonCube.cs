

namespace Ramune.CraftableIonCube.Items
{
    public static class CraftableIonCube
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("CraftableIonCube", "Ion cube", "High capacity energy source.", ImageUtils.GetSprite(TechType.PrecursorIonCrystal))
            .WithJsonRecipe("CraftableIonCube", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorsAdvancedMaterials);

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PrecursorIonCrystal);
            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}