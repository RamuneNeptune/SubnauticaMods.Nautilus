

namespace Ramune.RadiantBlade.Monos
{
    public partial class RadiantBlade : HeatBlade
    {
        public static FMODAsset AssetSeismic = Nautilus.Utility.AudioUtils.GetFmodAsset("event:/creature/crash/die");

        public static void UseSeismic(Creature creature)
        {
            Rigidbody rb = creature.GetComponent<Rigidbody>();

            float massMultiplier = rb.mass > 100f ? rb.mass * 0.02f : 2f;
            float sizeMultiplier = rb.mass > 10f ? rb.mass * 0.1f : rb.mass * 0.1f;

            AssetSeismicDebris.transform.localScale *= sizeMultiplier;

            WorldForces.AddCurrent(creature.transform.position, DayNightCycle.main.timePassed, 2f, MainCamera.camera.transform.forward, rb.mass * massMultiplier, 4f);
            Utils.PlayOneShotPS(AssetSeismicDebris, creature.transform.position, creature.transform.rotation);
            MainCameraControl.main.ShakeCamera(1f, 2f, MainCameraControl.ShakeMode.Sqrt, 1.4f);
            FMODUWE.PlayOneShot(AssetSeismic, creature.transform.position, 1f);
        }
    }
}