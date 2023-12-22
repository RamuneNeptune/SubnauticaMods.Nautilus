

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            [HarmonyPatch(typeof(Charger), nameof(Charger.Start)), HarmonyPostfix]
            public static void Charger_Start(Charger __instance) => __instance.chargeSpeed = 0.0025f;
        }
    }
}