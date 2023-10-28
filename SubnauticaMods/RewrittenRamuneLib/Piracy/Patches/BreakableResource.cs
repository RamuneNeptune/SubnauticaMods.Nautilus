

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
                {
                    var go = new GameObject("Pop");
                    go.transform.parent = Player.main.transform;

                    popSource = go.EnsureComponent<AudioSource>();
                    screamSource.volume = 1f;
                }

                if(PiracyVariables.Clip_Pop is null)
                    return;

                popSource.clip = PiracyVariables.Clip_Pop;
                popSource.Play();

                if(UnityEngine.Random.value <= 0.08f); // To be implemented
            }
        }
    }
}