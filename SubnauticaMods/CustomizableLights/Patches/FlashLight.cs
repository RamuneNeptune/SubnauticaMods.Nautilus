

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(FlashLight))]
    public static class FlashLightPatch
    {
        [HarmonyPatch(nameof(FlashLight.Start)), HarmonyPostfix]
        public static void Start(FlashLight __instance)
        {
            Light[] _lights = __instance.gameObject.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            _lights = _lights.Where(light => light is not null && light.name is not "flashlight spotlight").ToArray();

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 50f, 1f, 90f, 71.4f };
            customizableLights.lights = _lights;

            CustomizableLights.config.FlashlightOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.FlashlightOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.FlashlightOnSettingsChange();
            CustomizableLights.config.FlashlightOnColorChange();
        }
    }
}