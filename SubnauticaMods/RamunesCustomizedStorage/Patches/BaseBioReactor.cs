

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(BaseBioReactor))]
    public static class BaseBioReactorPatch
    {
        [HarmonyPatch("get_container"), HarmonyPostfix]
        public static void Awake(BaseBioReactor __instance, ref ItemsContainer __result) => __result.Resize((int)RamunesCustomizedStorage.config.width_bioReactor, (int)RamunesCustomizedStorage.config.height_bioReactor);
    }
}