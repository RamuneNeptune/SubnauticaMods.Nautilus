

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

            AddTab("Modules", ImageUtils.GetSprite("TabModules"));
            AddTab("Seamoth", ImageUtils.GetSprite(TechType.Seamoth), "Modules");
            AddTab("Prawn suit", ImageUtils.GetSprite(TechType.Exosuit), "Modules");
            AddTab("Cyclops", ImageUtils.GetSprite(TechType.Cyclops), "Modules");

            LoggerUtils.LogInfo(">> [2/3] Added initial tabs");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("MegaO2Tank"))
            {
                AddTab("Tanks", ImageUtils.GetSprite(TechType.PlasteelTank), "Equipment");
                AddCraft("MegaO2Tank", "Equipment", "Tanks");
                LoggerUtils.LogInfo(">> [2/2] MegaO2Tank sorted!");
            }
            else LoggerUtils.LogInfo(">> MegaO2Tank is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("SeaglideUpgrades"))
            {
                AddTab("Seaglides", ImageUtils.GetSprite(TechType.Seaglide), "Equipment");
                AddCraft("SeaglideMK1", "Equipment", "Seaglides");
                AddCraft("SeaglideMK2", "Equipment", "Seaglides");
                AddCraft("SeaglideMK3", "Equipment", "Seaglides");
                LoggerUtils.LogInfo(">> [2/2] SeaglideUpgrades sorted!");
            }
            else LoggerUtils.LogInfo(">> SeaglideUpgrades is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("OxygenCanisters"))
            {
                AddCraft("OxygenCanister", "Consumables");
                AddCraft("LargeOxygenCanister", "Consumables");
                LoggerUtils.LogInfo(">> [2/2] OxygenCanisters sorted!");
            }
            else LoggerUtils.LogInfo(">> OxygenCanisters is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("SeamothTurbo"))
            {
                AddCraft("SeamothTurbo", "Modules", "Seamoth");
                LoggerUtils.LogInfo(">> [2/2] SeamothTurboModule sorted!");
            }
            else LoggerUtils.LogInfo(">> SeamothTurboModule is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("SeamothLeviathanRadar"))
            {
                AddCraft("SeamothLeviathanRadar", "Modules", "Seamoth");
                LoggerUtils.LogInfo(">> [2/2] SeamothLeviathanRadar sorted!");
            }
            else LoggerUtils.LogInfo(">> SeamothLeviathanRadar is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


            if(IsLoaded("StasisModule"))
            {
                AddCraft("StasisModule", "Modules", "Seamoth");
                LoggerUtils.LogInfo(">> [2/2] StasisModule sorted!");
            }
            else LoggerUtils.LogInfo(">> StasisModule is not loaded");
            LoggerUtils.LogInfo("-------------------------------------------------------");


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
                LoggerUtils.LogInfo($">> [1/2] {guid} sorting..");
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
    }
}