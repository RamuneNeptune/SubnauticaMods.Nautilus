

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(SubRoot))]
    public static class SubRootPatch
    {
        [HarmonyPatch(nameof(SubRoot.Start)), HarmonyPostfix]
        public static void Start(SubRoot __instance)
        {
            if(!__instance.isCyclops)
                return;

            GameObject floodlights = __instance.gameObject.FindChild("Floodlights");

            if(floodlights is null)
                return;

            Light[] _lights = floodlights.GetComponentsInChildren<Light>(true);

            if(_lights.Length == 0)
                return;

            var customizableLights = __instance.gameObject.EnsureComponent<Monos.CustomizableLights>();
            customizableLights.defaults = new float[] { 70f, 2f, 65f, 49f };
            customizableLights.lights = _lights;

            CustomizableLights.config.CyclopsOnSettingsChangeEvent += customizableLights.OnSettingsChange;
            CustomizableLights.config.CyclopsOnColorChangeEvent += customizableLights.OnColorChange;
            CustomizableLights.config.CyclopsOnSettingsChange();
            CustomizableLights.config.CyclopsOnColorChange();
        }
    }
}