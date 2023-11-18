

namespace Ramune.Seal.ShrinkModule.Items
{
    public static class ShrinkModule
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SealShrinkModule", "Seal shrink module", "Shrink do be doo ba, do the shrinking move real quick Ernest. Does not stack.", ImageUtils.GetSprite("SealShrinkModule"))
            .WithPDACategory(TechGroup.VehicleUpgrades, TechCategory.VehicleUpgrades)
            .WithJsonRecipe("SealShrinkModule", Plugin.SealFabricatorTree)
            .WithEquipment(Plugin.SealModuleEquipmentType)
            .WithUnlock(SealSubPrefab.SealType);


        public static void Register()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.CyclopsHullModule1);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}