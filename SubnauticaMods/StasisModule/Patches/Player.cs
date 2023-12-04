

namespace Ramune.StasisModule.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatch
    {
        [HarmonyPatch(nameof(Player.Update)), HarmonyPostfix]
        public static void Update(Player __instance)
        {
            if(GameInput.GetKeyDown(KeyCode.K))
                Monos.BasicMenu.ShowTeleportMenu();
        }
    }
}