

namespace Ramune.ToggleSilentRiggingLights.Patches
{
    [HarmonyPatch(typeof(SubFloodAlarm))]
    public static class SubFloodAlarmPatch
    {
        [HarmonyPatch(nameof(SubFloodAlarm.NewAlarmState)), HarmonyPostfix]
        public static void Start(SubFloodAlarm __instance)
        {
            if(!__instance.sub.isCyclops)
                return;

            if(!__instance.sub.fireSuppressionState && !__instance.sub.subWarning && !__instance.sub.silentRunning)
                return;

            __instance.SetAlarmLightsActive(true);
            __instance.SetAlarmLightPulseState(false);
            __instance.SetAlarmLightColor(ToggleSilentRiggingLights.config.color);
        }
    }
}