

namespace Ramune.OrganizedWorkbench
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class OrganizedWorkbench : BaseUnityPlugin
    {
        public static OrganizedWorkbench Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.OrganizedWorkbench";
        public const string Name = "Organized Workbench";
        public const string Version = "2.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);

            List<(TechType, string)> list = new()
            {
                { (TechType.LithiumIonBattery, "") },
                { (TechType.HeatBlade , "Tools") },
                { (TechType.PlasteelTank , "Equipment") },
                { (TechType.HighCapacityTank , "Equipment") },
                { (TechType.UltraGlideFins , "Equipment") },
                { (TechType.SwimChargeFins , "Equipment") },
                { (TechType.RepulsionCannon , "Tools") },
                { (TechType.VehicleHullModule2 , "Modules") },
                { (TechType.VehicleHullModule3 , "Modules") },
                { (TechType.ExoHullModule2 , "Modules") },
                { (TechType.CyclopsHullModule2 , "Modules") },
                { (TechType.CyclopsHullModule3 , "Modules") },
            };

            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "Vanilla");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Tools", "Tools", Utilities.GetSprite(TechType.Knife));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Equipment", "Equipment", Utilities.GetSprite(TechType.Tank));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Modules", "Modules", Utilities.GetSprite(TechType.VehicleHullModule1));

            foreach(var value in list.Skip(1)) CraftTreeHandler.AddCraftingNode(CraftTree.Type.Workbench, value.Item1, value.Item2);
        }
    }
}