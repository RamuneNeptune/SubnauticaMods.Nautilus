

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(Inventory))]
    public static class InventoryPatch
    {
        [HarmonyPatch(nameof(Inventory.Awake)), HarmonyPostfix]
        public static void Awake(Inventory __instance) => __instance.container.Resize((int)RamunesCustomizedStorage.config.width_inventory, (int)RamunesCustomizedStorage.config.height_inventory);
    }
}