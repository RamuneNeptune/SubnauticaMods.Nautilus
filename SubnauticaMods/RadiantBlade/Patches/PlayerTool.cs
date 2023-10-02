

namespace Ramune.RadiantBlade.Patches
{
    [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.animToolName), MethodType.Getter)]
    public static class PlayerToolPatch
    {
        public static void Postfix(PlayerTool __instance, ref string __result)
        {
            if(__instance.pickupable?.GetTechType() == Items.RadiantBlade.Prefab.Info.TechType) __result = "knife";
        }
    }
}