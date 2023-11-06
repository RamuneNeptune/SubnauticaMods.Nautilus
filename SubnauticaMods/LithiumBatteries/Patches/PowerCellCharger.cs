

namespace Ramune.LithiumBatteries.Patches
{
    [HarmonyPatch(typeof(PowerCellCharger))]
    internal class PowerCellChargerPatch
    {
        [HarmonyPatch(nameof(PowerCellCharger.Initialize)), HarmonyPostfix]
        public static void Initialize(PowerCellCharger __instance)
        {
            if(!__instance.allowedTech.Contains(Items.LithiumPowerCell.Prefab.Info.TechType))
                __instance.allowedTech.Add(Items.LithiumPowerCell.Prefab.Info.TechType);
        }
    }
}