

namespace Ramune.ConfigurableSeaglide.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    public static class SeaglidePatches
    {
        public static List<float> seaglideDefaults = new() { 25f, 36.56f, 6.35f };
        public static float forwardSpeed, forwardSpeedAccel, backwardSpeed, strafeSpeed, verticalSpeed;

        [HarmonyPatch(nameof(Seaglide.OnDraw)), HarmonyPostfix]
        public static void OnDraw(Seaglide __instance)
        {
            if(__instance.pickupable.GetTechType() != TechType.Seaglide) return;

            forwardSpeed = seaglideDefaults[0] * ConfigurableSeaglide.config.forwardSpeedMultiplier;
            forwardSpeedAccel = seaglideDefaults[1] * ConfigurableSeaglide.config.accelerationMultiplier;
            backwardSpeed = seaglideDefaults[2] * ConfigurableSeaglide.config.backwardSpeedMultiplier;
            strafeSpeed = seaglideDefaults[2] * ConfigurableSeaglide.config.strafeSpeedMultiplier;
            verticalSpeed = seaglideDefaults[2] * ConfigurableSeaglide.config.verticalSpeedMultiplier;

            Player.main.playerController.seaglideForwardMaxSpeed = forwardSpeed;
            Player.main.playerController.seaglideWaterAcceleration = forwardSpeedAccel;
            Player.main.playerController.seaglideBackwardMaxSpeed = backwardSpeed;
            Player.main.playerController.seaglideStrafeMaxSpeed = strafeSpeed;
            Player.main.playerController.seaglideVerticalMaxSpeed = verticalSpeed;
        }
    }
}