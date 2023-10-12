

namespace Ramune.SeaglideBoosting.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    public static class SeaglidePatches
    {
        public static PlayerController pc => Player.main.playerController;
        public static List<float> seaglideDefaults = new() { 1f };
        public static bool isBoosting;
        public static float pitch;
        public static TechType techType;


        [HarmonyPatch(nameof(Seaglide.OnDraw)), HarmonyPrefix]
        public static void OnDraw(Seaglide __instance)
        {
            SetDefaults();
        }


        [HarmonyPatch(nameof(Seaglide.Update)), HarmonyPostfix]
        public static void Update(Seaglide __instance)
        {
            if(techType == TechType.None) techType = __instance.pickupable.GetTechType();
            if(techType != TechType.Seaglide) return;

            isBoosting = GameInput.GetKey(SeaglideBoosting.config.boostKey);

            pc.underWaterController.forwardMaxSpeed = isBoosting 
                ? seaglideDefaults[0] * SeaglideBoosting.config.boostMultiplier 
                : seaglideDefaults[0];

            pc.underWaterController.waterAcceleration = isBoosting 
                ? seaglideDefaults[1] * SeaglideBoosting.config.boostMultiplier
                : seaglideDefaults[1];

            pc.underWaterController.backwardMaxSpeed = isBoosting 
                ? seaglideDefaults[2] * SeaglideBoosting.config.boostMultiplier
                : seaglideDefaults[2];

            pc.underWaterController.strafeMaxSpeed = isBoosting 
                ? seaglideDefaults[2] * SeaglideBoosting.config.boostMultiplier 
                : seaglideDefaults[2];

            pc.underWaterController.verticalMaxSpeed = isBoosting 
                ? seaglideDefaults[2] * SeaglideBoosting.config.boostMultiplier 
                : seaglideDefaults[2];

            pitch = SeaglideBoosting.config.boostMultiplier < 1f
                ? 0.87f
                : 1.1f;

            __instance.animator.speed = isBoosting ? SeaglideBoosting.config.boostMultiplier : 1f;
            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(isBoosting ? pitch : 1f);
            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(isBoosting ? 1.1f : 1f);
        }


        [HarmonyPatch(nameof(Seaglide.UpdateEnergy)), HarmonyPrefix]
        public static bool UpdateEnergy(Seaglide __instance)
        {
            if(techType != TechType.Seaglide) return true;
            if(!isBoosting) return true;

            if(__instance.activeState)
            {
                __instance.timeSinceUse += Time.deltaTime;
                if(__instance.timeSinceUse >= 1f)
                {
                    __instance.energyMixin.ConsumeEnergy(0.3f * SeaglideBoosting.config.energyMultiplier);
                    __instance.timeSinceUse -= 1f;
                }
            }

            return false;
        }

        public static void SetDefaults()
        {
            seaglideDefaults.Clear();
            seaglideDefaults.Add(pc.seaglideForwardMaxSpeed);
            seaglideDefaults.Add(pc.seaglideWaterAcceleration);
            seaglideDefaults.Add(pc.seaglideBackwardMaxSpeed);
        }
    }
}