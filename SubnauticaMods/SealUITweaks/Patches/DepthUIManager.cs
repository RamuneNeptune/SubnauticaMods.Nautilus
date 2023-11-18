

namespace Ramune.Seal.UITweaks.Patches
{
    [HarmonyPatch(typeof(DepthUIManager))]
    public static class DepthUIManagerPatch
    {
        public static SealSubRoot subRoot;
        public static Color color;


        [HarmonyPatch(nameof(DepthUIManager.UpdateUI)), HarmonyPrefix]
        public static bool UpdateUI(DepthUIManager __instance)
        {
            if(!SealUITweaks.config.displayAltitude)
                return true;

            subRoot ??= __instance.GetComponentInParent<SealSubRoot>();

            int maxDepth = (int)__instance.crushDamage.crushDepth;
            int depthOrAltitude = (int)subRoot.transform.position.y;

            _ = depthOrAltitude >= maxDepth ? color = Color.red : color = Color.white;
            
            if(__instance.lastDisplayedDepth != depthOrAltitude || __instance.lastDisplayedCrushDepth != maxDepth)
            {
                __instance.lastDisplayedDepth = depthOrAltitude;
                __instance.lastDisplayedCrushDepth = maxDepth;

                bool inAir = depthOrAltitude >= 1;

                __instance.depthText.text = $"{Mathf.Abs(depthOrAltitude)}m{(inAir ? "<color=#ffc600>^</color>" : "")} / {maxDepth}m";
            }
            __instance.depthText.color = color;


            return false;
        }
    }
}