

namespace Ramune.ReaperGoldSkin.Patches
{
    [HarmonyPatch(typeof(Creature))]
    public static class CreaturePatch
    {
        public static Texture2D Main = ImageUtils.GetTexture("Reaper");
        public static Texture2D Emissive = ImageUtils.GetTexture("ReaperEmissive");


        [HarmonyPatch(nameof(Creature.Start)), HarmonyPostfix]
        public static void Start(Creature __instance)
        {
            if(__instance is not ReaperLeviathan)
                return;

            if(!__instance.gameObject.TryGetComponentInChildren<Renderer>(out var renderer, true))
                return;

            renderer
                .MultiSetTexture(TextureType.Main, Main, 0, 1)
                .MultiSetTexture(TextureType.Specular, Main, 0, 1)
                .MultiSetTexture(TextureType.Illum, Emissive, 0, 1)
                .MultiSetGlowStrength(0.5f, 0, 1);
        }
    }
}