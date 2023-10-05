

namespace Ramune.SeaglideUpgrades.Monos
{
    public class UpgradedSeaglide : MonoBehaviour
    {
        public PlayerController controller;
        public Light[] lights;

        public Color colorMk1, colorMk2, colorMk3;

        public float acceleration, speed;
        public bool isSet, isMk1, isMk2, isMk3;


        public void Start()
        {
            controller = Player.main.playerController;
            lights = GetComponentsInChildren<Light>(true);
        }


        public void Update()
        {
            if(isMk1)
            {
                controller.seaglideForwardMaxSpeed = speed * SeaglideUpgrades.config.speedmk1;
                controller.seaglideWaterAcceleration = acceleration * SeaglideUpgrades.config.speedmk1;

                if(!SeaglideUpgrades.config.boolmk1) return;

                for (int i = 0; i < lights.Length; i++)
                {
                    colorMk1.r = SeaglideUpgrades.config.redmk1;
                    colorMk1.g = SeaglideUpgrades.config.greenmk1;
                    colorMk1.b = SeaglideUpgrades.config.bluemk1;

                    lights[i].color = colorMk1;
                    lights[i].intensity = 0.9f * SeaglideUpgrades.config.intensitymk1;
                    lights[i].range = 200f * SeaglideUpgrades.config.rangemk1;
                    lights[i].spotAngle = 70 * SeaglideUpgrades.config.conesizemk1;
                }
            }

            if(isMk2)
            {
                controller.seaglideForwardMaxSpeed = speed * SeaglideUpgrades.config.speedmk2;
                controller.seaglideWaterAcceleration = acceleration * SeaglideUpgrades.config.speedmk2;

                if(!SeaglideUpgrades.config.boolmk2) return;

                for (int i = 0; i < lights.Length; i++)
                {
                    colorMk2.r = SeaglideUpgrades.config.redmk2;
                    colorMk2.g = SeaglideUpgrades.config.greenmk2;
                    colorMk2.b = SeaglideUpgrades.config.bluemk2;

                    lights[i].color = colorMk2;
                    lights[i].intensity = 0.9f * SeaglideUpgrades.config.intensitymk2;
                    lights[i].range = 200f * SeaglideUpgrades.config.rangemk2;
                    lights[i].spotAngle = 70 * SeaglideUpgrades.config.conesizemk2;
                }
            }

            if(isMk3)
            {
                controller.seaglideForwardMaxSpeed = speed * SeaglideUpgrades.config.speedmk3;
                controller.seaglideWaterAcceleration = acceleration * SeaglideUpgrades.config.speedmk3;

                if(!SeaglideUpgrades.config.boolmk3) return;

                for(int i = 0; i < lights.Length; i++)
                {
                    colorMk3.r = SeaglideUpgrades.config.redmk3;
                    colorMk3.g = SeaglideUpgrades.config.greenmk3;
                    colorMk3.b = SeaglideUpgrades.config.bluemk3;

                    lights[i].color = colorMk3;
                    lights[i].intensity = 0.9f * SeaglideUpgrades.config.intensitymk3;
                    lights[i].range = 200f * SeaglideUpgrades.config.rangemk3;
                    lights[i].spotAngle = 70 * SeaglideUpgrades.config.conesizemk3;
                }
            }
        }
    }
}