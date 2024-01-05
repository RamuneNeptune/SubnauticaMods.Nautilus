

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
                .SetTexture(new[] { TextureType.Main, TextureType.Specular, TextureType.Illum }, Main, 0, 1)
                .SetGlowStrength(0.5f, 0, 1);
        }
    }
}