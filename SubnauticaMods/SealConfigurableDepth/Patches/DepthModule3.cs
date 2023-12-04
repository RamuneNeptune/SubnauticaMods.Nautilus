

namespace Ramune.Seal.ConfigurableDepth.Patches
{
    [HarmonyPatch(typeof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule3))]
    public static class DepthModule3Patch
    {
        [HarmonyPatch(nameof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule3.Depth), MethodType.Getter), HarmonyPrefix]
        public static bool Depth(ref float __result)
        {
            __result = SealConfigurableDepth.config.DepthMk3;
            return false;
        }
    }
}