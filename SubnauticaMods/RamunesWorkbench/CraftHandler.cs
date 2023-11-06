

namespace Ramune.RamunesWorkbench
{
    public static class CraftHandler
    {
        public static CraftTree.Type CraftTreeType => Buildables.RamunesWorkbench.craftTreeType;


        public static IEnumerator Initialize()
        {
            while(CraftTreeType is CraftTree.Type.None)
                yield return null;
            

            LoggerUtils.LogInfo(">> [1/3] Found CraftTreeType for RamunesWorkbench");

            AddTab("Tools", ImageUtils.GetSprite("TabTools"));
            AddTab("Equipment", ImageUtils.GetSprite("TabEquipment"));
            AddTab("Consumables", ImageUtils.GetSprite("TabConsumables"));

            AddTab("Power", ImageUtils.GetSprite("TabPower"));
            AddTab("Batteries", ImageUtils.GetSprite(TechType.Battery), "Power");
            AddTab("PowerCells", "Power cells", ImageUtils.GetSprite(TechType.PowerCell), "Power");

            AddTab("Modules", ImageUtils.GetSprite("TabModules"));
            AddTab("Seamoth", ImageUtils.GetSprite(TechType.Seamoth), "Modules");
            AddTab("Prawn suit", ImageUtils.GetSprite(TechType.Exosuit), "Modules");
            AddTab("Cyclops", ImageUtils.GetSprite(TechType.Cyclops), "Modules");

            LoggerUtils.LogInfo(">> [2/3] Added initial tabs");
            LoggerUtils.LogInfo(" ");


            if(IsLoaded("MegaO2Tank"))
            {
                AddTab("Tanks", ImageUtils.GetSprite(TechType.PlasteelTank), "Equipment");
                AddCraft("MegaO2Tank", "Equipment", "Tanks");
                LoggerUtils.LogInfo("MegaO2Tank sorted!");
            }
            else LoggerUtils.LogInfo("MegaO2Tank is not loaded");


            if(IsLoaded("SeaglideUpgrades"))
            {
                AddTab("Seaglides", ImageUtils.GetSprite(TechType.Seaglide), "Equipment");
                AddCraft("SeaglideMK1", "Equipment", "Seaglides");
                AddCraft("SeaglideMK2", "Equipment", "Seaglides");
                AddCraft("SeaglideMK3", "Equipment", "Seaglides");
                LoggerUtils.LogInfo("SeaglideUpgrades sorted!");
            }
            else LoggerUtils.LogInfo("SeaglideUpgrades is not loaded");


            if(IsLoaded("LithiumBatteries"))
            {
                AddCraft("IonBatteryAlt", "Power", "Batteries");
                AddCraft("IonPowerCellAlt", "Power", "PowerCells");
                AddCraft("LithiumBattery", "Power", "Batteries");
                AddCraft("LithiumPowerCell", "Power", "PowerCells");
                LoggerUtils.LogInfo("LithiumBatteries sorted!");
            }
            else LoggerUtils.LogInfo("LithiumBatteries is not loaded");


            if(IsLoaded("KioniteBatteries"))
            {
                AddCraft("KioniteBattery", "Power", "Batteries");
                AddCraft("KionitePowerCell", "Power", "PowerCells");
                LoggerUtils.LogInfo("KioniteBatteries sorted!");
            }
            else LoggerUtils.LogInfo("KioniteBatteries is not loaded");


            if(IsLoaded("OxygenCanisters"))
            {
                AddCraft("OxygenCanister", "Consumables");
                AddCraft("LargeOxygenCanister", "Consumables");
                LoggerUtils.LogInfo("OxygenCanisters sorted!");
            }
            else LoggerUtils.LogInfo("OxygenCanisters is not loaded");


            if(IsLoaded("SeamothTurbo"))
            {
                AddCraft("SeamothTurbo", "Modules", "Seamoth");
                LoggerUtils.LogInfo("SeamothTurboModule sorted!");
            }
            else LoggerUtils.LogInfo("SeamothTurboModule is not loaded");


            if(IsLoaded("SeamothLeviathanRadar"))
            {
                AddCraft("SeamothLeviathanRadar", "Modules", "Seamoth");
                LoggerUtils.LogInfo("SeamothLeviathanRadar sorted!");
            }
            else LoggerUtils.LogInfo("SeamothLeviathanRadar is not loaded");


            if(IsLoaded("StasisModule"))
            {
                AddCraft("StasisModule", "Modules", "Seamoth");
                LoggerUtils.LogInfo("StasisModule sorted!");
            }
            else LoggerUtils.LogInfo("StasisModule is not loaded");


            LoggerUtils.LogInfo(" ");
            LoggerUtils.LogInfo(">> [3/3] Processed all mod items (if found)");
        }


        public static IEnumerator WaitForChainloader()
        {
            Type chainloader = typeof(BepInEx.Bootstrap.Chainloader);
            FieldInfo loaded = chainloader.GetField("_loaded", BindingFlags.NonPublic | BindingFlags.Static);

            while(!(bool)loaded.GetValue(null))
                yield return null;

            CoroutineHost.StartCoroutine(Initialize());
        }


        public static bool IsLoaded(string guid)
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue("com.ramune." + guid, out _))
            {
                LoggerUtils.LogInfo($">> {guid} sorting..");
                return true;
            }

            return false;
        }


        public static void AddCraft(string techType)
        {
            if(!EnumHandler.TryGetValue(techType, out TechType _techType)) return;
            CraftTreeHandler.AddCraftingNode(CraftTreeType, _techType);
        }


        public static void AddCraft(string techType, params string[] stepsToTab)
        {
            if(!EnumHandler.TryGetValue(techType, out TechType _techType)) return;
            CraftTreeHandler.AddCraftingNode(CraftTreeType, _techType, stepsToTab);
        }


        public static void AddTab(string name, Atlas.Sprite sprite) => CraftTreeHandler.AddTabNode(CraftTreeType, name, name, sprite);


        public static void AddTab(string name, Atlas.Sprite sprite, params string[] stepsToTab) => CraftTreeHandler.AddTabNode(CraftTreeType, name, name, sprite, stepsToTab);


        public static void AddTab(string id, string name, Atlas.Sprite sprite, params string[] stepsToTab) => CraftTreeHandler.AddTabNode(CraftTreeType, id, name, sprite, stepsToTab);
    }
}