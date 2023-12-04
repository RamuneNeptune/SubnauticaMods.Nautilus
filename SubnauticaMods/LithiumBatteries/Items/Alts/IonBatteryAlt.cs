

namespace Ramune.LithiumBatteries.Items
{
    public static class IonBatteryAlt
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("IonBatteryAlt", "Ion battery", "Battery infused with alien ion technology.", ImageUtils.GetSprite(TechType.PrecursorIonBattery))
            .WithEquipment(EquipmentType.BatteryCharger)
            .WithUnlock(TechType.PrecursorIonBattery)
            .WithJsonRecipe("IonBatteryAlt");

        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PrecursorIonBattery);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}