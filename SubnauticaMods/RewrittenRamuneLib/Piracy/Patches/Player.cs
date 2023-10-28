

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            [HarmonyPatch(typeof(Player), nameof(Player.Awake)), HarmonyPostfix]
            public static void Awake(Player __instance)
            {
                __instance.gameObject.EnsureComponent<Monos.PirateTunes>();
            }
        }
    }
}