

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            [HarmonyPatch(typeof(BatteryCharger), nameof(BatteryCharger.Initialize)), HarmonyPostfix]
            public static bool BatteryCharger_Initialize(Charger __instance, ref bool __result)
            {
                __instance.chargeSpeed = 0.0025f;
                return __result;
            }

            [HarmonyPatch(typeof(PowerCellCharger), nameof(PowerCellCharger.Initialize)), HarmonyPostfix]
            public static bool PowerCellCharger_Initialize(Charger __instance, ref bool __result)
            {
                __instance.chargeSpeed = 0.0025f;
                return __result;
            }
        }
    }
}