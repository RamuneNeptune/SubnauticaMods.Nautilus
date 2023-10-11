

namespace Ramune.NoCrashfish.Patches
{
    [HarmonyPatch(typeof(Creature))]
    public static class CreaturePatch
    {
        [HarmonyPatch(nameof(Creature.Start)), HarmonyPrefix]
        public static bool Start(Creature __instance)
        {
            if(__instance.GetType() != typeof(Crash)) return true;

            GameObject.Destroy(__instance.gameObject);

            return false;
        }
    }
}