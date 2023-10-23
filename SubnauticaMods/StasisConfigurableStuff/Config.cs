

namespace Ramune.StasisConfigurableStuff
{
    [Menu("Stasis Configurable Stuff")]
    public class Config : ConfigFile
    {
        [Slider("Time to charge (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f)]
        public float chargeDuration = 1f;

        [Slider("Energy cost per shot (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f)]
        public float energyCost = 1f;
    }
}