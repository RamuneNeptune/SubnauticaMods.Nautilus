

namespace Ramune.SimpleCoordinates
{
    [Menu("Simple Coordinates")]
    public class Config : ConfigFile
    {
        [Toggle("Display player coords", Order = 0)]
        public bool display = true;

        [Slider("Player coords size", Format = "{0:F0}", DefaultValue = 23f, Min = 1f, Max = 100f, Step = 1f, Tooltip = "Changes are applied automatically", Order = 1), OnChange(nameof(SendChanges))]
        public float textSize = 23f;

        [Slider("Player coords offset (X)", Format = "{0:F0}", DefaultValue = -830f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 2), OnChange(nameof(SendChanges))]
        public float textX = -830f;

        [Slider("Player coords offset (Y)", Format = "{0:F0}", DefaultValue = 510f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 3), OnChange(nameof(SendChanges))]
        public float textY = 510f;

        [Toggle("Display target coords", Order = 4)]
        public bool targetDisplay = false;

        [Slider("Target coords size", Format = "{0:F0}", DefaultValue = 21f, Min = 1f, Max = 100f, Step = 1f, Tooltip = "Changes are applied automatically", Order = 5), OnChange(nameof(SendChanges))]
        public float targetTextSize = 21f;

        [Slider("Target coords offset (X)", Format = "{0:F0}", DefaultValue = -830f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 6), OnChange(nameof(SendChanges))]
        public float targetTextX = -830f;

        [Slider("Target coords offset (Y)", Format = "{0:F0}", DefaultValue = 480f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 7), OnChange(nameof(SendChanges))]
        public float targetTextY = 480f;

        [Button("Refresh target coordinates", Tooltip = "Use this after editing TargetCoordinates.json", Order = 8)]
        public void Refresh(ButtonClickedEventArgs _)
        {
            Monos.CoordinateDisplay.RefreshJson();
        }

        [Button("Open TargetCoordinates.json", Tooltip = "Opens the json file which your Target Coordinates will be read from", Order = 9)]
        public void Open(ButtonClickedEventArgs _)
        {
            System.Diagnostics.Process.Start(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TargetCoordinates.json"));
        }

        public void SendChanges(object sender, SliderChangedEventArgs args)
        {
            Monos.CoordinateDisplay.AdjustForConfig();
        }
    }
}