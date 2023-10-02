

namespace Ramune.RamunesTextureUpscales
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class RamunesTextureUpscales : BaseUnityPlugin
    {
        public static RamunesTextureUpscales Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.RamunesTextureUpscales";
        public const string Name = "Ramunes Texture Upscales";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}