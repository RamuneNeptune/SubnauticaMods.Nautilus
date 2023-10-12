

namespace Ramune.OxygenCanisters.Items
{
    public static class LargeOxygenCaniser
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("LargeOxygenCanister", "Large oxygen canister", "O2: +70\nEncapsulated oxygen from the Bladderfish.", Utilities.GetSprite("LargeOxygenCanister.Sprite"))
            .WithJsonRecipe("LargeOxygenCanister.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorEquipment)
            .WithPDACategory(TechGroup.Personal, TechCategory.Equipment)
            .WithUnlock(TechType.None);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.FiberMesh)
            {
                ModifyPrefab = go => SurvivalHandler.GiveOxygenOnConsume(Prefab.Info.TechType, 70f, true)
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}