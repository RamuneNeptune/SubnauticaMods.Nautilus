

namespace Ramune.PrawnSuitLightSwitch.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    public static class ExosuitPatch
    {
        public static FMODAsset lightOn = AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_on");
        public static FMODAsset lightOff = AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_off");
        public static Light[] lights;
        public static bool on, playSounds, displaySubtitles;


        [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Update)), HarmonyPostfix]
        public static void Update(Exosuit __instance)
        {

            if (Player.main.inExosuit && GameInput.GetKeyDown(PrawnSuitLightSwitch.config.toggle) && !Cursor.visible)
            {
                on = !on;

                playSounds = PrawnSuitLightSwitch.config.sounds;
                displaySubtitles = PrawnSuitLightSwitch.config.debug;

                if(on) if(playSounds) FMODUWE.PlayOneShot(lightOn, __instance.transform.position);
                else if(playSounds) FMODUWE.PlayOneShot(lightOff, __instance.transform.position);

                lights.ForEach(li => li.enabled = !on);
                if (displaySubtitles) Subtitles.Add("PRAWN SUIT: " + (on ? "Disabling" : "Enabling") + " lighting systems");
            }
        }
    }
}