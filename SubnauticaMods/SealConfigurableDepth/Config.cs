

namespace Ramune.Seal.ConfigurableDepth
{
    [Menu("Seal Configurable Depth")]
    public class Config : ConfigFile
    {
        //[Slider("Seal base depth", Format = "{0:F0}", DefaultValue = 800f, Min = 100f, Max = 10000f, Step = 100f)]
        //public float Depth = 800f;

        [Slider("Mk1 additional depth", Format = "{0:F1}", DefaultValue = 900f, Min = 100f, Max = 10000f, Step = 100f)]
        public float DepthMk1 = 900f;

        [Slider("Mk2 additional depth", Format = "{0:F1}", DefaultValue = 1300f, Min = 100f, Max = 10000f, Step = 100f)]
        public float DepthMk2 = 1300f;

        [Slider("Mk3 additional depth", Format = "{0:F1}", DefaultValue = 1800f, Min = 100f, Max = 10000f, Step = 100f)]
        public float DepthMk3 = 1800f;
    }
}