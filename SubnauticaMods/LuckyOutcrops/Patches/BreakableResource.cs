

namespace Ramune.LuckyOutcrops.Patches
{
    [HarmonyPatch(typeof(BreakableResource))]
    public static class BreakableResourcePatch
    {
        public static float chance;

        [HarmonyPatch(nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResources(BreakableResource __instance)
        {
            chance = LuckyOutcrops.config.crashfishChance / 100f;

            if (UnityEngine.Random.value < chance)
            {
                __instance.broken = true;
                __instance.SendMessage("OnBreakResource", null, SendMessageOptions.DontRequireReceiver);

                if (__instance.gameObject.GetComponent<VFXBurstModel>()) __instance.gameObject.BroadcastMessage("OnKill");
                else UnityEngine.Object.Destroy(__instance.gameObject);

                if (__instance.customGoalText != "") GoalManager.main.OnCustomGoalEvent(__instance.customGoalText);

                FMODUWE.PlayOneShot(__instance.breakSound, __instance.transform.position, 1f);

                if (__instance.hitFX) global::Utils.PlayOneShotPS(__instance.breakFX, __instance.transform.position, Quaternion.Euler(new Vector3(270f, 0f, 0f)), null);

                DevConsole.SendConsoleCommand("spawn crash");
                return false;
            }

            return true;
        }
    }
}