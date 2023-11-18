

namespace Ramune.Seal.UITweaks
{
    [Menu("Seal UI Tweaks")]
    public class Config : ConfigFile
    {
        public static string[] extendedSlotInfoOptions = new string[] { "Slot (number): Module name", "Module name" };

        public static string[] powerStatusOptions = new string[] { "Current power / max power", "Max power / current power", "Current power", "Max power" };

        [Toggle("Display extended slot info for upgrade consoles")]
        public bool displayExtendedSlotInfo = true;

        //[Choice("  <color=#ffc600><b>»</b></color> Extended slot info format", Options = new string[] { "Slot (number): Module name", "Module name" })]
        //public string extendedSlotInfoFormat = extendedSlotInfoOptions[0];

        [Toggle("  <color=#ffc600><b>»</b></color> Extended slot info show 'Available slots' count")]
        public bool extendedSlotInfoSlotsFreeCount = true;

        [Toggle("  <color=#ffc600><b>»</b></color> Extended slot info show empty slots")]
        public bool extendedSlotInfoShowEmpty = true;

        [Toggle("  <color=#ffc600><b>»</b></color> Extended slot info show full slots")]
        public bool extendedSlotInfoShowFull = true;


        [Toggle("<alpha=#00>---------------------------------------------------------------------------------------------------</alpha>")]
        public bool divider1 = false;
        

        [Toggle("Display altitude when above 0m in helm/piloting HUD")]
        public bool displayAltitude = true;

        [Toggle("Display current & max power in helm/piloting HUD")]
        public bool displayCurrentPower = true;


        [Toggle("<alpha=#00>---------------------------------------------------------------------------------------------------</alpha>")]
        public bool divider2 = false;


        [Toggle("Display power status in helm/piloting HUD")]
        public bool displayPowerStatus = true;

        [Choice("  <color=#ffc600><b>»</b></color> Power status format", Options = new string[] { "Current power / max power", "Max power / current power", "Current power", "Max power" })]
        public string powerStatusFormat = powerStatusOptions[0];

        [Slider("  <color=#ffc600><b>»</b></color> % for <color=#1ed724>stable</color> power", Format = "{0:F0}%", DefaultValue = 100f, Min = 99.9f, Max = 100f, Step = 1f), OnChange(nameof(OnChange))]
        public float stable = 100f;

        [Slider("  <color=#ffc600><b>»</b></color> % for <color=#fbd03c>low</color> power", Format = "{0:F0}%", DefaultValue = 25f, Min = 1f, Max = 99f, Step = 1f), OnChange(nameof(OnChange))]
        public float low = 25f;

        [Slider("  <color=#ffc600><b>»</b></color> % for <color=#ff3f00>critical</color> power", Format = "{0:F0}%", DefaultValue = 10f, Min = 1f, Max = 99f, Step = 1f), OnChange(nameof(OnChange))]
        public float critical = 10f;

        public static void OnChange() => Patches.PowerUIManagerPatch.OnPercentageChanged(Patches.PowerUIManagerPatch.GetPercentage());
    }
}