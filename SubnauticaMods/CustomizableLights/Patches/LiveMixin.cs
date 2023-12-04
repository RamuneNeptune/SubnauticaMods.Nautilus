

namespace Ramune.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(LiveMixin))]
    public static class LiveMixinPatch
    {
        [HarmonyPatch(nameof(LiveMixin.Kill)), HarmonyPrefix]
        public static void Kill(LiveMixin __instance, DamageType damageType = DamageType.Normal)
        {
            var cam = __instance.gameObject.GetComponent<MapRoomCamera>();
            var veh = __instance.gameObject.GetComponent<Vehicle>();
            var cl = __instance.gameObject.GetComponent<Monos.CustomizableLights>();
                        
            if(cl is null) 
                return;

            if(cam is not null)
            {
                CustomizableLights.config.DroneOnSettingsChangeEvent -= cl.OnSettingsChange;
                CustomizableLights.config.DroneOnColorChangeEvent -= cl.OnColorChange;
                return;
            }

            if(veh is not null)
            {
                switch (veh.GetType().FullName)
                {
                    case string SMType when SMType == typeof(SeaMoth).FullName:
                        CustomizableLights.config.SeamothOnSettingsChangeEvent -= cl.OnSettingsChange;
                        CustomizableLights.config.SeamothOnColorChangeEvent -= cl.OnColorChange;
                        break;


                    case string EXType when EXType == typeof(Exosuit).FullName:
                        CustomizableLights.config.ExosuitOnSettingsChangeEvent -= cl.OnSettingsChange;
                        CustomizableLights.config.ExosuitOnColorChangeEvent -= cl.OnColorChange;
                        break;


                    case string CYType when CYType == typeof(SubRoot).FullName:
                        CustomizableLights.config.CyclopsOnSettingsChangeEvent -= cl.OnSettingsChange;
                        CustomizableLights.config.CyclopsOnColorChangeEvent -= cl.OnColorChange;
                        break;
                }
                return;
            }
        }
    }
}