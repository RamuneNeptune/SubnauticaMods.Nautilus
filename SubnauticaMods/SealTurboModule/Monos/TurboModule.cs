

namespace Ramune.Seal.TurboModule.Monos
{
    [SealUpgradeModule("SealTurboModule")]
    public class TurboModule : MonoBehaviour
    {
        public EngineRpmSFXManager engineSFX;
        public SubControl control;
        public float cooldown, original;
        public bool debug = false;


        public void Start()
        {
            control = gameObject.GetComponentInParent<SubControl>();
            engineSFX = control.engineRPMManager;

            cooldown = Time.time;
        }


        public void Update()
        {            
            if(Player.main.currentSub is not SealSubRoot)
                return;

            if(!Player.main.isPiloting)
                return;

            if(!Input.anyKey)
                return;

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(debug) LoggerUtils.Screen.LogInfo("Pressed LeftShift");

                if(Time.time < cooldown)
                {
                    if(debug) LoggerUtils.Screen.LogFail("Time.time < cooldown");

                    LoggerUtils.LogSubtitle($"SEAL: Used turbo too recently, try again in {Mathf.RoundToInt(Mathf.Max(0.0f, cooldown - Time.time))} seconds.", 3f);

                    return;
                }

                if(debug) LoggerUtils.Screen.LogSuccess("Time.time > cooldown");

                cooldown = Time.time + SealTurboModule.config.cooldown;
                original = control.BaseForwardAccel;

                control.BaseForwardAccel = Mathf.Lerp(original, original * SealTurboModule.config.multiplier, 0.3f);

                LoggerUtils.LogSubtitle("SEAL: Activating turbo systems.", 3f);

                if(debug) LoggerUtils.Screen.LogSuccess($"1/2 -- Lerped from '{original}' to '{original * SealTurboModule.config.multiplier}'");

                if(engineSFX is not null)
                {
                    engineSFX.engineRpmSFX.GetEventInstance().setPitch(Mathf.Lerp(1f, 1.1f, 1f));
                    engineSFX.engineRpmSFX.GetEventInstance().setVolume(Mathf.Lerp(1f, 1.15f, 1));
                }

                MainCameraControl.main.ShakeCamera(1f, SealTurboModule.config.duration, MainCameraControl.ShakeMode.Quadratic, 1f);

                CoroutineHost.StartCoroutine(DecreaseSpeed());

                if(debug) LoggerUtils.Screen.LogInfo("Started coroutine 'DecreaseSpeed()'");
            }
        }

        public IEnumerator DecreaseSpeed()
        {
            yield return new WaitForSeconds(SealTurboModule.config.duration);

            control.BaseForwardAccel = original;

            if(engineSFX is not null)
            {
                engineSFX.engineRpmSFX.GetEventInstance().setPitch(Mathf.Lerp(1.1f, 1f, 1f));
                engineSFX.engineRpmSFX.GetEventInstance().setVolume(Mathf.Lerp(1.15f, 1f, 1f));
            }

            if(debug) LoggerUtils.Screen.LogSuccess($"2/2 -- Lerped back to '{original}' from '{original * SealTurboModule.config.multiplier}' ");
        }
    }
}