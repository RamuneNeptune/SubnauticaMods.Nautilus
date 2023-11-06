

namespace Ramune.LithiumBatteries.Items
{
    public static class IonPowerCellAlt
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("IonPowerCellAlt", "Ion power cell", "Power cell infused with alien ion technology.", ImageUtils.GetSprite(TechType.PrecursorIonPowerCell))
            .WithEquipment(EquipmentType.PowerCellCharger)
            .WithJsonRecipe("IonPowerCellAlt");
        //.WithPDACategory();


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PrecursorIonPowerCell);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}