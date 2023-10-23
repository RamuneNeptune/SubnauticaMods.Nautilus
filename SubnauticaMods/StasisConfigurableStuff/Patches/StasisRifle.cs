

namespace Ramune.StasisConfigurableStuff.Patches
{
    [HarmonyPatch(typeof(StasisRifle))]
    public static class StasisRiflePatch
    {
        [HarmonyPatch(nameof(StasisRifle.Charge)), HarmonyPostfix]
        public static void Charge(StasisRifle __instance)
        {
            __instance.chargeDuration = 3f * StasisConfigurableStuff.config.chargeDuration;
            __instance.energyCost = 5f * StasisConfigurableStuff.config.energyCost;
        }
    }
}