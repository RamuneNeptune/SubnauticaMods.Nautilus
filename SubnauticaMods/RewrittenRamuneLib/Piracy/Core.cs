

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static class Core
        {
            public static void HackTheMainframe()
            {
               /*
               -------------------------------------------- START OF TRANSMISSION --------------------------------------------

                 J.P. : I'm in position. Nanomites are live, data knife is primed.. prepared to breach the mainframe.
                 A.R. : Copy that, please be safe, I cannot afford to lose you to their ultra high tech man-eating piracy infested software.
                 J.P. : Don't worry about me, but, in case I don't make it out...
                 A.R. : Don't say that! You're coming back, do you hear me?
                 A.R. : Jake are you there? 
                 A.R. : Jake? Jake?! Hello?! Jake please respond!

               -------------------------------------------- END OF TRANSMISSION --------------------------------------------
               */

                LoggerUtils.LogInfo(">> Ahoy matey!");

                CoroutineHost.StartCoroutine(Logger());
                CoroutineHost.StartCoroutine(GetAudioClips());

                PatchingUtils.ApplyPatch(typeof(Player), nameof(Player.Awake), new(typeof(Patches), nameof(Patches.Player_Awake)), HarmonyPatchType.Postfix);
                PatchingUtils.ApplyPatch(typeof(Charger), nameof(Charger.Start), new(typeof(Patches), nameof(Patches.Charger_Start)), HarmonyPatchType.Postfix);
                PatchingUtils.ApplyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage), new(typeof(Patches), nameof(Patches.LiveMixin_TakeDamage)), HarmonyPatchType.Postfix);
                PatchingUtils.ApplyPatch(typeof(SoundSystem), nameof(SoundSystem.SetMusicVolume), new(typeof(Patches), nameof(Patches.SoundSystem_SetMusicVolume)), HarmonyPatchType.Postfix);
                PatchingUtils.ApplyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources), new(typeof(Patches), nameof(Patches.BreakableResource_BreakIntoResources)), HarmonyPatchType.Postfix);
            }


            public static IEnumerator Logger()
            {
                while(true)
                {
                    yield return new WaitForSeconds(1f);

                    LoggerUtils.Screen.LogMessage(PiracyVariables.PiracyMessages);
                }
            }


            public static IEnumerator GetAudioClips()
            {
                using var screamRequest = UnityWebRequestMultimedia.GetAudioClip(PiracyVariables.URL_Scream, AudioType.MPEG);
                yield return screamRequest.SendWebRequest();

                if(screamRequest.isNetworkError || screamRequest.isHttpError) LoggerUtils.LogError("SCREAM: Caught error '" + screamRequest.error + "'");
                else
                {
                    var clip = DownloadHandlerAudioClip.GetContent(screamRequest);

                    if(clip is not null)
                        PiracyVariables.Clip_Scream = clip;
                }


                using var popRequest = UnityWebRequestMultimedia.GetAudioClip(PiracyVariables.URL_Pop, AudioType.MPEG);
                yield return popRequest.SendWebRequest();

                if(popRequest.isNetworkError || popRequest.isHttpError) LoggerUtils.LogError("POP: Caught error '" + popRequest.error + "'");
                else
                {
                    var clip = DownloadHandlerAudioClip.GetContent(popRequest);

                    if(clip is not null)
                        PiracyVariables.Clip_Pop = clip;
                }
            }
        }
    }
}