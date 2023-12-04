

namespace Ramune.RamunesCustomizedStorage.Monos
{
    public class StorageResizer : MonoBehaviour
    {
        public static List<StorageContainer> WaterproofLockers = new();
        public static List<StorageContainer> WallLockers = new();
        public static List<StorageContainer> StandingLockers = new();
        public static List<StorageContainer> CarryAlls = new();
        public static List<StorageContainer> CyclopsLockers = new();

        public StorageContainer container;


        public void Start()
        {
            var config = RamunesCustomizedStorage.config;

            if(IsLifepodLocker())
                container.Resize((int)config.width_locker, (int)config.height_locker);

            else if(IsWaterproofLocker())
                container.Resize((int)config.width_locker, (int)config.height_locker);

            else if(IsCarryAll())
                container.Resize((int)config.width_carryAll, (int)config.height_carryAll);

            else if (IsStorage("Locker"))
                container.Resize((int)config.width_locker, (int)config.height_locker);

            else if(IsStorage("SmallLocker"))
                container.Resize((int)config.width_wallLocker, (int)config.height_wallLocker);

            else if(IsStorage("submarine_locker_01_door"))
                container.Resize((int)config.width_cyclops, (int)config.height_cyclops);
        }


        public bool IsStorage(string name) => container.name.StartsWith(name);


        public bool IsCarryAll() => container.transform.parent is not null && container.transform.parent.gameObject.name.StartsWith("docking_luggage_01_bag4");


        public bool IsLifepodLocker() => container.gameObject.GetComponent<SpawnEscapePodSupplies>() is not null;


        public bool IsWaterproofLocker() => container.gameObject.GetComponent<SmallStorage>() is not null;
    }
}