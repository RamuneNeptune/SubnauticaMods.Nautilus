

namespace Ramune.SealRailingSettings
{
    [Menu("Seal Railing Settings")]
    public class Config : ConfigFile
    {
        [Toggle("Railing (Left) Collision"), OnChange(nameof(OnChange))]
        public bool leftCollision = true;

        [ColorPicker("Railing (Left) Color", Advanced = true), OnChange(nameof(OnChange))]
        public Color leftColor = new(1f, 1f, 1f, 0.2f);

        [Toggle("Railing (Right) Collision"), OnChange(nameof(OnChange))]
        public bool rightCollision = true;

        [ColorPicker("Railing (Right) Color", Advanced = true), OnChange(nameof(OnChange))]
        public Color rightColor = new(1f, 1f, 1f, 0.2f);


        public void OnChange(EventArgs _)
        {
            if(Patches.SealSubRootPatch.RailingLeftMeshRenderer != null && Patches.SealSubRootPatch.RailingRightMeshRenderer != null)
            {
                Patches.SealSubRootPatch.RailingLeftMeshRenderer.material.color = SealRailingSettings.config.leftColor;
                Patches.SealSubRootPatch.RailingRightMeshRenderer.material.color = SealRailingSettings.config.rightColor;
            }
            else LoggerUtils.Screen.LogError("MeshRenderer components not found in the rendererParent");


            if(Patches.SealSubRootPatch.RailingLeftCollision != null && Patches.SealSubRootPatch.RailingRightCollision != null)
            {
                Patches.SealSubRootPatch.RailingLeftCollision.SetActive(SealRailingSettings.config.leftCollision);
                Patches.SealSubRootPatch.RailingRightCollision.SetActive(SealRailingSettings.config.rightCollision);
            }
            else LoggerUtils.Screen.LogError("Colliders not found in the collisionParent");
        }
    }
}