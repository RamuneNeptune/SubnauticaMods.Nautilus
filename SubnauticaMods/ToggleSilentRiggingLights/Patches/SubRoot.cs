

namespace Ramune.ToggleSilentRiggingLights.Patches
{
    [HarmonyPatch(typeof(SubRoot))]
    public static class SubRootPatch
    {
        public static List<SubFloodAlarm> subFloodAlarms = new();

        [HarmonyPatch(nameof(SubRoot.Start)), HarmonyPostfix]
        public static void Start(SubRoot __instance)
        {
            if(!__instance.isCyclops)
                return;

            var subFloodAlarm = __instance.GetComponentInChildren<SubFloodAlarm>(true);

            if(!subFloodAlarms.Contains(subFloodAlarm))
                subFloodAlarms.Add(subFloodAlarm);
        }
    }
}