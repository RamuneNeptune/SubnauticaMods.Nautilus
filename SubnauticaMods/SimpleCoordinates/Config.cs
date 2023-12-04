

namespace Ramune.SimpleCoordinates
{
    [Menu("Simple Coordinates")]
    public class Config : ConfigFile
    {
        public enum CoordPos
        {
            TopLeft,
            TopRight, 
            TopCenter, 
            LeftMiddle, 
            RightMiddle,
            BottomLeft,
            BottomCenter,
            BottomRight
        }


        [Toggle("Hide coordinates while in PDA", Order = 0)]
        public bool hideInPDA = false;

        [Toggle("Hide coordinates while in Cyclops", Order = 1)]
        public bool hideInCyclops = false;

        [Toggle("Hide coordinates while in Seamoth", Order = 2)]
        public bool hideInSeamoth = false;

        [Toggle("Hide coordinates while in Prawn Suit", Order = 3)]
        public bool hideInPrawnSuit = false;


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 4)]
        public bool divider1 = false;

        [Toggle("Display player coords", Order = 5)]
        public bool display = true;

        [Keybind("Display player coords keybind", Order = 6)]
        public KeyCode keybind = KeyCode.None;

        [ColorPicker("Player coords color", Advanced = true, Order = 7), OnChange(nameof(SendChanges))]
        public Color color = Monos.CoordinateDisplay.defaultColor;

        [Choice("Player coords style", Tooltip = "Changes are applied automatically", Order = 8), OnChange(nameof(SendChanges))]
        public FontStyles fontStyle = FontStyles.Normal;

        [Slider("Player coords size", Format = "{0:F0}", DefaultValue = 23f, Min = 1f, Max = 100f, Step = 1f, Tooltip = "Changes are applied automatically", Order = 9), OnChange(nameof(SendChanges))]
        public float textSize = 23f;

        [Slider("Player coords offset (X)", Format = "{0:F0}", DefaultValue = -830f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 10), OnChange(nameof(SendChanges))]
        public float textX = -830f;

        [Slider("Player coords offset (Y)", Format = "{0:F0}", DefaultValue = 510f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 11), OnChange(nameof(SendChanges))]
        public float textY = 510f;


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                

        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 12)]
        public bool divider2 = false;

        [Toggle("Display target coords", Order = 13)]
        public bool targetDisplay = false;

        [Keybind("Display target coords keybind", Order = 14)]
        public KeyCode targetKeybind = KeyCode.None;

        [ColorPicker("Target coords color", Advanced = true, Order = 15), OnChange(nameof(SendChanges))]
        public Color targetColor = Monos.CoordinateDisplay.defaultColor;

        [Choice("Target coords style", Tooltip = "Changes are applied automatically", Order = 16), OnChange(nameof(SendChanges))]
        public FontStyles targetFontStyle = FontStyles.Normal;

        [Choice("Target coords preset offsets", Tooltip = "Changes are applied automatically", Order = 18)]
        public string e = "e";

        [Slider("Target coords size", Format = "{0:F0}", DefaultValue = 21f, Min = 1f, Max = 100f, Step = 1f, Tooltip = "Changes are applied automatically", Order = 17), OnChange(nameof(SendChanges))]
        public float targetTextSize = 21f;

        [Slider("Target coords offset (X)", Format = "{0:F0}", DefaultValue = -830f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 18), OnChange(nameof(SendChanges))]
        public float targetTextX = -830f;

        [Slider("Target coords offset (Y)", Format = "{0:F0}", DefaultValue = 480f, Min = -1000f, Max = 1000f, Step = 5f, Tooltip = "Changes are applied automatically", Order = 19), OnChange(nameof(SendChanges))]
        public float targetTextY = 480f;


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        [Toggle("<alpha=#00>----------------------------------------------------------------------------------------------------</alpha>", Order = 20)]
        public bool divider3 = false;

        [Button("Open target coordinates config", Tooltip = "Opens the json file which your Target Coordinates will be read from", Order = 21)]
        public void Open(ButtonClickedEventArgs _)
        {
            Process.Start(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TargetCoordinates.json"));
        }

        [Button("Refresh target coordinates", Tooltip = "Use this after editing TargetCoordinates.json", Order = 22)]
        public void Refresh(ButtonClickedEventArgs _)
        {
            Monos.CoordinateDisplay.RefreshJson();
        }

        public void SendChanges(object sender, SliderChangedEventArgs args)
        {
            Monos.CoordinateDisplay.AdjustForConfig();
        }


//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}