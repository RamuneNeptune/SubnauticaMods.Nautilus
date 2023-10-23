

namespace Ramune.FasterScanning
{
    [Menu("Faster Scanning")]
    public class Config : ConfigFile
    {
        [Slider("Scanning speed multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f)]
        public float multiplier = 1f;
    }
}