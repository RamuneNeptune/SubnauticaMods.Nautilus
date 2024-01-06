

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            public static AudioSource popSource;

            [HarmonyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources)), HarmonyPostfix]
            public static void BreakableResource_BreakIntoResources(BreakableResource __instance)
            {
                if(popSource is null)
                {
                    var go = new GameObject("Pop");
                    go.transform.parent = Player.main.transform;

                    popSource = go.EnsureComponent<AudioSource>();
                    popSource.volume = 1f;
                }

                if(PiracyVariables.Clip_Pop is null)
                    return;

                popSource.clip = PiracyVariables.Clip_Pop;
                popSource.Play();

                if(UnityEngine.Random.value <= 0.1f)
                    DevConsole.SendConsoleCommand("spawn crash");
            }
        }
    }
}