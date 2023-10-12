

namespace Ramune.ConfigurableSeaglide
{
    [Menu("Configurable Seaglide")]
    public class Config : ConfigFile
    {
        [Slider("General Acceleration Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "Changes are applied when equipping the Seaglide", Order = 0)]
        public float accelerationMultiplier = 1f;

        [Slider("Forward Speed Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "Changes are applied when equipping the Seaglide", Order = 1)]
        public float forwardSpeedMultiplier = 1f;

        [Slider("Backwards Speed Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "Changes are applied when equipping the Seaglide", Order = 2)]
        public float backwardSpeedMultiplier = 1f;

        [Slider("Strafe Speed Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "Changes are applied when equipping the Seaglide", Order = 3)]
        public float strafeSpeedMultiplier = 1f;

        [Slider("Vertical Speed Multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f, Tooltip = "Changes are applied when equipping the Seaglide", Order = 4)]
        public float verticalSpeedMultiplier = 1f;
    }
}