

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
            if(__instance.name is not "ReaperLeviathan(Clone)")
                return;

            var renderer = __instance.gameObject.GetComponentInChildren<Renderer>(true);

            if(renderer is null)
                return;

            renderer.material.SetTexture(ShaderPropertyID._MainTex, Main);
            renderer.material.SetTexture(ShaderPropertyID._SpecTex, Main);
            renderer.material.SetTexture(ShaderPropertyID._Illum, Emissive);
            renderer.material.SetFloat(ShaderPropertyID._GlowStrength, 0.5f);
            renderer.material.SetFloat(ShaderPropertyID._GlowStrengthNight, 0.5f);
            renderer.materials[1].SetTexture(ShaderPropertyID._MainTex, Main);
            renderer.materials[1].SetTexture(ShaderPropertyID._SpecTex, Main);
            renderer.materials[1].SetTexture(ShaderPropertyID._Illum, Emissive);
            renderer.materials[1].SetFloat(ShaderPropertyID._GlowStrength, 0.5f);
            renderer.materials[1].SetFloat(ShaderPropertyID._GlowStrengthNight, 0.5f);
        }
    }
}