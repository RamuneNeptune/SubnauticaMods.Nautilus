

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(SeamothStorageContainer))]
    public static class SeamothStorageContainerPatch
    {
        [HarmonyPatch(nameof(SeamothStorageContainer.Init)), HarmonyPrefix]
        public static void Init(SeamothStorageContainer __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.Seamoth;
            resizer.container = __instance;
        }

        // add logic to account for storage modules plz self
    }
}