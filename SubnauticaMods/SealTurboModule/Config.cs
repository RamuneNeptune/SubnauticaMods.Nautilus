

namespace Ramune.Seal.TurboModule
{
    [Menu("Seal Turbo Module")]
    public class Config : ConfigFile
    {
        [Slider("Turbo speed multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f)]
        public float multiplier = 1f;

        [Slider("Turbo speed duration (s)", Format = "{0:F1}s", DefaultValue = 2.5f, Min = 1f, Max = 10f, Step = 1f)]
        public float duration = 2.5f;

        [Slider("Cooldown in seconds (s)", Format = "{0:F1}s", DefaultValue = 15f, Min = 1f, Max = 60f, Step = 1f)]
        public float cooldown = 15f;
    }
}