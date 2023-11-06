

namespace Ramune.Seal.CustomizableLights
{
    [Menu("Seal Customizable Lights")]
    public class Config : ConfigFile
    {
        public static Color floodlight_color;
        public static Color internal_color;

        [Toggle("<b>Floodlight</b> settings: <alpha=#00>---------------------------------------------------------------------------------------------------</alpha>")]
        public bool DIVIDER_1 = false;

        [Slider("  • <color=#FFC029>Floodlights</color> Red (<color=#FFC029>R</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_red = 1f;

        [Slider("  • <color=#FFC029>Floodlights</color> Green (<color=#FFC029>G</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_green = 1f;

        [Slider("  • <color=#FFC029>Floodlights</color> Blue (<color=#FFC029>B</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_blue = 1f;

        [Slider("  • <color=#FFC029>Floodlights</color> Range", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_range = 1f;

        [Slider("  • <color=#FFC029>Floodlights</color> Intensity", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_intensity = 1f;

        [Slider("  • <color=#FFC029>Floodlights</color> Conesize", Format = "{0:F2}x", DefaultValue = 1f, Min = 0.1f, Max = 3f, Step = 0.01f), OnChange(nameof(RefreshFloodlights))]
        public float floodlight_conesize = 1f;

        [Toggle("<b>Internal Light</b> settings: <alpha=#00>---------------------------------------------------------------------------------------------------</alpha>")]
        public bool DIVIDER_3 = false;

        [Slider("  • <color=#FFC029>Internal Lights</color> Red (<color=#FFC029>R</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshInternals))]
        public float internal_red = 1f;

        [Slider("  • <color=#FFC029>Internal Lights</color> Green (<color=#FFC029>G</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshInternals))]
        public float internal_green = 1f;

        [Slider("  • <color=#FFC029>Internal Lights</color> Blue (<color=#FFC029>B</color>)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshInternals))]
        public float internal_blue = 1f;

        [Slider("  • <color=#FFC029>Internal Lights</color> Intensity", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(RefreshInternals))]
        public float internal_intensity = 1f;

        /*
        [Toggle("  • <color=#FFC029>Internal Lights</color> Use Rainbow Mode")]
        public bool internal_rainbow = false;

        [Slider("  • <color=#FFC029>Internal Lights</color> Rainbow Mode Length (<color=#FFC029>s</color>)", Format = "{0:F1}s", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f), OnChange(nameof(RefreshInternal))]
        public float internal_rainbow_length = 1f;
        */

        public void RefreshFloodlights()
        {
            if(Patches.SealSubRootPatch.debug) LoggerUtils.Screen.LogDebug("RefreshFloodlights()");

            if(Patches.SealSubRootPatch.seal_floodlights.Count == 0)
                return;

            floodlight_color.r = floodlight_red;
            floodlight_color.g = floodlight_green;
            floodlight_color.b = floodlight_blue;

            foreach(var li in Patches.SealSubRootPatch.seal_floodlights)
            {
                li.color = floodlight_color;
                li.range = 60f * floodlight_range;
                li.intensity = 2f * floodlight_intensity;
                li.spotAngle = 45f * floodlight_conesize;
            }
        }

        public void RefreshInternals()
        {            
            if(Patches.SealSubRootPatch.debug) LoggerUtils.Screen.LogDebug("RefreshInternals()");

            if(Patches.SealSubRootPatch.seal_internals.Count == 0)
                return;

            internal_color.r = internal_red;
            internal_color.g = internal_green;
            internal_color.b = internal_blue;

            foreach(var li in Patches.SealSubRootPatch.seal_internals)
            {
                li.color = internal_color;
                li.intensity = 1.5f * internal_intensity;
            }
        }
    }
}