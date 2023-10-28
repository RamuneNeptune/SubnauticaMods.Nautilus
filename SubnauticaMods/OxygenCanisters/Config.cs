

namespace Ramune.OxygenCanisters
{
    [Menu("Oxygen Canisters")]
    public class Config : ConfigFile
    {
        [Slider("Oxygen Canister capacity", Format = "{0:F1}", DefaultValue = 35f, Min = 5f, Max = 200f, Step = 5f, Tooltip = "Changes are applied on restart", Order = 0)]
        public float canisterCapacity = 35f;

        [Slider("Large Oxygen Canister capacity", Format = "{0:F1}", DefaultValue = 70f, Min = 5f, Max = 200f, Step = 5f, Tooltip = "Changes are applied on restart", Order = 1)]
        public float largeCanisterCapacity = 70f;
    }
}