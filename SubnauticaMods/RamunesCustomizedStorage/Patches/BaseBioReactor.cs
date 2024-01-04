

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(BaseBioReactor))]
    public static class BaseBioReactorPatch
    {
        [HarmonyPatch(nameof(BaseBioReactor.Start)), HarmonyPostfix]
        public static void Start(BaseBioReactor __instance)
        {
            var resizer =__instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.BioReactor;
        }
    }
}