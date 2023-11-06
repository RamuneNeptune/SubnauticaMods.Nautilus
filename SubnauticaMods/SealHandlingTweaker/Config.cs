

namespace Ramune.Seal.HandlingTweaker
{
    [Menu("Seal Handling Tweaker")]
    public class Config : ConfigFile
    {
        [Slider("Steering responsiveness (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(Apply))]
        public float responsiveness = 1f;

        [Slider("Forward accel multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(Apply))]
        public float forwardAccel = 1f;

        [Slider("Vertical accel multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(Apply))]
        public float verticalAccel = 1f;

        [Slider("Turning torque multiplier (x)", Format = "{0:F1}x", DefaultValue = 1f, Min = 0.1f, Max = 10f, Step = 0.1f), OnChange(nameof(Apply))]
        public float torque = 1f;

        public void Apply()
        {
            if(Patches.SealSubRootPatch.seals.Count == 0)
                return;

            foreach (var seal in Patches.SealSubRootPatch.seals)
            {
                if(seal is null) 
                    break;

                var control = seal.GetComponent<SubControl>();
                control.BaseTurningTorque = 0.75f * torque;
                control.steeringReponsiveness = 2f * responsiveness;
                control.BaseVerticalAccel = 7f * verticalAccel;
                //control.BaseForwardAccel = 2f * torque;
            }
        }
    }
}