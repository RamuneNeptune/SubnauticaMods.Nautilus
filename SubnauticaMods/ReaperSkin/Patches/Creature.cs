
using DroneBuddy.MonoBehaviours;


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


    [HarmonyPatch(typeof(MapRoomCamera))]
    public static class MapRoomCameraPatch
    {
        public static Texture2D Texture = ImageUtils.GetTexture("Base_Exterior_Map_Room");

        [HarmonyPatch(nameof(MapRoomCamera.Start)), HarmonyPostfix]
        public static void Start(MapRoomCamera __instance)
        {
            LoggerUtils.LogFatal("MapRoomCamera.Start: Start");

            if(!__instance.gameObject.TryGetComponent<Drone>(out var drone))
                return;

            LoggerUtils.LogFatal("MapRoomCamera.Start: This is a drone buddy!");

            if (__instance.gameObject.TryGetComponentInChildren<Renderer>(out var renderer, true))
                renderer.SetTexture(new[] { TextureType.Main, TextureType.Specular }, Texture);

            LoggerUtils.LogFatal("MapRoomCamera.Start: Set textures");
        }
    }
}