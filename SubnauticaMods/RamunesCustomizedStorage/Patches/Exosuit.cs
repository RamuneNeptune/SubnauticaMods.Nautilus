

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    public static class ExosuitPatch
    {
        [HarmonyPatch(nameof(Exosuit.UpdateStorageSize)), HarmonyPostfix]
        public static void UpdateStorageSize(Exosuit __instance)
        {
            int height = (int)RamunesCustomizedStorage.config.height_prawnSuit + ((int)RamunesCustomizedStorage.config.height_prawnSuitModule * __instance.modules.GetCount(TechType.VehicleStorageModule));
            __instance.storageContainer.Resize((int)RamunesCustomizedStorage.config.width_prawnSuit, height);
        }
    }
}