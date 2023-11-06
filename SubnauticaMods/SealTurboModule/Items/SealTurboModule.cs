

namespace Ramune.Seal.TurboModule.Items
{
    public static class SealTurboModule
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("SealTurboModule", "Seal turbo module", "On activation, increases engine power substantially for a short time, providing extra thrust for increased speed. Excess heat generated increases power usage. Does not stack.", ImageUtils.GetSprite("SealTurboModule"))
            .WithPDACategory(TechGroup.VehicleUpgrades, TechCategory.VehicleUpgrades)
            .WithJsonRecipe("SealTurboModule", Plugin.SealFabricatorTree)
            .WithEquipment(Plugin.SealModuleEquipmentType)
            .WithUnlock(SealSubPrefab.SealType);


        public static void Register()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.CyclopsFireSuppressionModule);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}