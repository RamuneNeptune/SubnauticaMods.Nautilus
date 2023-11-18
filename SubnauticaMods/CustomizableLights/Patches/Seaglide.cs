

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    public static class SeaglidePatch
    {
        [HarmonyPatch(nameof(Seaglide.Start)), HarmonyPostfix]
        public static void Start(Seaglide __instance)
        {
            Light[] _lights = __instance.gameObject.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 40f, 0.9f, 70f, 53.4f };
            customizableLights.lights = _lights;

            CustomizableLights.config.SeaglideOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.SeaglideOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.SeaglideOnSettingsChange(); 
            CustomizableLights.config.SeaglideOnColorChange();
        }
    }
}