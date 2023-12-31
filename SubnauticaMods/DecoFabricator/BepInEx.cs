﻿

namespace Ramune.DecoFabricator
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class DecoFabricator : BaseUnityPlugin
    {
        public static DecoFabricator Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.DecoFabricator";
        public const string Name = "Deco Fabricator";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Initializer.Initialize(harmony, Logger, Name, Version);
            Buildables.DecoFabricator.Patch();
        }
    }
}