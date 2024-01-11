

namespace Ramune.RadiantDepths.Patches
{
    [HarmonyPatch(typeof(uGUI_OptionsPanel))]
    public static class uGUI_OptionsPanelPatch
    {
        [HarmonyPatch(nameof(uGUI_OptionsPanel.Awake)), HarmonyPostfix]
        public static void Awake(uGUI_OptionsPanel __instance) => RadiantDepths.config.counter = 0;
    }
}