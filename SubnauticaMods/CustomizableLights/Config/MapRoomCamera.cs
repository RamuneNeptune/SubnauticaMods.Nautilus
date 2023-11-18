
using Ramune.CustomizableLights.Monos;


namespace Ramune.CustomizableLights
{
    public partial class Config : ConfigFile
    {
        [Slider("<color=#ffbd2e>Drone</color> Light Red (R)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 23), OnChange(nameof(DroneOnColorChange))]
        public float DroneRed = 1f;

        [Slider("<color=#ffbd2e>Drone</color> Light Green (G)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 24), OnChange(nameof(DroneOnColorChange))]
        public float DroneGreen = 1f;

        [Slider("<color=#ffbd2e>Drone</color> Light Blue (B)", Format = "{0:F1}", DefaultValue = 1f, Min = 0f, Max = 1f, Step = 0.1f, Order = 25), OnChange(nameof(DroneOnColorChange))]
        public float DroneBlue = 1f;

        [Slider("<color=#ffbd2e>Drone</color> Light Range Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 26), OnChange(nameof(DroneOnSettingsChange))]
        public float DroneRange = 1f;

        [Slider("<color=#ffbd2e>Drone</color> Light Intensity Multiplier (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 27), OnChange(nameof(DroneOnSettingsChange))]
        public float DroneIntensity = 1f;

        [Slider("<color=#ffbd2e>Drone</color> Light Cone Size Multipler (x)", Format = "{0:0.0}x", DefaultValue = 1f, Min = 0f, Max = 5f, Step = 0.1f, Order = 28), OnChange(nameof(DroneOnSettingsChange))]
        public float DroneConesize = 1f;

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 29)]
        public bool DroneDivider = false;


        public event EventHandler<CustomEventArgs.SettingsEventArgs> DroneOnSettingsChangeEvent;
        public event EventHandler<CustomEventArgs.ColorEventArgs> DroneOnColorChangeEvent;


        public void DroneOnSettingsChange()
        {
            var eventArgs = new CustomEventArgs.SettingsEventArgs(new float[] { DroneRange, DroneIntensity, DroneConesize });
            DroneOnSettingsChangeEvent?.Invoke(this, eventArgs);
        }

        public void DroneOnColorChange()
        {
            _DroneColor.r = DroneRed;
            _DroneColor.b = DroneGreen;
            _DroneColor.g = DroneBlue;

            var eventArgs = new CustomEventArgs.ColorEventArgs(_DroneColor);
            DroneOnColorChangeEvent?.Invoke(this, eventArgs);
        }
    }
}