

namespace Ramune.SeamothSprint.Patches
{
    [HarmonyPatch(typeof(SeaMoth))]
    public static class SeaMoth_Patches
    {
        [HarmonyPatch(nameof(SeaMoth.Start)), HarmonyPostfix]
        public static void Start(SeaMoth __instance)
        {
            __instance.gameObject.EnsureComponent<Monos.SeamothSprintController>();
        }
    }
}