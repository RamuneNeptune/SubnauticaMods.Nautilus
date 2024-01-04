

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(Inventory))]
    public static class InventoryPatch
    {
        [HarmonyPatch(nameof(Inventory.Awake)), HarmonyPostfix]
        public static void Awake(Inventory __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = Monos.StorageType.Inventory;
            resizer.container = __instance.container;
        }
    }
}