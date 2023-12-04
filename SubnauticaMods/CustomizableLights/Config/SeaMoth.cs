
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#a1ff0a>Seamoth</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 1), OnChange(nameof(SeamothOnColorChange))]
        public float SeamothRed = 1f;

        [Slider("<color=#a1ff0a>Seamoth</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 2), OnChange(nameof(SeamothOnColorChange))]
        public float SeamothGreen = 1f;

        [Slider("<color=#a1ff0a>Seamoth</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 3), OnChange(nameof(SeamothOnColorChange))]
        public float SeamothBlue = 1f;

        [Slider("<color=#a1ff0a>Seamoth</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 4), OnChange(nameof(SeamothOnSettingsChange))]
        public float SeamothRange = 1f;

        [Slider("<color=#a1ff0a>Seamoth</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 5), OnChange(nameof(SeamothOnSettingsChange))]
        public float SeamothIntensity = 1f;

        [Slider("<color=#a1ff0a>Seamoth</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 6), OnChange(nameof(SeamothOnSettingsChange))]
        public float SeamothConesize = 1f;

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 7)]
        public bool SeamothDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> SeamothOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> SeamothOnColorChangeEvent;


        public void SeamothOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { SeamothRange, SeamothIntensity, SeamothConesize });
            SeamothOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void SeamothOnColorChange()
        {
            _SeamothColor.r = SeamothRed;
            _SeamothColor.g = SeamothGreen;
            _SeamothColor.b = SeamothBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_SeamothColor);
            SeamothOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}