
global using static Ramune.RamunesCustomizedStorage.RamunesCustomizedStorage;
global using static Ramune.RamunesCustomizedStorage.Monos.StorageTypeConfig;


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

        public static Dictionary<StorageType, Func<(float, float)>> Values = new()
        {
            { StorageType.Unknown, () => (10f, 10f) },
            { StorageType.Inventory, () => (config.width_inventory, config.height_inventory) },
            { StorageType.Seamoth, () => (config.width_seamoth, config.height_seamoth) },
            { StorageType.Exosuit, () => (config.width_prawnSuit, config.height_prawnSuit) },
            { StorageType.CyclopsLocker, () => (config.width_cyclops, config.height_cyclops) },
            { StorageType.WallLocker, () => (config.width_wallLocker, config.height_wallLocker) },
            { StorageType.StandingLocker, () => (config.width_locker, config.height_locker) },
            { StorageType.LifepodLocker, () => (config.width_lifepod, config.height_lifepod) },
            { StorageType.WaterproofLocker, () => (config.width_waterproofLocker, config.height_waterproofLocker) },
            { StorageType.CarryAll, () => (config.width_carryAll, config.height_carryAll) },
            { StorageType.BioReactor, () => (config.width_bioReactor, config.height_bioReactor) },
            { StorageType.WaterFiltration, () => (config.water_filtration, config.height_filtration) },
        };

        public static(float, float) GetSize(this StorageResizer resizer, StorageType storageType)
        {
            if(Values.ContainsKey(storageType))
                return Values[storageType]();

            throw new Exception($"'{resizer.gameObject.name}' has a storage type of 'StorageType.Unknown'");
        }
    }


    public class StorageResizer : MonoBehaviour
    {
        public StorageType type;
        public object container;

        public void OnEnable() => StorageResizers.Add(this, type);

        public void OnDisable() => StorageResizers.Remove(this);

        public void Start() => Resize();

        public void Resize()
        {
            LoggerUtils.Debug = true;

            (float width, float height) = this.GetSize(type);

            var filtration = gameObject.GetComponent<FiltrationMachine>();
            if(type == StorageType.WaterFiltration && filtration is not null)
            {
                filtration.maxSalt = (int)config.salt_filtration;
                filtration.maxWater = (int)config.water_filtration;
            }

            var bioreactor = gameObject.GetComponent<BaseBioReactor>();
            if(type == StorageType.BioReactor && bioreactor is not null)
            {
                bioreactor._container.sizeX = (int)config.width_bioReactor;
                bioreactor._container.sizeY = (int)config.height_bioReactor;
            }

            if(LoggerUtils.Debug)
            {
                LoggerUtils.LogWarning($"---------------- {type} : BEGIN ----------------");

                LoggerUtils.LogWarning($"width = {width}");
                LoggerUtils.LogWarning($"height = {height}");

                bool isBioreactor = bioreactor is not null;
                if(isBioreactor)
                {
                    LoggerUtils.LogWarning("bioreactor = true");
                }

                bool isFiltration = filtration is not null;
                if(isFiltration)
                {
                    LoggerUtils.LogWarning($"maxSalt = {filtration.maxSalt}");
                    LoggerUtils.LogWarning($"maxWater = {filtration.maxWater}");
                }
            }

            if(container == null)
                throw new NullReferenceException($"{type} : 'container' is null");

            if(LoggerUtils.Debug) LoggerUtils.LogWarning("");

            switch(container)
            {
                case object obj when obj is StorageContainer:
                    StorageContainer storageContainer = obj as StorageContainer;
                    if (LoggerUtils.Debug) LoggerUtils.LogWarning($"container is 'StorageContainer'");
                    storageContainer.Resize((int)width, (int)height);
                    if (LoggerUtils.Debug) LoggerUtils.LogWarning($"finished setting to {width}, {height}");
                    break;

                case object obj when obj is ItemsContainer:
                    ItemsContainer itemsContainer = obj as ItemsContainer;
                    if (LoggerUtils.Debug) LoggerUtils.LogWarning($"container is 'ItemsContainer'");
                    itemsContainer.Resize((int)width, (int)height);
                    if (LoggerUtils.Debug) LoggerUtils.LogWarning($"finished setting to {width}, {height}");
                    break;

                case object obj when obj is SeamothStorageContainer:
                    SeamothStorageContainer seamothStorageContainer = obj as SeamothStorageContainer;
                    if(LoggerUtils.Debug) LoggerUtils.LogWarning($"container is 'SeamothStorageContainer'");
                    seamothStorageContainer.width = (int)width;
                    seamothStorageContainer.height = (int)height;
                    if(LoggerUtils.Debug) LoggerUtils.LogWarning($"finished setting to {width}, {height}");
                    break;

                default:
                    throw new ArgumentException($"The type of container '{container.GetType()}' is not yet handled by this mod, please DM/message @ramuneneptune about this on discord");
            }

            if(LoggerUtils.Debug) LoggerUtils.LogWarning($"---------------- {type} : FINISH ----------------\n");
        }

        public StorageType GetStorageType() => type; // this will be used when i implement adjusting storage sizes without restarting the game
    }
}