

namespace Ramune.PrawnSuitLightSwitch.Patches
{
    [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Awake))]
    public static class ExosuitPatch
    {
        public static void Postfix(Exosuit __instance)
        {
            __instance.gameObject.EnsureComponent<Monos.ExosuitLightSwitch>();
        }
    }
}