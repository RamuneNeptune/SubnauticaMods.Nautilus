
using SealSubMod.MonoBehaviours;


namespace Ramune.Seal.CustomizableLights.Patches
{
    [HarmonyPatch(typeof(SealSubRoot))]
    public static class SealSubRootPatch
    {
        public static List<Light> seal_floodlights = new();
        public static List<Light> seal_internals = new();

        public static bool debug = false;


        [HarmonyPatch(nameof(SealSubRoot.Start)), HarmonyPostfix]
        public static void Start(SealSubRoot __instance)
        {
            if(debug) LoggerUtils.Screen.LogDebug("SealSubRoot.Start()");

            var floodlightsParent = __instance.gameObject.FindChild("Floodlights");

            if(debug) LoggerUtils.Screen.LogDebug($"Grabbed parent for floodlights");

            if(floodlightsParent is null)
                if(debug) LoggerUtils.Screen.LogError($"Could not find floodlights parent!");

            if(floodlightsParent is not null)
            {
                var floodlights = floodlightsParent.GetComponentsInChildren<Light>(true);

                if(floodlights is not null)
                    seal_floodlights.AddRange(floodlights);
            }

            var internalsParent = __instance.gameObject.FindChild("Scaler/SealSubModelPrefab/Seal Sub");

            var a = __instance.gameObject.FindChild("Scaler");
            var b = a.FindChild("SealSubModelPrefab");
            var c = b.FindChild("Seal Sub");

            if(a is null)
                if(debug) LoggerUtils.Screen.LogError("Scaler is null");
            
            if(b is null)
                if(debug) LoggerUtils.Screen.LogError("Scaler/SealSubModelPrefab is null");
                        
            if(c is null)
                if(debug) LoggerUtils.Screen.LogError("Scaler/SealSubModelPrefab/Seal Sub is null");

            /*
            if(debug) LoggerUtils.Screen.LogDebug($"Grabbed parent for internal lights");

            if(internalsParent is null)
                if(debug) LoggerUtils.Screen.LogError($"Could not find internal lights parent!");
            */

            if(c is not null)
            {
                if(debug) LoggerUtils.Screen.LogSuccess($"Found the parent of all internal lights");

                var internals = c.GetComponentsInChildren<Light>(true);

                if(internals is not null)
                {
                    if(debug) LoggerUtils.Screen.LogSuccess($"Found '{internals.Count()}' internal lights");

                    if(debug) LoggerUtils.Screen.LogDebug($"Purging..");

                    seal_floodlights.ForEach(li =>
                    {
                        if(li.name.StartsWith("Alarm"))
                            seal_floodlights.Remove(li);

                        if(li.name == "fabricatorLight")
                            seal_floodlights.Remove(li);

                        if(li.name == "Light F")
                            seal_floodlights.Remove(li);
                                                
                        if(li.name.StartsWith("Cam"))
                            seal_floodlights.Remove(li);
                    });

                    if(debug) LoggerUtils.Screen.LogDebug($"Purge completed!");

                    if(debug) LoggerUtils.Screen.LogSuccess($"New count: '{internals.Count()}' internal lights");

                    seal_internals.AddRange(internals);
                }
            }

            SealCustomizableLights.config.RefreshFloodlights();
            SealCustomizableLights.config.RefreshInternals();
        }
    }
}