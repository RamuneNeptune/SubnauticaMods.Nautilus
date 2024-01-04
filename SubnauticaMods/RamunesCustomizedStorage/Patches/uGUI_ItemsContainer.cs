

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(uGUI_ItemsContainer))]
    public static class uGUI_ItemsContainerPatch
    {
        [HarmonyPatch(nameof(uGUI_ItemsContainer.OnResize)), HarmonyPostfix]
        public static void OnResize(uGUI_ItemsContainer __instance, int width, int height)
        {
            float x = __instance.rectTransform.anchoredPosition.x;

            __instance.rectTransform.anchoredPosition = new Vector2(Mathf.Sign(x) * (width == 8 ? 292f : 284f), 
                (height == 9) ? -39f :        // if height is 9:       new Vector2(x, -39f)
                (height == 10) ? -75f : -4f); // if height is 10:      new Vector2(x, -75f)
                                              // if height is neither: new Vector2(x, -4f)
        }
    }
}