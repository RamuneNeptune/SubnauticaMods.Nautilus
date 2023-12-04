

namespace Ramune.Seal.ConfigurableDepth.Patches
{
    [HarmonyPatch(typeof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule1))]
    public static class DepthModule1Patch
    {
        [HarmonyPatch(nameof(SealSubMod.MonoBehaviours.UpgradeModules.DepthModule1.Depth), MethodType.Getter), HarmonyPrefix]
        public static bool Depth(ref float __result)
        {
            __result = SealConfigurableDepth.config.DepthMk1;
            return false;
        }
    }
}