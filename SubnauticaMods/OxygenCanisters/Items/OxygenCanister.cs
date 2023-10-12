

namespace Ramune.OxygenCanisters.Items
{
    public static class OxygenCanister
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("OxygenCanister", "Oxygen canister", "O2: +35\nEncapsulated oxygen from the Bladderfish.", Utilities.GetSprite("OxygenCanister.Sprite"))
            .WithJsonRecipe("OxygenCanister.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorEquipment)
            .WithPDACategory(TechGroup.Personal, TechCategory.Equipment)
            .WithUnlock(TechType.None);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.FiberMesh)
            {
                ModifyPrefab = go => SurvivalHandler.GiveOxygenOnConsume(Prefab.Info.TechType, 35f, true)
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}