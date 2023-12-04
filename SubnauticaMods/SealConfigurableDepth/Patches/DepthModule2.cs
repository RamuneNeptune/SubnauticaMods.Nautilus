

namespace Ramune.Seal.ConfigurableDepth.Patches
{
    [HarmonyPatch(typeof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule2))]
    public static class DepthModule2Patch
    {
        [HarmonyPatch(nameof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule2.Depth), MethodType.Getter), HarmonyPrefix]
        public static bool Depth(ref float __result)
        {
            __result = SealConfigurableDepth.config.DepthMk2;
            return false;
        }
    }
}