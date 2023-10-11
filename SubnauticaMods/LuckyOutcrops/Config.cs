

namespace Ramune.LuckyOutcrops
{
    [Menu("Lucky Outcrops")]
    public class Config : ConfigFile
    {
        [Slider("Chance to spawn Crashfish (%)", Format = "{0:F0}%", DefaultValue = 5f, Min = 1f, Max = 100f, Step = 1f, Tooltip = "Changes are applied automatically")]
        public float crashfishChance = 5f;
    }
}