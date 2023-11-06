

namespace Ramune.LithiumBatteries.Patches
{
    [HarmonyPatch(typeof(BatteryCharger))]
    internal class BatteryChargerPatch
    {
        [HarmonyPatch(nameof(BatteryCharger.Initialize)), HarmonyPostfix]
        public static void Initialize(BatteryCharger __instance)
        {
            if(!__instance.allowedTech.Contains(Items.LithiumBattery.Prefab.Info.TechType))
                __instance.allowedTech.Add(Items.LithiumBattery.Prefab.Info.TechType);
        }
    }
}