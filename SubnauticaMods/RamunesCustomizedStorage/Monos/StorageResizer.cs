
global using static Ramune.RamunesCustomizedStorage.RamunesCustomizedStorage;
global using static Ramune.RamunesCustomizedStorage.Monos.StorageTypeConfig;
using static VFXParticlesPool;


namespace Ramune.RamunesCustomizedStorage.Monos
{
    public enum StorageType
    {
        Unknown = 0,
        Inventory,
        Seamoth,
        Exosuit,
        CyclopsLocker,
        WallLocker,
        StandingLocker,
        LifepodLocker,
        WaterproofLocker,
        CarryAll,
        BioReactor,
        WaterFiltration,
    }


    public static class StorageTypeConfig
    {
        public static Dictionary<StorageResizer, StorageType> StorageResizers = new();

        public static Dictionary<StorageType, Func<float2>> Values = new()
        {
            { StorageType.Inventory, () => new(config.width_inventory, config.height_inventory) },
            { StorageType.Seamoth, () => new(config.width_seamoth, config.height_seamoth) },
            { StorageType.Exosuit, () => new(config.width_prawnSuit, config.height_prawnSuit) },
            { StorageType.CyclopsLocker, () => new(config.width_cyclops, config.height_cyclops) },
            { StorageType.WallLocker, () => new(config.width_wallLocker, config.height_wallLocker) },
            { StorageType.StandingLocker, () => new(config.width_locker, config.height_locker) },
            { StorageType.LifepodLocker, () => new(config.width_lifepod, config.height_lifepod) },
            { StorageType.WaterproofLocker, () => new(config.width_waterproofLocker, config.height_waterproofLocker) },
            { StorageType.CarryAll, () => new(config.width_carryAll, config.height_carryAll) },
            { StorageType.BioReactor, () => new(config.width_bioReactor, config.height_bioReactor) },
            { StorageType.WaterFiltration, () => new(config.water_filtration, config.height_filtration) },
        };

        public static float2 GetSize(this StorageResizer resizer, StorageType storageType)
        {
            if(Values.TryGetValue(storageType, out var values))
                return values();

            // this should never run
            return new(0, 0);
        }
    }
    

    public class StorageResizer : MonoBehaviour
    {
        public StorageType type;
        public object container;
        public bool applyChangesAutomatically;
        public float2 currentSize, intendedSize;


        public void OnEnable() => StorageResizers.Add(this, type);


        public void OnDisable() => StorageResizers.Remove(this);


        public void Start() => Resize();


        public void Resize()
        {
            if(type == StorageType.Unknown)
                Destroy(this);

            if(container == null)
                throw new NullReferenceException($"{type} : 'container' is null");

            intendedSize = this.GetSize(type);

            if(type == StorageType.WaterFiltration && gameObject.TryGetComponent<FiltrationMachine>(out var filtration))
            {
                filtration.maxSalt = (int)config.salt_filtration;
                filtration.maxWater = (int)config.water_filtration;
            }

            if(type == StorageType.BioReactor)
            {
                // probably not needed, needs testing to confirm
                if(container == null)
                    return;
            }

            if(type == StorageType.Exosuit)
            {
                if(gameObject.TryGetComponent<Exosuit>(out var exosuit))
                {
                    StorageContainer storageContainer = container as StorageContainer;
                    storageContainer.Resize((int)intendedSize.x + (int)(config.height_prawnSuitModule * exosuit.modules.GetCount(TechType.VehicleStorageModule)), (int)intendedSize.y);
                }
                return;
            }

            switch(container)
            {
                case object obj when obj is StorageContainer:
                    StorageContainer storageContainer = obj as StorageContainer;
                    storageContainer.Resize((int)intendedSize.x, (int)intendedSize.y);
                    break;

                case object obj when obj is ItemsContainer:
                    ItemsContainer itemsContainer = obj as ItemsContainer;
                    itemsContainer.Resize((int)intendedSize.x, (int)intendedSize.y);
                    break;

                case object obj when obj is SeamothStorageContainer:
                    SeamothStorageContainer seamothStorageContainer = obj as SeamothStorageContainer;
                    seamothStorageContainer.width = (int)intendedSize.x;
                    seamothStorageContainer.height = (int)intendedSize.y;
                    break;

                default:
                    throw new ArgumentException($"The type of container '{container.GetType()}' is not yet handled by this mod, please DM/message @ramuneneptune about this on discord");
            }

            currentSize = intendedSize;
        }


        public void Update()
        {
            if(!this.applyChangesAutomatically)
                return;

            intendedSize = this.GetSize(type);

            // if the current values are set to the config values, return
            if(currentSize.x == intendedSize.x && currentSize.y == intendedSize.y)
                return;
                
            // else resize (this method will also update the currentHeight and currentWidth meaning this should only run once)
            this.Resize();
        }
    }
}