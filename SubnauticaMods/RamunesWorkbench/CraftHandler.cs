

using Nautilus.Handlers;

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

            AddTab("Tools", ImageUtils.GetSprite(TechType.Knife));
            AddTab("Equipment", ImageUtils.GetSprite(TechType.Tank));
            AddTab("Consumables", ImageUtils.GetSprite(TechType.FirstAidKit));

            LoggerUtils.LogInfo(">> [2/3] Added initial tabs..");


            if(IsLoaded("MegaO2Tank"))
            {
                AddTab("Tanks", ImageUtils.GetSprite(TechType.Tank), new string[] { "Equipment" });
                AddCraft("MegaO2Tank", "Equipment", "Tanks");
                LoggerUtils.LogInfo(">> [---] MegaO2Tank tabs and crafts have been handled!");
            }           
            else LoggerUtils.LogInfo(">> [---] MegaO2Tank is not loaded, skipped..");


            if(IsLoaded("SeaglideUpgrades"))
            {
                AddTab("Seaglides", ImageUtils.GetSprite(TechType.Seaglide), "Equipment");
                AddCraft("SeaglideMK1", "Equipment", "Seaglides");
                AddCraft("SeaglideMK2", "Equipment", "Seaglides");
                AddCraft("SeaglideMK3", "Equipment", "Seaglides");
                LoggerUtils.LogInfo(">> [---] SeaglideUpgrades tabs and crafts have been  handled!");
            }
            else LoggerUtils.LogInfo(">> [---] SeaglideUpgrades is not loaded, skipped..");


            if(IsLoaded("OxygenCanisters"))
            {
                AddTab("Oxygen", ImageUtils.GetSprite("OxygenTab"), "Consumables");
                AddCraft("OxygenCanister", "Consumables", "Oxygen");
                AddCraft("LargeOxygenCanister", "Consumables", "Oxygen");
                LoggerUtils.LogInfo(">> [---] OxygenCanisters tabs and crafts have been handled!");
            }
            else LoggerUtils.LogInfo(">> [---] OxygenCanisters is not loaded, skipped..");


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
                LoggerUtils.LogInfo($">> [---] {guid} found, processing..");
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