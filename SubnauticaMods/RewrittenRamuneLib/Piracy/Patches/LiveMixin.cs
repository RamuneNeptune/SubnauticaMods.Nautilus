

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static partial class Patches
        {
            public static FMODAsset scream;


            [HarmonyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage)), HarmonyPostfix]
            public static void LiveMixin_TakeDamage(LiveMixin __instance)
            {
                if(!__instance.gameObject.TryGetComponent<Creature>(out _))
                    return;

                if(!__instance.IsAlive())
                {
                    LoggerUtils.Screen.LogWarning("Fish is dead");
                    return;
                }

                if(scream is null)
                {
                    var sound = Nautilus.Utility.AudioUtils.CreateSound(PiracyVariables.Clip_Scream, Nautilus.Utility.AudioUtils.StandardSoundModes_3D);
                    CustomSoundHandler.RegisterCustomSound("FishScream", sound, Nautilus.Utility.AudioUtils.BusPaths.UnderwaterCreatures);
                    scream = Nautilus.Utility.AudioUtils.GetFmodAsset("FishScream");
                }

                CoroutineHost.StartCoroutine(SetupScream(__instance.gameObject, __instance));
            }


            public static IEnumerator SetupScream(GameObject gameObject, LiveMixin livemixin)
            {
                if(PiracyVariables.Clip_Scream is null || livemixin == null || Player.main == null)
                    yield break;

                var go = new GameObject("Screamer");
                go.transform.parent = Player.main.transform;

                var emitter = go.EnsureComponent<FMOD_CustomEmitter>();
                emitter.asset = scream;
                emitter.followParent = true;
                emitter.Play();

                LoggerUtils.Screen.LogSuccess("Fish is screaming");
                GameObject.Destroy(go);
            }
        }
    }
}