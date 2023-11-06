

namespace Ramune.Seal.AlwaysActiveHUD.Patches
{
    [HarmonyPatch(typeof(SealHelmHUDManager))]
    public static class SealHelmHUDManagerPatch
    {
        [HarmonyPatch(nameof(SealHelmHUDManager.Start)), HarmonyPostfix]
        public static void Start(SealHelmHUDManager __instance)
        {
            __instance.hudActive = true;
        }

        [HarmonyPatch(nameof(SealHelmHUDManager.StopPiloting)), HarmonyPostfix]
        public static void StopPiloting(SealHelmHUDManager __instance)
        {
            __instance.hudActive = true;
        }
    }
}