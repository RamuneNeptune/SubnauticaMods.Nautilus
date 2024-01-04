

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(BaseBioReactor))]
    public static class BaseBioReactorPatch
    {
        private static FieldInfo _container = typeof(BaseBioReactor).GetField("_container", BindingFlags.NonPublic | BindingFlags.Instance);
        private static ItemsContainer container;

        [HarmonyPatch(nameof(BaseBioReactor.Start)), HarmonyPostfix]
        public static void Start(BaseBioReactor __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.BioReactor;
        }

        [HarmonyPatch("get_container"), HarmonyPostfix]
        public static void get_container(BaseBioReactor __instance)
        {
            if(container == null)
                container = (ItemsContainer)_container.GetValue(__instance);

            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.container = container;

            // needs testing
        }
    }
}