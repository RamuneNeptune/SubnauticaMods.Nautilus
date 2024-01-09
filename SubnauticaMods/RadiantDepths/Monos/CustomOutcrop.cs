

namespace Ramune.RadiantDepths.Monos
{
    public class CustomOutcrop : MonoBehaviour
    {
        /// <summary>
        /// Dictionary for: item to spawn, chance to spawn
        /// </summary>
        public Dictionary<TechType, float> Drops;


        public string GUID = "";


        /// <summary>
        /// When running the chance logic if the thing doesn't win the chance this item is spawned instead
        /// </summary>
        public int DropAmount = 1;


        /// <summary>
        /// The total weight from all values in 'Drops' dictionary, used when picking a random TechType to drop
        /// </summary>
        public float TotalChance = -1f;


        public void Start()
        {
            if(Items.ItemUtils.OutcropPatcher.TryGetValue(GUID, out var key)) AddDrops(key);
            else throw new Exception($"{name} doesn't have an entry in OutcropPatcher, plz fix");
        }


        public void AddDrops(Dictionary<TechType, float> additionalDrops)
        {
            Drops = new();
            Drops.AddRange(additionalDrops);
            TotalChance = Drops.Values.Sum();
        }


        public TechType GetRandomTechType()
        {
            var randomValue = UnityEngine.Random.Range(0f, TotalChance);

            foreach(var drop in Drops)
            {
                randomValue -= drop.Value;

                if(randomValue <= 0f)
                    return drop.Key;
            }

            return TechType.Titanium;
        }
    }
}