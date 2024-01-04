

namespace Ramune.SeamothSprint.Monos
{
    public class SeamothSprintController : MonoBehaviour
    {
        public EngineRpmSFXManager engineSFX;
        public EnergyMixin energyMixin;
        public Animator animator;
        public SeaMoth seamoth;
        public Vehicle vehicle;
        public float forward, backward, sideward, speed, pitch, volume, energy = 0.24f;


        public void Start()
        {
            engineSFX = gameObject.GetComponentInChildren<EngineRpmSFXManager>();
            energyMixin = gameObject.GetComponentInChildren<EnergyMixin>();
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
            animator = gameObject.GetComponentInChildren<Animator>();
            vehicle = gameObject.GetComponentInParent<Vehicle>();
            forward = vehicle.forwardForce;
            backward = vehicle.backwardForce;
            sideward = vehicle.sidewardForce;
            speed = animator.speed;
        }


        public void Update()
        {
            if(SeamothSprint.config.requiresModule)
            {
                if(vehicle.modules.GetCount(Items.SeamothSprintModule.Prefab.Info.TechType) <= 0)
                    return;
            }

            if(!seamoth.playerFullyEntered)
                return;

            _ = SeamothSprint.config.energyMultiplier == 1
                ? energy = 0.066667f
                : energy = 0.24f;

            if(GameInput.GetKey(SeamothSprint.config.boostKeybind))
            {
                seamoth.enginePowerConsumption = energy * SeamothSprint.config.energyMultiplier;

                float insanityMultiplier = SeamothSprint.config.isInsanity ? 3f : 1f;
                float multiplier = SeamothSprint.config.speedMultiplier * insanityMultiplier;

                animator.speed = speed * multiplier;
                vehicle.forwardForce = forward * multiplier;
                vehicle.backwardForce = backward * multiplier;
                vehicle.sidewardForce = sideward * multiplier;

                if(pitch != 1.15f || volume != 1.25f)
                {
                    engineSFX.engineRpmSFX.GetEventInstance().getPitch(out pitch);
                    engineSFX.engineRpmSFX.GetEventInstance().getVolume(out volume);

                    if(pitch != 1.15f)
                        engineSFX.engineRpmSFX.GetEventInstance().setPitch(1.15f);

                    if(volume != 1.25f)
                        engineSFX.engineRpmSFX.GetEventInstance().setVolume(1.25f);
                }
            }
            else SetDefault();
        }

        public void SetDefault()
        {
            engineSFX.engineRpmSFX.GetEventInstance().setPitch(1f);
            engineSFX.engineRpmSFX.GetEventInstance().setVolume(1f);
            seamoth.enginePowerConsumption = 0.06666667f;
            vehicle.forwardForce = 12.52f;
            vehicle.backwardForce = 5.45f;
            vehicle.sidewardForce = 12.52f;
        }
    }
}