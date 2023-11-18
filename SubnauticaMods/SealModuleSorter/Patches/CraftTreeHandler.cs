

namespace Ramune.Seal.ModuleSorter.Patches
{
    [HarmonyPatch(typeof(CraftTreeHandler))]
    public static class CraftTreeHandlerPatch
    {
        [HarmonyPatch(nameof(CraftTreeHandler.AddCraftingNode), argumentTypes: new Type[] { typeof(CraftTree.Type), typeof(TechType) }), HarmonyPrefix]
        public static bool AddCraftingNode(CraftTree.Type craftTree, TechType craftingItem)
        {
            if(craftTree != Plugin.SealFabricatorTree)
                return true;

            string[] steps = { "Default" };

            if(Nautilus.Patchers.CraftTreePatcher.CustomTrees.TryGetValue(craftTree, out ModCraftTreeRoot root))
            {
                root.AddCraftNode(craftingItem, steps.LastOrDefault());
                return false;
            }

            Nautilus.Patchers.CraftTreePatcher.CraftingNodes.Add(new CraftingNode(steps, craftTree, craftingItem));

            return false;
        }
    }
}