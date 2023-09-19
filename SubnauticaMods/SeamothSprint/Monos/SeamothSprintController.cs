

namespace Ramune.SeamothSprint.Monos
{
    public class SeamothSprintController : MonoBehaviour
    {
        public EngineRpmSFXManager engineSFX;
        public EnergyMixin energyMixin;
        public Animator animator;
        public SeaMoth seamoth;
        public Vehicle vehicle;
        public float forward, backward, sideward, energy = 0.24f, speed;

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
            if(!SeamothSprint.config.isEnabled) return;
            if(SeamothSprint.config.energyMultiplier == 1) energy = 0.066667f;
            if(!seamoth.playerFullyEntered) return;

            if(GameInput.GetKey(SeamothSprint.config.boostKeybind))
            {
                seamoth.enginePowerConsumption = energy * SeamothSprint.config.energyMultiplier;

                engineSFX.engineRpmSFX.GetEventInstance().setPitch(1.15f);
                engineSFX.engineRpmSFX.GetEventInstance().setVolume(1.25f);

                animator.speed = SeamothSprint.config.isInsanity
                    ? (speed * SeamothSprint.config.speedMultiplier * 3f)
                    : (speed * SeamothSprint.config.speedMultiplier);

                vehicle.forwardForce = SeamothSprint.config.isInsanity
                    ? (forward * SeamothSprint.config.speedMultiplier * 3f)
                    : (forward * SeamothSprint.config.speedMultiplier);

                vehicle.backwardForce = SeamothSprint.config.isInsanity
                    ? (backward * SeamothSprint.config.speedMultiplier * 3f)
                    : (backward * SeamothSprint.config.speedMultiplier);

                vehicle.sidewardForce = SeamothSprint.config.isInsanity
                    ? (sideward * SeamothSprint.config.speedMultiplier * 3f)
                    : (sideward * SeamothSprint.config.speedMultiplier);
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