

namespace Ramune.MegaO2Tank.Items
{
    public static class MegaO2Tank
    {
        public static CustomPrefab Prefab = CustomPrefabExtensions.CreatePrefab("MegaO2Tank", "Mega O₂ Tank", "Additional air capacity.", ImageUtils.GetSprite("MegaO2Tank"))
            .WithUnlock(TechType.HighCapacityTank)
            .WithEquipment(EquipmentType.Tank)
            .WithJsonRecipe("MegaO2Tank");


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