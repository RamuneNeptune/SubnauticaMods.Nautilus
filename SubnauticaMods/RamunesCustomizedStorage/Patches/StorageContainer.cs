

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(StorageContainer))]
    public static class StorageContainerPatch
    {
        [HarmonyPatch(nameof(StorageContainer.Awake)), HarmonyPostfix]
        public static void Awake(StorageContainer __instance)
        {
            var resizer = __instance.gameObject.EnsureComponent<Monos.StorageResizer>();
            resizer.type = GetStorageType(__instance);
            resizer.container = __instance;
        }

        public static Monos.StorageType GetStorageType(StorageContainer container)
        {
            return container switch
            {
                { name: var n } when n.ToLower().StartsWith("locker") => Monos.StorageType.StandingLocker,
                { name: var n } when n.ToLower().StartsWith("smalllocker") => Monos.StorageType.WallLocker,
                { name: var n } when n.ToLower().StartsWith("submarine_locker_01_door") => Monos.StorageType.CyclopsLocker,
                _ when container.gameObject.GetComponent<SmallStorage>() is not null => Monos.StorageType.WaterproofLocker,
                _ when container.gameObject.GetComponent<SpawnEscapePodSupplies>() is not null => Monos.StorageType.LifepodLocker,
                _ when container.transform.parent is not null && container.transform.parent.gameObject.name.StartsWith("docking_luggage_01_bag4") => Monos.StorageType.CarryAll,
                _ => Monos.StorageType.Unknown,
            };
        }
    }
}