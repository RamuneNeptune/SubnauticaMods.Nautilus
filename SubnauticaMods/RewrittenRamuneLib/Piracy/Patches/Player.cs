

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            [HarmonyPatch(typeof(Player), nameof(Player.Awake)), HarmonyPostfix]
            public static void Awake(Player __instance)
            {
                LoggerUtils.LogFatal(" >> --------------- [1/2] Player.Start");

                __instance.gameObject.EnsureComponent<Monos.PirateTunes>();

                LoggerUtils.LogFatal(" >> --------------- [2/2] Player.Start");
            }
        }
    }
}