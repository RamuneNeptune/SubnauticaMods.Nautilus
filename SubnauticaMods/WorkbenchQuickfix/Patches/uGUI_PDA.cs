

namespace Ramune.EscapeClosesPDA.Patches
{
    [HarmonyPatch(typeof(uGUI_PDA))]
    public static class uGUI_PDA_Patch
    {
        [HarmonyPatch(nameof(uGUI_PDA.Update)), HarmonyPostfix]
        public static void Update(uGUI_PDA __instance)
        {
            if(GameInput.GetKeyDown(KeyCode.Escape)) Player.main.GetPDA().Close();
        }
    }
}