

namespace Ramune.RamunesWorkbench
{
    public static class CraftHandler
    {
        public static CraftTree.Type CraftTreeType => Buildables.RamunesWorkbench.craftTreeType;


        public static IEnumerator WaitForChainloader()
        {
            Type chainloader = typeof(BepInEx.Bootstrap.Chainloader);
            FieldInfo loaded = chainloader.GetField("_loaded", BindingFlags.NonPublic | BindingFlags.Static);

            while(!(bool)loaded.GetValue(null))
                yield return null;

            Initialize();
        }


        public static bool IsLoaded(string guid)
        {
            if(BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue("com.ramune." + guid, out _))
            {
                LoggerUtils.LogFatal($">> {guid} is loaded..");
                return true;
            }

            return false;
        }


        public static void Initialize()
        {
            AddTab("Tools", ImageUtils.GetSprite(TechType.Knife));
            AddTab("Equipment", ImageUtils.GetSprite(TechType.Tank));
            AddTab("Consumables", ImageUtils.GetSprite(TechType.FirstAidKit));

            if(IsLoaded("MegaO2Tank"))
            {
                AddTab("Tanks", ImageUtils.GetSprite(TechType.Tank), "Equipment");
                AddCraft("MegaO2Tank", "Equipment", "Tanks");
            }

            if(IsLoaded("SeaglideUpgrades"))
            {
                AddTab("Seaglides", ImageUtils.GetSprite(TechType.Seaglide), "Equipment");
                AddCraft("SeaglideMK1", "Equipment", "Seaglides");
                AddCraft("SeaglideMK2", "Equipment", "Seaglides");
                AddCraft("SeaglideMK3", "Equipment", "Seaglides");
            }

            if(IsLoaded("OxygenCanisters"))
            {
                AddTab("Oxygen", ImageUtils.GetSprite("OxygenTab"), "Consumables");
                AddCraft("OxygenCanister", "Consumables", "Oxygen");
                AddCraft("LargeOxygenCanister", "Consumables", "Oxygen");
            }
        }


        public static void AddTab(string name, Atlas.Sprite sprite, params string[] stepsToTab)
        {
            if(stepsToTab is null) CraftTreeHandler.AddTabNode(CraftTreeType, name, name, sprite);
            else CraftTreeHandler.AddTabNode(CraftTreeType, name, name, sprite, stepsToTab);
        }


        public static void AddCraft(string techType, params string[] stepsToTab)
        {
            if(!EnumHandler.TryGetValue(techType, out TechType _techType))
                return;

            if(stepsToTab is null) CraftTreeHandler.AddCraftingNode(CraftTreeType, _techType);
            else CraftTreeHandler.AddCraftingNode(CraftTreeType, _techType, stepsToTab);
        }
    }
}