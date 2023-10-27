

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            public static AudioSource screamSource;

            [HarmonyPatch(typeof(LiveMixin), nameof(LiveMixin.Kill)), HarmonyPostfix]
            public static void Kill(LiveMixin __instance)
            {
                var creature = __instance.gameObject.GetComponent<Creature>();

                if(creature is null)
                    return;

                if(screamSource is null)
                    screamSource = __instance.gameObject.EnsureComponent<AudioSource>();

                if(PiracyVariables.Clip_Scream is null)
                    return;

                screamSource.clip = PiracyVariables.Clip_Scream;
                screamSource.Play();
            }
        }
    }
}