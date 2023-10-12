

namespace Ramune.SeaglideBoosting
{
    [Menu("Seaglide Boosting")]
    public class Config : ConfigFile
    {
        [Keybind("Boost Keybind")]
        public KeyCode boostKey = KeyCode.LeftShift;

        [Slider("Boost Speed Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1.9f, Min = 0.1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 0)]
        public float boostMultiplier = 1.9f;

        [Slider("Boost Energy Usage Multiplier (x)", Format = "{0:F1}x", DefaultValue = 3.5f, Min = 0.1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 1)]
        public float energyMultiplier = 3.5f;
    }
}