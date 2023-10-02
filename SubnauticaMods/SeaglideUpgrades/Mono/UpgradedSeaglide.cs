

namespace Ramune.SeaglideUpgrades.Mono
{
    public class UpgradedSeaglide : MonoBehaviour
    {
        public PlayerController controller;
        public Light[] lights;
        public float acceleration;
        public float speed;
        public bool isSet;

        public UpgradedSeaglide(float _acceleration, float _speed)
        {
            acceleration = _acceleration;
            speed = _speed;
        }

        public void Start()
        {
            controller = Player.main.playerController;
            lights = GetComponentsInChildren<Light>(true);
        }

        public void Update()
        {
            controller.seaglideForwardMaxSpeed = speed;
            controller.seaglideWaterAcceleration = acceleration;

            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.white;
                lights[i].intensity = 1f;
                lights[i].range = 1f;

                if(Player.main.isNewBorn) lights[i].spotAngle = 1f;
                else lights[i].spotAngle = 1f;
            }
        }
    }
}