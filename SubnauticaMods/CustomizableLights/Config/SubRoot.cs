
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#00e2ff>Cyclops</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 16), OnChange(nameof(CyclopsOnColorChange))]
        public float CyclopsRed = 1f;

        [Slider("<color=#00e2ff>Cyclops</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 17), OnChange(nameof(CyclopsOnColorChange))]
        public float CyclopsGreen = 1f;

        [Slider("<color=#00e2ff>Cyclops</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 18), OnChange(nameof(CyclopsOnColorChange))]
        public float CyclopsBlue = 1f;

        [Slider("<color=#00e2ff>Cyclops</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 19), OnChange(nameof(CyclopsOnSettingsChange))]
        public float CyclopsRange = 1f;

        [Slider("<color=#00e2ff>Cyclops</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 20), OnChange(nameof(CyclopsOnSettingsChange))]
        public float CyclopsIntensity = 1f;

        [Slider("<color=#00e2ff>Cyclops</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 21), OnChange(nameof(CyclopsOnSettingsChange))]
        public float CyclopsConesize = 1f;

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 22)]
        public bool CyclopsDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> CyclopsOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> CyclopsOnColorChangeEvent;


        public void CyclopsOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { CyclopsRange, CyclopsIntensity, CyclopsConesize });
            CyclopsOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void CyclopsOnColorChange()
        {
            _CyclopsColor.r = CyclopsRed;
            _CyclopsColor.g = CyclopsGreen;
            _CyclopsColor.b = CyclopsBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_CyclopsColor);
            CyclopsOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}