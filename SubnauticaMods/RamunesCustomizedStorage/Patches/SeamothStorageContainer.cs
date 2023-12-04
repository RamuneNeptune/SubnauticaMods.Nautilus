

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(SeamothStorageContainer))]
    public static class SeamothStorageContainerPatch
    {
        [HarmonyPatch(nameof(SeamothStorageContainer.Init)), HarmonyPrefix]
        public static void Init(SeamothStorageContainer __instance)
        {
            __instance.width = (int)RamunesCustomizedStorage.config.width_seamoth;
            __instance.height = (int)RamunesCustomizedStorage.config.height_seamoth;
        }
    }
}