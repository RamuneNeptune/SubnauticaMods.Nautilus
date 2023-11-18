

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    public static class ExosuitPatch
    {
        [HarmonyPatch(nameof(Exosuit.Start)), HarmonyPostfix]
        public static void Start(Exosuit __instance)
        {
            Light[] _lights = __instance.gameObject.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 40f, 0.75f, 99f, 80.1f };
            customizableLights.lights = _lights;

            CustomizableLights.config.ExosuitOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.ExosuitOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.ExosuitOnSettingsChange();
            CustomizableLights.config.ExosuitOnColorChange();
        }
    }
}