

namespace Ramune.SealRailingSettings.Patches
{
    [HarmonyPatch(typeof(SealSubRoot))]
    public static class SealSubRootPatch
    {
        public static GameObject RailingLeftCollision;
        public static GameObject RailingRightCollision;
        public static MeshRenderer RailingLeftMeshRenderer;
        public static MeshRenderer RailingRightMeshRenderer;


        [HarmonyPatch(nameof(SealSubRoot.Start)), HarmonyPostfix]
        public static void Start(SealSubRoot __instance)
        {
            if(LoggerUtils.Debug) LoggerUtils.Screen.LogInfo("SealSubRoot.Start() -- Starting..");

            var rendererParent = __instance.gameObject.FindChild("Scaler").FindChild("SealSubModelPrefab").FindChild("Seal Sub");

            if(rendererParent != null)
            {
                RailingLeftMeshRenderer = rendererParent.FindChild("Railing L")?.GetComponent<MeshRenderer>();
                RailingRightMeshRenderer = rendererParent.FindChild("Railing R")?.GetComponent<MeshRenderer>();

                if(RailingLeftMeshRenderer != null && RailingRightMeshRenderer != null)
                {
                    RailingLeftMeshRenderer.material.color = SealRailingSettings.config.leftColor;
                    RailingRightMeshRenderer.material.color = SealRailingSettings.config.rightColor;
                }
                else if(LoggerUtils.Debug) LoggerUtils.Screen.LogError("MeshRenderer components not found in the rendererParent");
            }
            else if(LoggerUtils.Debug) LoggerUtils.Screen.LogError("Renderer parent not found");

            var collisionParent = __instance.gameObject.FindChild("Scaler").FindChild("Collision").FindChild("Interior").FindChild("MainRoom");

            if(collisionParent != null)
            {
                RailingLeftCollision = collisionParent.FindChild("HoleRailStairThing (1)");
                RailingRightCollision = collisionParent.FindChild("HoleRailStairThing");

                if(RailingLeftCollision != null && RailingRightCollision != null)
                {
                    RailingLeftCollision.SetActive(SealRailingSettings.config.leftCollision);
                    RailingRightCollision.SetActive(SealRailingSettings.config.rightCollision);
                }
                else if(LoggerUtils.Debug) LoggerUtils.Screen.LogError("Colliders not found in the collisionParent");
            }
            else if(LoggerUtils.Debug) LoggerUtils.Screen.LogError("Collision parent not found");

            if(LoggerUtils.Debug) LoggerUtils.Screen.LogInfo("SealSubRoot.Start() -- Finished!");
        }
    }
}