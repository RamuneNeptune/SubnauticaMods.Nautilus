

using System.Xml.Linq;

namespace Ramune.RamunesTextureUpscales.Patches
{
    [HarmonyPatch(typeof(PlayerTool), (nameof(PlayerTool.Awake)))]
    public static class PlayerToolPatch
    {
        public static MeshRenderer meshRenderer;
        public static SkinnedMeshRenderer skinnedMeshRenderer;

        [HarmonyPostfix]
        public static void Awake(PlayerTool __instance)
        {
            switch(__instance.pickupable?.GetTechType())
            {
                case TechType.Flashlight:
                    Logger.Log(" >> [1] << Patching Flashlight", LogLevel.Error);
                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "flashlight_batt_rig_Flashlight");
                    Logger.Log(" >> [2] << Set renderer for Flashlight", LogLevel.Error);
                    Utils.ApplyUpscaling(skinnedMeshRenderer, "Flashlight");
                    Logger.Log(" >> [3] << Applied upscaling to Flashlight\n\n", LogLevel.Error);
                    break;

                case TechType.Scanner:
                    Logger.Log(" >> [1] << Patching Scanner", LogLevel.Error);
                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "scanner_geo");
                    Logger.Log(" >> [2] << Set renderer for Scanner", LogLevel.Error);
                    Utils.ApplyUpscaling(skinnedMeshRenderer, "Scanner");
                    Logger.Log(" >> [3] << Applied upscaling to Scanner\n\n", LogLevel.Error);
                    break;

                case TechType.Builder:
                    Logger.Log(" >> [1] << Patching Builder", LogLevel.Error);

                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "builder_geo");
                    Logger.Log(" >> [2] << Set renderer for Builder", LogLevel.Error);

                    Utils.ApplyUpscaling(skinnedMeshRenderer, "Builder");
                    Logger.Log(" >> [3] << Applied upscaling to Builder\n\n", LogLevel.Error);
                    break;

                case TechType.Welder:
                    Logger.Log(" >> [1] << Patching Welder", LogLevel.Error);
                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "welder_geos");
                    Logger.Log(" >> [2] << Set renderer for Welder", LogLevel.Error);
                    Utils.ApplyUpscaling(skinnedMeshRenderer, "Welder");
                    Logger.Log(" >> [3] << Applied upscaling to Welder\n\n", LogLevel.Error);
                    break;

                case TechType.Knife:
                    Logger.Log(" >> [1] << Patching Knife", LogLevel.Error);
                    meshRenderer = __instance.gameObject.GetComponentInChildren<MeshRenderer>(true);
                    Logger.Log(" >> [2] << Set renderer for Knife", LogLevel.Error);
                    Utils.ApplyUpscaling(meshRenderer, "Knife");
                    Logger.Log(" >> [3] << Applied upscaling to Knife\n\n", LogLevel.Error);
                    break;

                case TechType.HeatBlade:
                    Logger.Log(" >> [1] << Patching HeatBlade", LogLevel.Error);
                    meshRenderer = __instance.gameObject.GetComponentInChildren<MeshRenderer>(true);
                    Logger.Log(" >> [2] << Set renderer for HeatBlade", LogLevel.Error);
                    Utils.ApplyUpscaling(meshRenderer, "HeatBlade");
                    Logger.Log(" >> [3] << Applied upscaling to HeatBlade\n\n", LogLevel.Error);
                    break;

                case TechType.Flare:
                    Logger.Log(" >> [1] << Patching Flare", LogLevel.Error);
                    meshRenderer = __instance.gameObject.GetComponentInChildren<MeshRenderer>(true);
                    Logger.Log(" >> [2] << Set renderer for Flare", LogLevel.Error);
                    Utils.ApplyUpscaling(meshRenderer, "Flare");
                    Logger.Log(" >> [3] << Applied upscaling to Flare\n\n", LogLevel.Error);
                    break;

                case TechType.StasisRifle:
                    Logger.Log(" >> [1] << Patching StasisRifle", LogLevel.Error);
                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "stasis_rifle_geo");
                    Logger.Log(" >> [2] << Set renderer for StasisRifle", LogLevel.Error);
                    Utils.ApplyUpscaling(skinnedMeshRenderer, "StasisRifle");
                    Logger.Log(" >> [3] << Applied upscaling to StasisRifle\n\n", LogLevel.Error);

                    break;

                case TechType.PropulsionCannon:
                    Logger.Log(" >> [1] << Patching PropCannon", LogLevel.Error);
                    skinnedMeshRenderer = __instance.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true).First(x => x.name == "Propulsion_Cannon_geo");
                    Logger.Log(" >> [2] << Set renderer for PropCannon", LogLevel.Error);
                    Utils.ApplyUpscaling(skinnedMeshRenderer, "PropCannon");
                    Logger.Log(" >> [3] << Applied upscaling to PropCannon\n\n", LogLevel.Error);
                    break;
            }
        }
    }
}