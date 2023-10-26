

namespace Ramune.RamunesWorkbench
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RamunesWorkbench : BaseUnityPlugin
    {
        public static RamunesWorkbench Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RamunesWorkbench";
        public const string Name = "Ramune's Workbench";
        public const string Version = "1.0.1";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Buildables.RamunesWorkbench.Patch();

            CoroutineHost.StartCoroutine(CraftHandler.WaitForChainloader());
        }
    }
}