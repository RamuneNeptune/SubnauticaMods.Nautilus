

namespace Ramune.RadiantDepths.Monos
{
    public class CustomOutcrop : MonoBehaviour
    {
        /// <summary>
        /// Unique identifier used to figure out what Drops to add to this outcrop
        /// </summary>
        public string GUID = "";


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


        /// <summary>
        /// Start method, obviously
        /// </summary>
        public void Start()
        {
            if(ItemUtils.OutcropPatcher.TryGetValue(GUID, out var key)) AddDrops(key);
            else throw new Exception($"{name} doesn't have an entry in OutcropPatcher, plz fix");
        }


        /// <summary>
        /// Sets the Drops and TotalChance fields
        /// </summary>
        public void AddDrops(Dictionary<TechType, float> additionalDrops)
        {
            Drops = new();
            Drops.AddRange(additionalDrops);
            TotalChance = Drops.Values.Sum();
        }


        /// <summary>
        /// Returns a TechType from Drops after doing copious amounts of meth
        /// </summary>
        public TechType GetRandomTechType()
        {
            var randomValue = UnityEngine.Random.Range(0f, TotalChance);
            int i = 0;

            foreach(var drop in Drops)
            {
                i++;
                randomValue -= drop.Value;
                if(LoggerUtils.Debug) LoggerUtils.Screen.LogInfo($"[{i}] Remaining: {randomValue}");

                if(randomValue <= 0f)
                {
                    if(LoggerUtils.Debug) LoggerUtils.Screen.LogSuccess($"[{i}] {drop.Key} won");
                    return drop.Key;
                }
                else if(LoggerUtils.Debug) LoggerUtils.Screen.LogFail($"[{i}] {drop.Key} lost");
            }

            return TechType.Titanium;
        }
    }
}