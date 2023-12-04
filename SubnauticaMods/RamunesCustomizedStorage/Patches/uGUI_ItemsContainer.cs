

namespace Ramune.RamunesCustomizedStorage.Patches
{
    [HarmonyPatch(typeof(uGUI_ItemsContainer))]
    public static class uGUI_ItemsContainerPatch
    {
        [HarmonyPatch(nameof(uGUI_ItemsContainer.OnResize)), HarmonyPostfix]
        public static void OnResize(uGUI_ItemsContainer __instance, int width, int height)
        {
            float x = __instance.rectTransform.anchoredPosition.x;

            if(height == 9)
                __instance.rectTransform.anchoredPosition = new Vector2(x, -39f);

            else if(height == 10)
                __instance.rectTransform.anchoredPosition = new Vector2(x, -75);

            else
                __instance.rectTransform.anchoredPosition = new Vector2(x, -4);

            __instance.rectTransform.anchoredPosition = new Vector2(Mathf.Sign(x) * (width == 8 ? 292f : 284f), __instance.rectTransform.anchoredPosition.y);
        }
    }
}