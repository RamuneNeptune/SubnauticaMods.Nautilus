
using System.Text.RegularExpressions;
using UnityEngine.Events;


namespace Ramune.AchievementUnlocker.Patches
{
    [HarmonyPatch(typeof(uGUI_OptionsPanel))]
    public static class uGUI_OptionsPanelPatches
    {
        public static Button latestButton;

        public static string UnlockerTabName = "Unlocker";

        public static int UnlockerTab;


        [HarmonyPatch(typeof(uGUI_TabbedControlsPanel), nameof(uGUI_TabbedControlsPanel.AddButton)), HarmonyPrefix]
        public static bool AddButtonPrefix(uGUI_TabbedControlsPanel __instance, int tabIndex, string label, UnityAction callback = null)
        {
            Button componentInChildren = __instance.AddItem(tabIndex, __instance.buttonPrefab, label).GetComponentInChildren<Button>();

            if(callback != null)
                componentInChildren.onClick.AddListener(callback);

            latestButton = componentInChildren;

            return false;
        }
            
        
        [HarmonyPatch(typeof(uGUI_TabbedControlsPanel), nameof(uGUI_TabbedControlsPanel.AddButton)), HarmonyPostfix]
        public static void AddButtonPostfix(uGUI_TabbedControlsPanel __instance, int tabIndex, string label, UnityAction callback = null)
        {
            if(tabIndex != UnlockerTab)
                return;

            if(label == "<color=#1ed760><b>Unlock all</b></color>")
                latestButton.image.color = new Color(0f, 0.375f, 0f, 1f);

            else if(label == "<color=#ff4c2d><b>Reset all</b></color>")
                latestButton.image.color = new Color(1f, 0f, 0f, 1f);
        }


        [HarmonyPatch(nameof(uGUI_OptionsPanel.AddTabs)), HarmonyPostfix]
        public static void AddTabs(uGUI_OptionsPanel __instance)
        {
            UnlockerTab = __instance.AddTab(UnlockerTabName);


            __instance.AddHeading(UnlockerTab, "\n<color=#f1c232><b>IMPORTANT:</b></color>\nClick the button below to open the Wiki page for Subnautica Achievements, it will useful to know what achievements you're unlocking"); Divider(__instance);


            __instance.AddButton(UnlockerTab, "Open Achievements Wiki Page\n", () =>
            {
                Process.Start("https://subnautica.fandom.com/wiki/Achievements#Subnautica");
                AchievementUnlocker.logger.LogInfo("Opened Achievements Wiki Page in browser");
            }); Divider(__instance);

            __instance.AddHeading(UnlockerTab, "<color=#f1c232><b>Achievements:</b></color>\nClick any button below to unlock the corresponding achievement\n"); Divider(__instance);


            __instance.AddButton(UnlockerTab, "<color=#1ed760><b>Unlock all</b></color>", () =>
            {
                foreach (GameAchievements.Id achievement in Enum.GetValues(typeof(GameAchievements.Id))) PlatformUtils.main.GetServices().UnlockAchievement(achievement);
                ErrorMessage.AddError("<color=#ffb717>Unlocked:</color> Everything! This may take some time, be patient");

                CoroutineHost.StartCoroutine(PlayClickSound(__instance, "UnlockAll"));
            });


            __instance.AddButton(UnlockerTab, "<color=#ff4c2d><b>Reset all</b></color>", () =>
            {
                PlatformUtils.main.GetServices().ResetAchievements();
                ErrorMessage.AddError("<color=#ffb717>Reset:</color> Everything!");

                CoroutineHost.StartCoroutine(PlayClickSound(__instance, "ResetAll"));
            });


            foreach(GameAchievements.Id achievement in Enum.GetValues(typeof(GameAchievements.Id))) if (achievement != GameAchievements.Id.None) Button(achievement, __instance);
        }


        public static IEnumerator PlayClickSound(uGUI_OptionsPanel __instance, string filename)
        {
            var path = Path.Combine(Variables.Paths.AssetsFolder, filename + ".wav");

            using(UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + path, AudioType.WAV))
            {
                yield return www.SendWebRequest();

                if(www.isNetworkError || www.isHttpError)
                {
                    LoggerUtils.LogError($"Error on 'PlayClickSound({__instance}, {filename})': " + www.error);
                    yield break;
                }

                var comp = __instance.gameObject.GetComponent<AudioSource>();
                bool alreadyHasAudioSource = comp is not null;

                if(alreadyHasAudioSource)
                    GameObject.DestroyImmediate(comp);

                var source = __instance.gameObject.AddComponent<AudioSource>();
                source.clip = DownloadHandlerAudioClip.GetContent(www);
                source.Play();

                while(source.isPlaying)
                    yield return null;

                GameObject.DestroyImmediate(source);
            }
        }


        public static void Button(GameAchievements.Id id, uGUI_OptionsPanel instance)
        {
            var stringID = Regex.Replace(id.ToString(), "(\\B[A-Z])", " $1");

            instance.AddButton(UnlockerTab, stringID, () =>
            {
                PlatformUtils.main.GetServices().UnlockAchievement(id);
                ErrorMessage.AddError($"<color=#ffa618>Unlocked:</color> {stringID}");
            });
        }


        public static void Divider(uGUI_OptionsPanel instance) => instance.AddHeading(UnlockerTab, " ");
    }
}