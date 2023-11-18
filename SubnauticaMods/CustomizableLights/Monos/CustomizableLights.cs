

namespace Ramune.CustomizableLights.Monos
{
    public static class CustomEventArgs
    {
        public class ColorEventArgs : EventArgs
        {
            public Color EventColor { get; }

            public ColorEventArgs(Color color) => EventColor = color;
        }


        public class SettingsEventArgs : EventArgs
        {
            public float[] EventSettings { get; }

            public SettingsEventArgs(float[] settings) => EventSettings = settings;
        }
    }


    public class CustomizableLights : MonoBehaviour
    {
        public Light[] lights;

        public float[] defaults;

        public void OnColorChange(object sender, CustomEventArgs.ColorEventArgs args)
        {
            foreach(var li in this.lights)
            {
                if(li is null)
                    break;

                li.color = args.EventColor;
            }
        }

        public void OnSettingsChange(object sender, CustomEventArgs.SettingsEventArgs args)
        {
            foreach(var li in this.lights)
            {
                if(li is null)
                    break;

                li.range = defaults[0] * args.EventSettings[0];
                li.intensity = defaults[1] * args.EventSettings[1];

                li.spotAngle = defaults[2] * args.EventSettings[2];
                li.innerSpotAngle = defaults[3] * args.EventSettings[2];
            }
        }
    }
}