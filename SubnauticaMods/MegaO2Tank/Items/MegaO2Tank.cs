

namespace Ramune.MegaO2Tank.Items
{
    public static class MegaO2Tank
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("MegaO2Tank", "Mega O₂ Tank", "Additional air capacity.", Utilities.GetSprite("MegaO2Tank.Sprite"))
            .WithJsonRecipe("MegaO2Tank.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorEquipment)
            .WithUnlock(TechType.HighCapacityTank)
            .WithEquipment(EquipmentType.Tank);

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.HighCapacityTank)
            {
                ModifyPrefab = go =>
                {
                    var oxygen = go.EnsureComponent<Oxygen>();
                    oxygen.oxygenCapacity = Ramune.MegaO2Tank.MegaO2Tank.config.oxygenCapacity;
                }
            };

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}