

namespace Ramune.BZTitaniumIngot
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class BZTitaniumIngot : BaseUnityPlugin
    {
        public static BZTitaniumIngot Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.BZTitaniumIngot";
        public const string Name = "BZ Titanium Ingot";
        public const string Version = "1.0.3";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
            CraftDataHandler.SetRecipeData(TechType.TitaniumIngot, Utilities.CreateRecipe(1, new Ingredient(TechType.Titanium, 5)));
        }
    }
}