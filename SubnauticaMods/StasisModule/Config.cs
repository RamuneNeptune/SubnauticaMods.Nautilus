

namespace Ramune.StasisModule
{
    [Menu("Stasis Module")]
    public class Config : ConfigFile
    {
        [Slider("Radius multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f)]
        public float radius = 1f;

        [Slider("Duration multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 5f, Step = 0.1f)]
        public float duration = 1f;
    }
}