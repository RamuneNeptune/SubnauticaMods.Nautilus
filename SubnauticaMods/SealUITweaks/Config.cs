

namespace Ramune.Seal.UITweaks
{
    [Menu("Seal UI Tweaks")]
    public class Config : ConfigFile
    {
        [Slider("Steering responsiveness (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(Apply))]
        public float responsiveness = 1f;
    }
}