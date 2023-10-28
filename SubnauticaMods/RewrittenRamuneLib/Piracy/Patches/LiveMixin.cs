

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            public static AudioSource screamSource;

            [HarmonyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage)), HarmonyPostfix]
            public static void TakeDamage(LiveMixin __instance)
            {
                var creature = __instance.gameObject.GetComponent<Creature>();

                if(creature is null)
                    return;
                
                if(screamSource is null)
                {
                    var go = new GameObject("Scream");
                    go.transform.parent = Player.main.transform;

                    screamSource = go.EnsureComponent<AudioSource>();
                    screamSource.volume = 0.1f;
                }

                if(PiracyVariables.Clip_Scream is null)
                    return;

                screamSource.clip = PiracyVariables.Clip_Scream;
                screamSource.Play();
            }
        }
    }
}