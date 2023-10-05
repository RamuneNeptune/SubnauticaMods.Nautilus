

namespace Ramune.SeaglideUpgrades.Patches
{
    [HarmonyPatch(typeof(PlayerTool))]
    public static class PlayerToolPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerTool), nameof(PlayerTool.animToolName), MethodType.Getter)]
        public static void Postfix(PlayerTool __instance, ref string __result)
        {
            if(__instance.pickupable?.GetTechType() == Items.SeaglideMK1.Prefab.Info.TechType) __result = "seaglide";
            if(__instance.pickupable?.GetTechType() == Items.SeaglideMK2.Prefab.Info.TechType) __result = "seaglide";
            if(__instance.pickupable?.GetTechType() == Items.SeaglideMK3.Prefab.Info.TechType) __result = "seaglide";
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(PlayerTool.OnDraw))]
        public static void OnDraw(PlayerTool __instance)
        {
            if (__instance.pickupable?.GetTechType() == TechType.Seaglide)
            {
                Player.main.playerController.seaglideForwardMaxSpeed = 25f;
                Player.main.playerController.seaglideWaterAcceleration = 36.56f;
            }
        }
    }
}