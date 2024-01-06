

namespace Ramune.NukeEm.Monos
{
    public class RifleTool : PlayerTool
    {
        public ParticleSystem chargeEffect;
        public ParticleSystem shootEffect;
        public Transform chargeMeter;
        public GameObject bulletPrefab;
        public FMOD_CustomEmitter sonarSound;
        public FMODAsset shootSound;
        public FMOD_CustomLoopingEmitter chargeSound;
        private float charge = 0f;
        private bool canShoot = true;
        private float sonarTimer = 0f;


        public override string animToolName => "stasisrifle";


        public void Update()
        {
            if(sonarTimer > 0f)
                sonarTimer -= Time.deltaTime;

            chargeMeter.localScale = Vector3.Lerp(new Vector3(0f, 1f, 0.0002f), new Vector3(0.008f, 1f, 0.0002f), charge);
            bool inside = Player.main.IsInBase() || Player.main.IsInSubmarine();

            ikAimLeftArm = !inside;
            ikAimRightArm = !inside;
            useLeftAimTargetOnPlayer = !inside;
        }


        public override bool OnRightHandDown() => false;


        public override bool OnRightHandHeld()
        {
            if(canShoot && energyMixin.charge > 0f && !Player.main.IsInBase() && !Player.main.IsInSubmarine())
            {
                if(charge < 1f)
                {
                    charge += 0.02f;

                    if(!chargeEffect.isPlaying)
                        chargeEffect.Play();

                    MainCameraControl.main.ShakeCamera(0.2f, 0.5f, MainCameraControl.ShakeMode.Sqrt, 2f);
                    chargeSound.Play();
                }
                else
                {
                    charge = 0f;
                    canShoot = false;

                    Player.main.armsController.animator.SetBool("using_tool", false);

                    chargeEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    shootEffect.Play();
                    energyMixin.ConsumeEnergy(50f);
                    chargeSound.Stop();

                    Utils.PlayFMODAsset(shootSound, transform, 20f);

                    var bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
                    bullet.transform.parent = null;
                    bullet.SetActive(true);
                    bullet.GetComponent<Rigidbody>().velocity = SNCameraRoot.main.GetAimingTransform().forward.normalized;
                    bullet.AddComponent<BulletControl>().rb = bullet.GetComponent<Rigidbody>();

                    GameObject.Destroy(bullet, 5f);
                }
            }
            return true;
        }


        public override void OnDraw(Player p)
        {
            base.OnDraw(p);
            charge = 0f;
            chargeEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            shootEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }


        public override void OnHolster() => base.OnHolster();


        public override bool OnRightHandUp()
        {
            chargeEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            charge = 0f;
            canShoot = true;
            chargeSound.Stop();
            return true;
        }


        public override bool OnAltDown()
        {
            if(energyMixin.charge > 0f && sonarTimer <= 0f)
            {
                MainCamera.camera.GetComponent<SonarScreenFX>().Ping();
                energyMixin.ConsumeEnergy(5f);
                sonarTimer = 3f;
                sonarSound.Play();
            }
            return true;
        }
    }
}