

namespace Ramune.EscapeClosesPDA
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class EscapeClosesPDA : BaseUnityPlugin
    {
        public static EscapeClosesPDA Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.EscapeClosesPDA";
        public const string Name = "Escape Closes PDA";
        public const string Version = "1.0.0";

        public void Start()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}