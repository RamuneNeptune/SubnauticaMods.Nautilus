

using HarmonyLib;

namespace Ramune.OxygenCanisters.Patches
{
    [HarmonyPatch(typeof(Player))]
    public static class PlayerPatch
    {
        [HarmonyPatch(nameof(Player.Awake)), HarmonyPostfix]
        public static void Awake(Player __instance)
        {

        }
    }
}