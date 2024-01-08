

namespace Ramune.RadiantDepths.Monos
{
    public class CustomOutcrop : MonoBehaviour
    {
        /// <summary>
        /// Dictionary for: item to spawn, chance to spawn
        /// </summary>
        public Dictionary<TechType, float> Drops;


        /// <summary>
        /// When running the chance logic if the thing doesn't win the chance this item is spawned instead
        /// </summary>
        public int DropAmount = 1;


        /// <summary>
        /// The total weight from all values in 'Drops' dictionary, used when picking a random TechType to drop
        /// </summary>
        public float TotalChance = -1f;


        public void AddDrops(Dictionary<TechType, float> additionalDrops)
        {
            var totalCount = additionalDrops.Count;
            var currentCount = 0f;

            Drops = new();

            LoggerUtils.Screen.LogDebug($"Starting with {totalCount} items to add");
            LoggerUtils.Screen.LogInfo($"Drops: {Drops.Count}");

            foreach(var pair in additionalDrops)
            {
                Drops.Add(pair.Key, pair.Value);
                LoggerUtils.Screen.LogDebug($"Added {pair.Key} to Drops ({currentCount + 1}/{totalCount})");
                currentCount++;
            }

            LoggerUtils.Screen.LogInfo($"Drops: {Drops.Count}");

            currentCount = 0f;
            foreach(var pair in Drops)
            {
                LoggerUtils.Screen.LogDebug($"{pair.Key} ({currentCount + 1}/{totalCount})");
                currentCount++;
            }

            TotalChance = Drops.Values.Sum();
        }


        public void Update()
        {
            if(Drops == null) LoggerUtils.Screen.LogWarning($"Drops.Count: null");
            else LoggerUtils.Screen.LogWarning($"Drops.Count: {Drops.Count}");
        }


        public TechType GetRandomTechType()
        {
            var totalCount = Drops.Count;
            var currentCount = 0f;

            LoggerUtils.Screen.LogInfo($"Drops: {totalCount}");
            foreach(var pair in Drops)
            {
                LoggerUtils.Screen.LogDebug($"{pair.Key} ({currentCount + 1}/{totalCount})");
                currentCount++;
            }

            var randomValue = UnityEngine.Random.Range(0f, TotalChance);

            foreach(var drop in Drops)
            {
                randomValue -= drop.Value;

                if(randomValue <= 0f)
                {
                    LoggerUtils.Screen.LogSuccess($"{drop.Key} is being spawned");
                    return drop.Key;
                }
                LoggerUtils.Screen.LogFail($"{drop.Key} is not being spawned");
            }

            return TechType.Titanium;
        }
    }
}