

namespace Ramune.StasisModule.Items
{
    public static class StasisModule
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("StasisModule", "Stasis module", "Boom, stasis field, pow, kapow, kaboom. Compatible with Seamoth and Exosuit.", Utilities.GetSprite(TechType.StasisRifle))
            .WithJsonRecipe("StasisModule.Recipe", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorMachines)
            .WithUnlock(TechType.StasisRifle);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.SeamothElectricalDefense)
            {
                ModifyPrefab = go =>
                {
                    GameObject.Destroy(go.GetComponent<MapRoomCamera>());
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