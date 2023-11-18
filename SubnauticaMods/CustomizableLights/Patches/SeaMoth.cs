

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(SeaMoth))]
    public static class SeaMothPatch
    {
        [HarmonyPatch(nameof(SeaMoth.Start)), HarmonyPostfix]
        public static void Start(SeaMoth __instance)
        {
            Light[] _lights = __instance.gameObject.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 100f, 1.5f, 50f, 53.4f };
            customizableLights.lights = _lights;

            CustomizableLights.config.SeamothOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.SeamothOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.SeamothOnSettingsChange();
            CustomizableLights.config.SeamothOnColorChange();
        }
    }
}