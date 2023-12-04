

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(StorageContainer))]
    public static class StorageContainerPatch
    {
        [HarmonyPatch(nameof(StorageContainer.Awake)), HarmonyPostfix]
        public static void Awake(StorageContainer __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.container = __instance;
        }
    }
}