

namespace Ramune.ToggleSilentRiggingLights
{
    [Menu("Toggle Silent Rigging Lights")]
    public class Config : ConfigFile
    {
        public static string[] ModeOptions = new string[] { "Only active when interior lights on", "Only active when interior lights off", "Always active" };

        [ColorPicker("Color to use", Advanced = true)]
        public Color color = Color.red;

        [Choice("Mode", options: new string[] { "Only active when interior lights on", "Only active when interior lights off", "Always active" })]
        public string modeSelected = ModeOptions[0];

        [Button("Enable custom light colors")]
        public void Enable(ButtonClickedEventArgs _)
        {
            if(Patches.SubRootPatch.subFloodAlarms.Count < 1)
                return;

            foreach(var subFloodAlarm in Patches.SubRootPatch.subFloodAlarms)
            {
                if(subFloodAlarm is null)
                {
                    Patches.SubRootPatch.subFloodAlarms.Remove(subFloodAlarm);
                    break;
                }

                subFloodAlarm.SetAlarmLightsActive(true);
                subFloodAlarm.SetAlarmLightPulseState(false);
                subFloodAlarm.SetAlarmLightColor(color);
            }
        }

        [Button("Disable custom light colors")]
        public void Disable(ButtonClickedEventArgs _)
        {
            if(Patches.SubRootPatch.subFloodAlarms.Count < 1)
                return;

            foreach(var subFloodAlarm in Patches.SubRootPatch.subFloodAlarms)
            {
                if(subFloodAlarm is null)
                {
                    Patches.SubRootPatch.subFloodAlarms.Remove(subFloodAlarm);
                    break;
                }

                subFloodAlarm.SetAlarmLightsActive(false);
            }
        }
    }
}