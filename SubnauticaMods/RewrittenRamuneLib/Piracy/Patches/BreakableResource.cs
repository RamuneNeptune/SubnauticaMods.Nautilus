

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            public static AudioSource popSource;

            [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPostfix]
            public static void BreakIntoResources(BreakableResource __instance)
            {
                if(popSource is null)
                    popSource = Player.main.gameObject.EnsureComponent<AudioSource>();

                if(PiracyVariables.Clip_Pop is null)
                    return;

                popSource.clip = PiracyVariables.Clip_Pop;
                popSource.Play();
            }
        }
    }
}