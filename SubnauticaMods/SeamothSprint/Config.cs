

namespace Ramune.SeamothSprint
{
    [Menu("Seamoth Sprint")]
    public class Config : ConfigFile
    {
        [Toggle("Enable this mod", Order = 1)]
        public bool isEnabled = true;

        [Toggle("Enable insanity (boost speed multipler will be tripled)", Order = 2)]
        public bool isInsanity = false;

        [Slider("Boost speed multiplier", Format = "{0:0.0}x", DefaultValue = 1.5f, Min = 1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 3)]
        public float speedMultiplier = 1.5f;

        [Slider("Boost energy usage multiplier", Format = "{0:0.0}x", DefaultValue = 2f, Min = 1f, Max = 10f, Step = 0.1f, Tooltip = "Changes are applied automatically", Order = 4)]
        public float energyMultiplier = 2f;

        [Keybind("Boost keybind", Order = 5)]
        public KeyCode boostKeybind = KeyCode.LeftShift;

        [Button("Bring nearest Seamoth here")]
        public void TeleportSeamoth(ButtonClickedEventArgs _)
        {
            var seamoths = GameObject.FindObjectsOfType<SeaMoth>();

            if(seamoths.Length < 1)
            {
                Log("None found").WithColor(Colors.Yellow);
                return;
            }

            SeaMoth target = null;
            float closest = float.MaxValue;

            Log($"Checking distances for [{seamoths.Length}] Seamoths").WithColor(Colors.White);

            foreach(SeaMoth seamoth in seamoths)
            {
                float distance = Vector3.Distance(seamoth.transform.position, Player.main.transform.position);

                if(distance < closest)
                {
                    closest = distance;
                    target = seamoth;
                    Log($" >> Set new closest ({distance}m)").WithColor(Colors.Yellow);
                }
            }

            target.TeleportVehicle(Player.main.transform.position, MainCamera.camera.transform.rotation);
        }
    }
}