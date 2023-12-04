
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#4cc9f0>Seaglide</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 30), OnChange(nameof(SeaglideOnColorChange))]
        public float SeaglideRed = 1f;

        [Slider("<color=#4cc9f0>Seaglide</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 31), OnChange(nameof(SeaglideOnColorChange))]
        public float SeaglideGreen = 1f;

        [Slider("<color=#4cc9f0>Seaglide</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 32), OnChange(nameof(SeaglideOnColorChange))]
        public float SeaglideBlue = 1f;

        [Slider("<color=#4cc9f0>Seaglide</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 33), OnChange(nameof(SeaglideOnSettingsChange))]
        public float SeaglideRange = 1f;

        [Slider("<color=#4cc9f0>Seaglide</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 34), OnChange(nameof(SeaglideOnSettingsChange))]
        public float SeaglideIntensity = 1f;

        [Slider("<color=#4cc9f0>Seaglide</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 35), OnChange(nameof(SeaglideOnSettingsChange))]
        public float SeaglideConesize = 1f;

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 36)]
        public bool SeaglideDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> SeaglideOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> SeaglideOnColorChangeEvent;


        public void SeaglideOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { SeaglideRange, SeaglideIntensity, SeaglideConesize });
            SeaglideOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void SeaglideOnColorChange()
        {
            _SeaglideColor.r = SeaglideRed;
            _SeaglideColor.g = SeaglideGreen;
            _SeaglideColor.b = SeaglideBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_SeaglideColor); 
            SeaglideOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}