

namespace Ramune.StasisModule.Items
{
    public static class StasisModule
    {
        public static CustomPrefab Prefab = Utilities.CreatePrefab("StasisModule", "Stasis module", "Boom, stasis field, pow, kapow, kaboom. Compatible with Seamoth and Exosuit.", Utilities.GetSprite("StasisModule"))
            .WithJsonRecipe("RadiantBlade", CraftTree.Type.Fabricator, CraftTreeHandler.Paths.FabricatorMachines)
            .WithUnlock(TechType.Seamoth);


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.SeamothElectricalDefense);
            Prefab.SetGameObject(clone);
            Prefab.Register();
          //Prefab.SetVehicleUpgradeModule()
          //    .WithOnModuleUsed(Monos.StasisModule.DeployStasis(Player.main.currentMountedVehicle, 1, 1, 1));
        }
    }
}