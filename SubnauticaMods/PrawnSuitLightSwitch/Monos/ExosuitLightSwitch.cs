

namespace Ramune.PrawnSuitLightSwitch.Monos
{
    public class ExosuitLightSwitch : MonoBehaviour
    {
        public FMODAsset lightOn = Nautilus.Utility.AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_on");
        public FMODAsset lightOff = Nautilus.Utility.AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_off");
        public Light[] lights;

        public bool on, playSounds, displaySubtitles;

        public void Start()
        {
            Light[] exosuitLights = gameObject.FindChild("lights_parent").GetComponentsInChildren<Light>(true);

            if(exosuitLights != null) lights = exosuitLights;
            else LoggerUtils.LogError("Couldn't find lights for Exosuit!");
        }

        public void Update()
        {
            if(Player.main.inExosuit && GameInput.GetKeyDown(PrawnSuitLightSwitch.config.toggle) && !Cursor.visible)
            {
                on = !on;

                playSounds = PrawnSuitLightSwitch.config.sounds;
                displaySubtitles = PrawnSuitLightSwitch.config.debug;

                if(on) if(playSounds) FMODUWE.PlayOneShot(lightOn, transform.position);
                else if(playSounds) FMODUWE.PlayOneShot(lightOff, transform.position);

                lights.ForEach(li => li.enabled = !on);
                if(displaySubtitles) Subtitles.Add("PRAWN SUIT: " + (on ? "Disabling" : "Enabling") + " lighting systems");
            }
        }
    }
}