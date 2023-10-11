

namespace Ramune.PassiveWarpersAfterQuarantineShutdown.Patches
{
    [HarmonyPatch(typeof(Creature))]
    public static class CreaturePatch
    {
        [HarmonyPatch(nameof(Creature.Start)), HarmonyPostfix]
        public static void Start(Creature __instance)
        {
            if(__instance.GetType() != typeof(Warper)) return;

            __instance.gameObject.EnsureComponent<Monos.WarperBefriender>();
        }
    }
}