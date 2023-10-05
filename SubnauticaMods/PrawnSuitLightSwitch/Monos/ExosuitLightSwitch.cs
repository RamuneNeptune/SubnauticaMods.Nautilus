

namespace Ramune.PrawnSuitLightSwitch.Monos
{
    public class ExosuitLightSwitch : MonoBehaviour
    {
        public FMODAsset lightOn = AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_on");
        public FMODAsset lightOff = AudioUtils.GetFmodAsset("event:/sub/seamoth/seamoth_light_off");
        public Light[] lights;

        public bool on, playSounds, displaySubtitles;

        public void Start()
        {
            Light[] exosuitLights = gameObject.FindChild("lights_parent").GetComponentsInChildren<Light>(true);

            if(exosuitLights != null) lights = exosuitLights;
            else Logger.LogInternal("Couldn't find lights for Exosuit!", LogLevel.Error);
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