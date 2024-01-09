

namespace Ramune.RadiantDepths.Patches
{
    [HarmonyPatch(typeof(BreakableResource))]
    public static class BreakableResourcePatch
    {
        [HarmonyPatch(nameof(BreakableResource.BreakIntoResources)), HarmonyPrefix]
        public static bool BreakIntoResources(BreakableResource __instance)
        {
            if(!__instance.gameObject.TryGetComponent<Monos.CustomOutcrop>(out var outcrop))
                return true;

            if(!__instance.broken)
            {
                __instance.broken = true;
                __instance.SendMessage("OnBreakResource", null, SendMessageOptions.DontRequireReceiver);

                if(__instance.gameObject.GetComponent<VFXBurstModel>()) __instance.gameObject.BroadcastMessage("OnKill");
                else GameObject.Destroy(__instance.gameObject);

                if(__instance.customGoalText != "") GoalManager.main.OnCustomGoalEvent(__instance.customGoalText);

                for(int i = 0; i < outcrop.DropAmount; i++)
                    SpawnPrefabForTechType(outcrop.GetRandomTechType(), __instance);

                FMODUWE.PlayOneShot(__instance.breakSound, __instance.transform.position, 1f);

                if(__instance.hitFX) Utils.PlayOneShotPS(__instance.breakFX, __instance.transform.position, Quaternion.Euler(new Vector3(270f, 0f, 0f)), null);
            }

            return false;
        }


        public static void SpawnPrefabForTechType(TechType techType, BreakableResource parent) => CoroutineHost.StartCoroutine(SpawnPrefabForTechTypeAsync(techType, parent));


        private static IEnumerator SpawnPrefabForTechTypeAsync(TechType techType, BreakableResource parent)
        {
            var task = GetPrefabForTechTypeAsync(techType);
            yield return task;

            var result = task.GetResult();
            var position = parent.transform.position + parent.transform.up * parent.verticalSpawnOffset;
            var go = GameObject.Instantiate(result, position, default);

            var rigidbody = go.EnsureComponent<Rigidbody>();
            UWE.Utils.SetIsKinematicAndUpdateInterpolation(rigidbody, false, false);
            rigidbody.AddTorque(Vector3.right * UnityEngine.Random.Range(3, 6));
            rigidbody.AddForce(parent.transform.up * 0.1f);
        }
    }
}