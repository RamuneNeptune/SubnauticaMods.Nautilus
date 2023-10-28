

namespace Ramune.StasisModule.Items
{
    public static class StasisModule
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("StasisModule", "Stasis module", "Boom, stasis field, pow, kapow, kaboom. Compatible with Seamoth and Exosuit.", ImageUtils.GetSprite(TechType.StasisRifle))
            .WithJsonRecipe("StasisModule")
            .WithUnlock(TechType.StasisRifle);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.SeamothElectricalDefense)
            {
                ModifyPrefab = go =>
                {

                }
            };

            Prefab.SetGameObject(clone);

            Prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Selectable)
                .WithCooldown(1f)
                .WithEnergyCost(1f)
                .WithOnModuleUsed((Vehicle vehicle, int slotID, float charge, float chargeScalar) => DeployStasis(vehicle));

            Prefab.Register();
        }


        public static void DeployStasis(Vehicle vehicle)
        {
            StasisRifle.sphere.Shoot(vehicle.gameObject.transform.position, vehicle.gameObject.transform.rotation, 1f, 3f * Ramune.StasisModule.StasisModule.config.duration, 10f);
            StasisRifle.sphere.EnableField();
            StasisRifle.sphere.radius = 10f * Ramune.StasisModule.StasisModule.config.radius;
        }
    }
}