
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#ffbd2e>Flashlight</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 37), OnChange(nameof(FlashlightOnColorChange))]
        public float FlashlightRed = 1f;

        [Slider("<color=#ffbd2e>Flashlight</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 38), OnChange(nameof(FlashlightOnColorChange))]
        public float FlashlightGreen = 1f;

        [Slider("<color=#ffbd2e>Flashlight</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 39), OnChange(nameof(FlashlightOnColorChange))]
        public float FlashlightBlue = 1f;

        [Slider("<color=#ffbd2e>Flashlight</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 40), OnChange(nameof(FlashlightOnSettingsChange))]
        public float FlashlightRange = 1f;

        [Slider("<color=#ffbd2e>Flashlight</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 41), OnChange(nameof(FlashlightOnSettingsChange))]
        public float FlashlightIntensity = 1f;

        [Slider("<color=#ffbd2e>Flashlight</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 42), OnChange(nameof(FlashlightOnSettingsChange))]
        public float FlashlightConesize = 1f;

        //[Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 43)]
        //public bool FlashlightDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> FlashlightOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> FlashlightOnColorChangeEvent;


        public void FlashlightOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { ExosuitRange, ExosuitIntensity, ExosuitConesize });
            FlashlightOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void FlashlightOnColorChange()
        {
            _FlashlightColor.r = FlashlightRed;
            _FlashlightColor.g = FlashlightGreen;
            _FlashlightColor.b = FlashlightBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_FlashlightColor);
            FlashlightOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}