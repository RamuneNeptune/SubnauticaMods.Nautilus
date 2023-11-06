

namespace Ramune.LithiumBatteries.Patches
{
    [HarmonyPatch(typeof(EnergyMixin))]
    internal class EnergyMixinPatches
    {
        [HarmonyPatch(nameof(EnergyMixin.Start)), HarmonyPostfix]
        public static void Start(EnergyMixin __instance)
        {
            if(__instance.compatibleBatteries.Contains(TechType.Battery))
               __instance.compatibleBatteries.Add(Items.LithiumBattery.Prefab.Info.TechType);
        
            if(__instance.compatibleBatteries.Contains(TechType.PowerCell))
               __instance.compatibleBatteries.Add(Items.LithiumPowerCell.Prefab.Info.TechType);
        }


        [HarmonyPatch(typeof(EnergyMixin), nameof(EnergyMixin.NotifyHasBattery)), HarmonyPostfix]
        public static void NotifyHasBattery(ref EnergyMixin __instance, InventoryItem item)
        {
            List<TechType> LithiumPowercell = new() { Items.LithiumPowerCell.Prefab.Info.TechType };

            if(LithiumPowercell.Count == 0) return;

            TechType? itemInSlot = item?.item?.GetTechType();

            if(!itemInSlot.HasValue || itemInSlot.Value == TechType.None)
                return;

            TechType powerCellTechType = itemInSlot.Value;

            bool isKnownModdedPowerCell = LithiumPowercell.Find(techType => techType == powerCellTechType) != TechType.None;

            if(isKnownModdedPowerCell)
            {
                int modelToDisplay = 0; // If a matching model cannot be found, the standard PowerCell model will be used instead.
                for(int b = 0; b < __instance.batteryModels.Length; b++)
                {
                    if(__instance.batteryModels[b].techType == powerCellTechType)
                    {
                        modelToDisplay = b;
                        break;
                    }
                }
                __instance.batteryModels[modelToDisplay].model.SetActive(true);
            }
        }
    }
}