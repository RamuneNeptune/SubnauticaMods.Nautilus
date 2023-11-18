

namespace Ramune.Seal.ModuleSorter
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SealModuleSorter : BaseUnityPlugin
    {
        public static SealModuleSorter Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.Seal.ModuleSorter";
        public const string Name = "Seal Module Sorter";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);

            CraftTreeHandler.AddTabNode(Plugin.SealFabricatorTree, "Default", "Default", ImageUtils.GetSprite(TechType.CyclopsSonarModule));
        }
    }
}