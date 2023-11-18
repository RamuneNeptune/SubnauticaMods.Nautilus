

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(MapRoomCamera))]
    public static class MapRoomCameraPatch
    {
        [HarmonyPatch(nameof(MapRoomCamera.Start)), HarmonyPostfix]
        public static void Start(MapRoomCamera __instance)
        {
            Light[] _lights = __instance.gameObject.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 80f, 1.5f, 60f, 45f };
            customizableLights.lights = _lights;

            CustomizableLights.config.DroneOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.DroneOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.DroneOnSettingsChange();
            CustomizableLights.config.DroneOnColorChange();
        }
    }
}