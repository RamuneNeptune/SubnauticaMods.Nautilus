

namespace Ramune.Seal.UITweaks
{
    [Menu("Seal UI Tweaks")]
    public class Config : ConfigFile
    {
        [Toggle("Display power status in helm/piloting HUD")]
        public bool displayPowerStatus = true;

        [Toggle("Display current power in helm/piloting HUD")]
        public bool displayCurrentPower = true;

        //[Toggle("Display empty slots for upgrade consoles")]
        //public bool displayEmpty = true;

        [Slider("Percentage start for stable status (%)", Format = "{0:F0}%", DefaultValue = 100f, Min = 0f, Max = 100f, Step = 1f)]
        public float stableStart = 100f;

        [Slider("Percentage end for stable status (%)", Format = "{0:F0}%", DefaultValue = 26f, Min = 0f, Max = 100f, Step = 1f)]
        public float stableEnd = 26f;

        [Slider("Percentage start for low status (%)", Format = "{0:F0}%", DefaultValue = 25f, Min = 0f, Max = 100f, Step = 1f)]
        public float lowStart = 25f;

        [Slider("Percentage end for low status (%)", Format = "{0:F0}%", DefaultValue = 11f, Min = 0f, Max = 100f, Step = 1f)]
        public float lowEnd = 11f;

        [Slider("Percentage start for critical status (%)", Format = "{0:F0}%", DefaultValue = 10f, Min = 0f, Max = 100f, Step = 1f)]
        public float criticalStart = 10f;

        [Slider("Percentage end for critical status (%)", Format = "{0:F0}%", DefaultValue = 0f, Min = 0f, Max = 100f, Step = 1f)]
        public float criticalEnd = 0f;
    }
}