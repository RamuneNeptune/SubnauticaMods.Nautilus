﻿

namespace Ramune.BuildableBrainCoral.Items
{
    public static class BuildableBrainCoral
    {
        public static CustomPrefab Prefab = PrefabUtils.CreatePrefab("BuildableBrainCoral", "Brain coral", "Colony of microscopic organisms which filter carbon dioxide from the environment, using the carbon to build the colony, and expelling oxygen from specialized exhaust funnels.", ImageUtils.GetSprite(TechType.BrainCoral))
            .WithPDACategory(TechGroup.ExteriorModules, TechCategory.ExteriorOther)
            .WithJsonRecipe("BuildableBrainCoral")
            .WithAutoUnlock();


        public static void Patch()
        {
            var clone = new CloneTemplate(Prefab.Info, TechType.PurpleBrainCoral)
            {
                ModifyPrefab = go =>
                {
                    var model = go.transform.Find("Coral_reef_purple_brain_coral_01").gameObject;
                    model.transform.rotation = Quaternion.Euler(180, 0, 0);

                    Nautilus.Utility.ConstructableFlags constructableFlags = Nautilus.Utility.ConstructableFlags.Outside | Nautilus.Utility.ConstructableFlags.Ground | Nautilus.Utility.ConstructableFlags.Rotatable;
                    Nautilus.Utility.PrefabUtils.AddConstructable(go, Prefab.Info.TechType, constructableFlags, model);
                }
            };

            CraftDataHandler.SetBackgroundType(Prefab.Info.TechType, BackgroundType.PlantWater);

            Prefab.SetGameObject(clone);
            Prefab.Register();
        }
    }
}