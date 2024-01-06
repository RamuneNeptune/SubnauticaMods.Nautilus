

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static class Core
        {
            public static void HackTheMainframe()
            {
                LoggerUtils.LogInfo(">> Ahoy matey!");

                CoroutineHost.StartCoroutine(Logger());

                CoroutineHost.StartCoroutine(GetAudioClips());

                PatchingUtils.ApplyPatch(typeof(Player), nameof(Player.Awake), new(typeof(Patches), nameof(Patches.Player_Awake)), HarmonyPatchType.Postfix);

                PatchingUtils.ApplyPatch(typeof(BatteryCharger), nameof(BatteryCharger.Initialize), new(typeof(Patches), nameof(Patches.BatteryCharger_Initialize)), HarmonyPatchType.Postfix);

                PatchingUtils.ApplyPatch(typeof(PowerCellCharger), nameof(PowerCellCharger.Initialize), new(typeof(Patches), nameof(Patches.PowerCellCharger_Initialize)), HarmonyPatchType.Postfix);

                PatchingUtils.ApplyPatch(typeof(LiveMixin), nameof(LiveMixin.TakeDamage), new(typeof(Patches), nameof(Patches.LiveMixin_TakeDamage)), HarmonyPatchType.Postfix);

                PatchingUtils.ApplyPatch(typeof(SoundSystem), nameof(SoundSystem.SetMusicVolume), new(typeof(Patches), nameof(Patches.SoundSystem_SetMusicVolume)), HarmonyPatchType.Postfix);

                PatchingUtils.ApplyPatch(typeof(BreakableResource), nameof(BreakableResource.BreakIntoResources), new(typeof(Patches), nameof(Patches.BreakableResource_BreakIntoResources)), HarmonyPatchType.Postfix);
            }


            public static IEnumerator Logger()
            {
                while(true)
                {
                    yield return new WaitForSeconds(1f);

                    //LoggerUtils.Screen.LogMessage(PiracyVariables.PiracyMessages);
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