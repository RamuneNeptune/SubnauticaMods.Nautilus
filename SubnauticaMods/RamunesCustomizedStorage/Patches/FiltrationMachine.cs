

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(FiltrationMachine))]
    public static class FiltrationMachinePatch
    {
        [HarmonyPatch(nameof(FiltrationMachine.Start)), HarmonyPostfix]
        public static void Start(FiltrationMachine __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.WaterFiltration;
            resizer.container = __instance.storageContainer;
        }
    }
}