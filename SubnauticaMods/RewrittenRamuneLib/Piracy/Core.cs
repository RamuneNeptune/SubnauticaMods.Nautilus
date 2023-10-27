

using System.Security.Policy;
using static uGUI_ResourceTracker;
using static UnityEngine.SpookyHash;

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

                 J.P. : Amy, I'm in position. Nanomites are live, data knife is primed.. prepared to breach the mainframe.
                 A.S. : Copy that, please be safe, I cannot afford to lose you to their ultra high tech man-eating antivirus software.
                 J.P. : Don't worry about me Amy, but, in case I don't make it out...
                 A.S. : Jake, don't say that! You're coming back, do you hear me?
                 A.S. : Jake are you there? 
                 A.S. : Jake?.. Jake? Hello? Jake please respond!
                 ???  : ┣ ▚ ▛▄┅┗▖ ▖┛▀┗▞┃┏▄ ▛┏┗▄

                 -------------------------------------------- END OF TRANSMISSION --------------------------------------------

                */

                LoggerUtils.LogInfo(">> Ahoy' matey!");

                CoroutineHost.StartCoroutine(Logger());
                CoroutineHost.StartCoroutine(GetAudioClips());

                PatchingUtils.RunSpecificPatch(typeof(Player), nameof(Player.Awake), new(typeof(Patches), nameof(Patches.Awake)), HarmonyPatchType.Postfix);
                PatchingUtils.RunSpecificPatch(typeof(LiveMixin), nameof(LiveMixin.Kill), new(typeof(Patches), nameof(Patches.Kill)), HarmonyPatchType.Postfix);

                var techTypes = Enum.GetValues(typeof(TechType));

                foreach(TechType techType in techTypes)
                {
                    var random = new System.Random();
                    var randomIndex = random.Next(techTypes.Length); 

                    TechType randomTechType = (TechType)techTypes.GetValue(randomIndex);

                    CraftDataHandler.SetCraftingTime(techType, 5f);
                    LanguageHandler.SetTechTypeName(techType, RandomString("RAMUNERamune", 5));
                    LanguageHandler.SetTechTypeTooltip(techType, RandomString("NEPTUNEneptune", 7));
                    SpriteHandler.RegisterSprite(techType, SpriteManager.Get(randomTechType));
                }
            }


            public static IEnumerator Logger()
            {
                while(true)
                {
                    yield return new WaitForSeconds(1f);
                    LoggerUtils.LogScreen("<color=#ffba1d><b>LeviathanKraken</b> says:</color> Luffy approves!");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>RamuneNeptune</b> says:</color> Avast, ye scallywag!");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Dreamanchik</b> says:</color> ⚠ goober");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Aftershock</b> says:</color> You son of a motherless goat!");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Unknown</b> says:</color> Your mother");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Cookie</b> says:</color> Hands off my booty, go walk the plank!");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Al-An</b> says:</color> <i>angry architecht noises</i>");
                    LoggerUtils.LogScreen("<color=#ffba1d><b>Ray</b> says:</color> Thieving scoundrel");
                }
            }


            public static string RandomString(string characters, int length)
            {
                var random = new System.Random();

                return new string(Enumerable.Repeat(characters, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }


            public static IEnumerator GetAudioClips()
            {
                using var screamRequest = UnityWebRequestMultimedia.GetAudioClip(PiracyVariables.URL_Scream, AudioType.MPEG);
                LoggerUtils.LogFatal(">> SCREAM: Sending request");

                yield return screamRequest.SendWebRequest();
                LoggerUtils.LogFatal(">> SCREAM: Sending request");

                if(screamRequest.isNetworkError || screamRequest.isHttpError) LoggerUtils.LogError("SCREAM: Error, '" + screamRequest.error + "'");
                else
                {
                    var clip = DownloadHandlerAudioClip.GetContent(screamRequest);
                    LoggerUtils.LogFatal(">> SCREAM: Got clip");

                    if(clip is not null)
                        PiracyVariables.Clip_Scream = clip;

                    LoggerUtils.LogFatal(">> SCREAM: Set clip");

                    LoggerUtils.LogFatal($">> SCREAM: Clip info, length = '{clip.length}', channels = {clip.channels}, name = {clip.name}");
                }


                using var popRequest = UnityWebRequestMultimedia.GetAudioClip(PiracyVariables.URL_Pop, AudioType.MPEG);
                LoggerUtils.LogFatal(">> POP: Sending request");

                yield return popRequest.SendWebRequest();
                LoggerUtils.LogFatal(">> POP: Got request");

                if(popRequest.isNetworkError || popRequest.isHttpError) LoggerUtils.LogError("POP: Error, '" + popRequest.error + "'");
                else
                {
                    var clip = DownloadHandlerAudioClip.GetContent(popRequest);
                    LoggerUtils.LogFatal(">> POP: Got clip");

                    if(clip is not null)
                        PiracyVariables.Clip_Pop = clip;

                    LoggerUtils.LogFatal(">> POP: Set clip");

                    LoggerUtils.LogFatal($">> POP: Clip info, length = '{clip.length}', channels = {clip.channels}, name = {clip.name}");
                }
            }
        }
    }
}