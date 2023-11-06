

namespace Ramune.Seal.HandlingTweaker.Patches
{
    [HarmonyPatch(typeof(SealSubRoot))]
    public static class SealSubRootPatch
    {
        public static List<SealSubRoot> seals = new();


        [HarmonyPatch(nameof(SealSubRoot.OnEnable)), HarmonyPostfix]
        public static void OnEnable(SealSubRoot __instance) => seals.Add(__instance);


        [HarmonyPatch(nameof(SealSubRoot.OnDisable)), HarmonyPostfix]
        public static void OnDisable(SealSubRoot __instance) => seals.Remove(__instance);
    }
}