

namespace Ramune.IonCubeCrafting
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class IonCubeCrafting : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static IonCubeCrafting Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public static string ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public const string GUID = "com.ramune.IonCubeCrafting";
        public const string Name = "Ion Cube Crafting";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            //CraftDataHandler.SetRecipeData(TechType.PrecursorIonCrystal 
        }
    }
}