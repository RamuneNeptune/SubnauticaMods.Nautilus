
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#f9c80e>Exosuit</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 8), OnChange(nameof(ExosuitOnColorChange))]
        public float ExosuitRed = 1f;

        [Slider("<color=#f9c80e>Exosuit</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 9), OnChange(nameof(ExosuitOnColorChange))]
        public float ExosuitGreen = 1f;

        [Slider("<color=#f9c80e>Exosuit</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 11), OnChange(nameof(ExosuitOnColorChange))]
        public float ExosuitBlue = 1f;

        [Slider("<color=#f9c80e>Exosuit</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 12), OnChange(nameof(ExosuitOnSettingsChange))]
        public float ExosuitRange = 1f;

        [Slider("<color=#f9c80e>Exosuit</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 13), OnChange(nameof(ExosuitOnSettingsChange))]
        public float ExosuitIntensity = 1f;

        [Slider("<color=#f9c80e>Exosuit</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 14), OnChange(nameof(ExosuitOnSettingsChange))]
        public float ExosuitConesize = 1f;

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 15)]
        public bool ExosuitDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> ExosuitOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> ExosuitOnColorChangeEvent;


        public void ExosuitOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { ExosuitRange, ExosuitIntensity, ExosuitConesize });
            ExosuitOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void ExosuitOnColorChange()
        {
            _ExosuitColor.r = ExosuitRed;
            _ExosuitColor.g = ExosuitGreen;
            _ExosuitColor.b = ExosuitBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_ExosuitColor);
            ExosuitOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}