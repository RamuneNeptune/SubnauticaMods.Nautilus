

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    public static class ExosuitPatches
    {
        [HarmonyPatch(nameof(Exosuit.Start)), HarmonyPostfix]
        public static void Start(Exosuit __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.Exosuit;
            resizer.container = __instance.storageContainer;
        }

        [HarmonyPatch(nameof(Exosuit.UpdateStorageSize)), HarmonyPostfix]
        public static void UpdateStorageSize(Exosuit __instance)
        {
            var resizer = __instance.gameObject.GetComponent<Monos.StorageResizer>();

            if(resizer == null)
                return;

            // logic to account for modules..
        }
    }
}