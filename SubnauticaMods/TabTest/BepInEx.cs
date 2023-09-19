

namespace Ramune.TabTest
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class TabTest : BaseUnityPlugin
    {
        public static TabTest Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.TabTest";
        public const string Name = "Tab Test";
        public const string Version = "1.0.0";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);

            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "Shapes", "Shapes", Utilities.GetSprite(TechType.AcidMushroom));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "RedShapes", "Red Shapes", Utilities.GetSprite(TechType.WhiteMushroom), "Shapes");

            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, TechType.Titanium, "----------------");



            string mainTabPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "UI", "GlassCube.png"); // The tab icon for the mod (fabricator)
            string deCompressedTabPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "UI", "UnCompressedItem.png"); // The tab icon for uncompression (fabricator)

            var mainTabIcon = ImageUtils.LoadSpriteFromFile(mainTabPath);
            var deCompressedTabIcon = ImageUtils.LoadSpriteFromFile(deCompressedTabPath);

            // All crafting tabs are below this point
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "CompactedItems", "Compacted Items", mainTabIcon);
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "UnpackedItems", "Unpacked Items", deCompressedTabIcon, "CompactedItems");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "CompactedTitanium", "Titanium", SpriteManager.Get(TechType.Titanium), "CompactedItems");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "CompactedCopper", "Copper", SpriteManager.Get(TechType.Copper), "CompactedItems");

            // All crafting recipes are below this point
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, TechType.Seaglide, "CompactedItems", "CompactedTitanium");
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, TechType.Knife, "CompactedItems", "CompactedCopper");

            // All crafting recipes for unpacking are below this point
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, TechType.Builder, "UnpackedItems");
        }
    }
}