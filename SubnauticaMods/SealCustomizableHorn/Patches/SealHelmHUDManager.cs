

namespace Ramune.Seal.CustomizableHorn.Patches
{
    [HarmonyPatch(typeof(SealHelmHUDManager))]
    public static class SealHelmHUDManagerPatch
    {
        [HarmonyPatch(nameof(SealHelmHUDManager.Start)), HarmonyPostfix]
        public static void Start(SealHelmHUDManager __instance)
        {
            __instance.gameObject.EnsureComponent<Monos.CustomHornManager>();
        }

        [HarmonyPatch(nameof(SealHelmHUDManager.StartPiloting)), HarmonyPostfix]
        public static void StartPiloting(SealHelmHUDManager __instance)
        {
            __instance.gameObject.GetComponent<Monos.CustomHornManager>().enabled = true;
        }

        [HarmonyPatch(nameof(SealHelmHUDManager.StopPiloting)), HarmonyPostfix]
        public static void StopPiloting(SealHelmHUDManager __instance)
        {
            __instance.gameObject.GetComponent<Monos.CustomHornManager>().enabled = false;
        }
    }
}