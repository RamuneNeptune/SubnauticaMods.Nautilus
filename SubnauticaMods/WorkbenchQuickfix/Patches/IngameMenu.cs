
using UnityEngine.XR;

namespace Ramune.EscapeClosesPDA.Patches
{
    [HarmonyPatch(typeof(IngameMenu))]
    public static class CraftTreeHandlerPatch
    {
        [HarmonyPatch(nameof(IngameMenu.Open)), HarmonyPrefix]
        public static bool Open(IngameMenu __instance)
        {
            if(Time.timeSinceLevelLoad < 1f) return false;

            if(FreezeTime.PleaseWait) return false;

            if(Player.main.GetPDA().isOpen) return false;
            
            if(!__instance.canBeOpen) return false;

            if(!__instance.gameObject.activeInHierarchy)
            {
                __instance.gameObject.SetActive(true);
                __instance.Select(false);
            }

            if(XRSettings.enabled) HideForScreenshots.Hide(HideForScreenshots.HideType.Mask | HideForScreenshots.HideType.HUD | HideForScreenshots.HideType.ViewModel);

            __instance.ChangeSubscreen("Main");

            return false;
        }
    }
}