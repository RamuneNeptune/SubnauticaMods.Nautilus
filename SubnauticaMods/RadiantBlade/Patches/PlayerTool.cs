

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

    [HarmonyPatch(typeof(CuteFish), nameof(CuteFish.Start))]
    public static class CuteFish_Start
    {
        public static void Postfix(CuteFish __instance)
        {
            var ren = __instance.GetComponentInChildren<SkinnedMeshRenderer>(true);
            ren.material.SetTexture(ShaderPropertyID._MainTex, Utilities.GetTexture("Cutefish"));
            ren.material.SetTexture(ShaderPropertyID._SpecTex, Utilities.GetTexture("Cutefish"));
        }
    }
}